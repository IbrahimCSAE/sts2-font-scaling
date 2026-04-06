using System;
using System.Collections.Generic;
using Godot;
using MegaCrit.Sts2.addons.mega_text;

namespace FontScalerMod.FontScalerModCode;

internal static class FontScalingService
{
    private static readonly object SyncObject = new();
    private static readonly List<TrackedControl> TrackedControls = new();

    public static void RefreshAll()
    {
        lock (SyncObject)
        {
            CleanupDeadControls();

            MainFile.Logger.Info($"FontScaler: refreshing {TrackedControls.Count} controls at scale {FontScalerConfig.FontScale:F2}");

            foreach (TrackedControl tracked in TrackedControls)
            {
                if (!tracked.ControlRef.TryGetTarget(out Control? control) || control == null || !GodotObject.IsInstanceValid(control))
                {
                    continue;
                }

                foreach ((StringName fontName, int baseSize) in tracked.BaseSizes)
                {
                    ApplyScale(control, fontName, baseSize);
                }
            }
        }
    }

    private static readonly StringName[] RichTextFontNames =
    {
        ThemeConstants.RichTextLabel.normalFontSize,
        ThemeConstants.RichTextLabel.boldFontSize,
        ThemeConstants.RichTextLabel.boldItalicsFontSize,
        ThemeConstants.RichTextLabel.italicsFontSize,
        ThemeConstants.RichTextLabel.monoFontSize
    };

    public static void RegisterAndApply(Control control, StringName fontName, ref int size)
    {
        if (control == null || fontName == default || size <= 0)
        {
            return;
        }

        lock (SyncObject)
        {
            CleanupDeadControls();
            TrackedControl tracked = GetOrCreateTracked(control);
            if (!tracked.BaseSizes.TryGetValue(fontName, out int baseSize))
            {
                baseSize = size;
                tracked.BaseSizes[fontName] = baseSize;
            }
            size = ScaleValue(baseSize);
        }
    }

    private static readonly StringName LabelFontSize = new("font_size");

    public static void RegisterFont(Control control, StringName fontName, int baseSize)
    {
        if (control == null || fontName == default || baseSize <= 0)
        {
            return;
        }

        lock (SyncObject)
        {
            CleanupDeadControls();
            TrackedControl tracked = GetOrCreateTracked(control);

            if (!tracked.BaseSizes.ContainsKey(fontName))
            {
                tracked.BaseSizes[fontName] = baseSize;
            }

            ApplyScale(control, fontName, tracked.BaseSizes[fontName]);
        }
    }

    public static void RegisterFont(Control control, StringName fontName)
    {
        if (control == null || fontName == default)
        {
            return;
        }

        int baseSize = ResolveFontSize(control, fontName);
        if (baseSize > 0)
        {
            RegisterFont(control, fontName, baseSize);
        }
    }

    public static void RegisterLabelFont(Control? control)
    {
        if (control == null)
        {
            return;
        }

        RegisterFont(control, LabelFontSize);
    }

    public static void RegisterRichTextFonts(Control? control)
    {
        if (control == null)
        {
            return;
        }

        foreach (StringName name in RichTextFontNames)
        {
            RegisterFont(control, name);
        }
    }

    public static void RegisterControlTree(Control? control)
    {
        if (control == null)
        {
            return;
        }

        ApplyScalingToControl(control);
    }

    private static void ApplyScalingToControl(Control control)
    {
        switch (control)
        {
            case MegaLabel:
                RegisterLabelFont(control);
                break;
            case MegaRichTextLabel:
                RegisterRichTextFonts(control);
                break;
            case Label:
                RegisterFont(control, LabelFontSize);
                break;
            case RichTextLabel:
                foreach (StringName fontName in RichTextFontNames)
                {
                    RegisterFont(control, fontName);
                }
                break;
        }

        foreach (Node child in control.GetChildren())
        {
            if (child is Control childControl)
            {
                ApplyScalingToControl(childControl);
            }
        }
    }

    public static void ApplyFontScale(Control control, StringName fontName)
    {
        if (control == null || fontName == default)
        {
            return;
        }

        lock (SyncObject)
        {
            CleanupDeadControls();
            TrackedControl tracked = GetOrCreateTracked(control);

            if (!tracked.BaseSizes.TryGetValue(fontName, out int baseSize))
            {
                baseSize = control.GetThemeFontSize(fontName);
                if (baseSize <= 0)
                {
                    return;
                }

                tracked.BaseSizes[fontName] = baseSize;
            }

            ApplyScale(control, fontName, baseSize);
        }
    }

    public static int ScaleValue(int baseSize)
    {
        if (baseSize <= 0)
        {
            return baseSize;
        }
        if (FontScalerConfig.Mode == FontScalingMode.Absolute)
        {
            return Math.Max(1, (int)Math.Round(FontScalerConfig.AbsoluteFontSize, MidpointRounding.AwayFromZero));
        }

        double scale = Math.Clamp(FontScalerConfig.FontScale, 1.0, 3.0);
        return Math.Max(1, (int)Math.Round(baseSize * scale, MidpointRounding.AwayFromZero));
    }

    private static void ApplyScale(Control control, StringName fontName, int baseSize)
    {
        int scaledSize = ScaleValue(baseSize);
        control.AddThemeFontSizeOverride(fontName, scaledSize);
    }

    private static TrackedControl GetOrCreateTracked(Control control)
    {
        foreach (TrackedControl tracked in TrackedControls)
        {
            if (tracked.ControlRef.TryGetTarget(out Control? existing) && existing == control)
            {
                return tracked;
            }
        }

        var created = new TrackedControl(control);
        TrackedControls.Add(created);
        return created;
    }

    private static void CleanupDeadControls()
    {
        for (int i = TrackedControls.Count - 1; i >= 0; i--)
        {
            if (!TrackedControls[i].ControlRef.TryGetTarget(out Control? control) || control == null || !GodotObject.IsInstanceValid(control))
            {
                TrackedControls.RemoveAt(i);
            }
        }
    }

    private sealed class TrackedControl
    {
        public TrackedControl(Control control)
        {
            ControlRef = new WeakReference<Control>(control);
        }

        public WeakReference<Control> ControlRef { get; }
        public Dictionary<StringName, int> BaseSizes { get; } = new();
    }

    private static int ResolveFontSize(Control control, StringName fontName)
    {
        int size = control.GetThemeFontSize(fontName);
        if (size <= 0)
        {
            size = control.GetThemeFontSize(fontName, control.GetClass());
        }

        if (size <= 0 && FontScalerConfig.Mode == FontScalingMode.Absolute)
        {
            size = Math.Max(1, (int)Math.Round(FontScalerConfig.AbsoluteFontSize, MidpointRounding.AwayFromZero));
        }

        return size;
    }
}

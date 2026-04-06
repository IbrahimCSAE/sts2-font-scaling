using Godot;
using HarmonyLib;
using MegaCrit.Sts2.addons.mega_text;

namespace FontScalerMod.FontScalerModCode;

[HarmonyPatch(typeof(MegaRichTextLabel), "SetFontSize")]
internal static class MegaRichTextLabelPatches
{
    private static readonly StringName[] FontNames =
    {
        ThemeConstants.RichTextLabel.normalFontSize,
        ThemeConstants.RichTextLabel.boldFontSize,
        ThemeConstants.RichTextLabel.boldItalicsFontSize,
        ThemeConstants.RichTextLabel.italicsFontSize,
        ThemeConstants.RichTextLabel.monoFontSize
    };

    private static void Postfix(MegaRichTextLabel __instance, int size)
    {
        foreach (StringName fontName in FontNames)
        {
            FontScalingService.RegisterFont(__instance, fontName, size);
        }
    }
}

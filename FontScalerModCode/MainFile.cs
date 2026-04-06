using System;
using BaseLib.Config;
using Godot;
using HarmonyLib;
using MegaCrit.Sts2.Core.Modding;

namespace FontScalerMod.FontScalerModCode;

//You're recommended but not required to keep all your code in this package and all your assets in the FontScalerMod folder.
[ModInitializer(nameof(Initialize))]
public partial class MainFile : Node
{
    public const string ModId = "FontScalerMod"; //At the moment, this is used only for the Logger and harmony names.

    public static MegaCrit.Sts2.Core.Logging.Logger Logger { get; } = new(ModId, MegaCrit.Sts2.Core.Logging.LogType.Generic);

    public static void Initialize()
    {
        ModConfigRegistry.Register(ModId, new FontScalerConfig());

        if (ModConfigRegistry.Get(ModId) is FontScalerConfig config)
        {
            config.ConfigChanged += OnConfigChanged;
            config.Load();
            Logger.Info($"FontScaler: loaded config scale={FontScalerConfig.FontScale:F2}");
        }

        FontScalingService.RefreshAll();

        Harmony harmony = new(ModId);

        harmony.PatchAll();
    }

    private static void OnConfigChanged(object? sender, EventArgs e)
    {
        Logger.Info($"FontScaler: config changed scale={FontScalerConfig.FontScale:F2}");
        FontScalingService.RefreshAll();
    }
}

using Godot;
using HarmonyLib;

namespace FontScalerMod.FontScalerModCode;

[HarmonyPatch(typeof(Control))]
internal static class ControlFontSizeOverridePatch
{
    [HarmonyPrefix]
    [HarmonyPatch(nameof(Control.AddThemeFontSizeOverride), typeof(StringName), typeof(int))]
    private static void ScaleFontOverride(Control __instance, StringName name, [HarmonyArgument("fontSize")] ref int fontSize)
    {
        FontScalingService.RegisterAndApply(__instance, name, ref fontSize);
    }
}

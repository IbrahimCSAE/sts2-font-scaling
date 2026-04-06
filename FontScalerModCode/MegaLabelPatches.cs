using Godot;
using HarmonyLib;
using MegaCrit.Sts2.addons.mega_text;

namespace FontScalerMod.FontScalerModCode;

[HarmonyPatch(typeof(MegaLabel), "SetFontSize")]
internal static class MegaLabelPatches
{
    private static void Postfix(MegaLabel __instance, int size)
    {
        FontScalingService.RegisterFont(__instance, ThemeConstants.Label.fontSize, size);
    }
}

using Godot;
using HarmonyLib;
using MegaCrit.Sts2.Core.Nodes.Screens;

namespace FontScalerMod.FontScalerModCode;

[HarmonyPatch(typeof(NDeckViewScreen), "_Ready")]
internal static class NDeckViewScreenPatches
{
    private static void Postfix(NDeckViewScreen __instance)
    {
        FontScalingService.RegisterControlTree(__instance);
    }
}

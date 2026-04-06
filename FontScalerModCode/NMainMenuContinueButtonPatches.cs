using HarmonyLib;
using MegaCrit.Sts2.Core.Nodes.Screens.MainMenu;

namespace FontScalerMod.FontScalerModCode;

[HarmonyPatch(typeof(NMainMenuContinueButton), "_Ready")]
internal static class NMainMenuContinueButtonPatches
{
    private static void Postfix(NMainMenuContinueButton __instance)
    {
        FontScalingService.RegisterControlTree(__instance);
    }
}

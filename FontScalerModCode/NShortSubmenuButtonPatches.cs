using HarmonyLib;
using MegaCrit.Sts2.Core.Nodes.Screens.MainMenu;

namespace FontScalerMod.FontScalerModCode;

[HarmonyPatch(typeof(NShortSubmenuButton), "_Ready")]
internal static class NShortSubmenuButtonPatches
{
    private static void Postfix(NShortSubmenuButton __instance)
    {
        FontScalingService.RegisterControlTree(__instance);
    }
}

using HarmonyLib;
using MegaCrit.Sts2.Core.Nodes.Screens.MainMenu;

namespace FontScalerMod.FontScalerModCode;

[HarmonyPatch(typeof(NCompendiumSubmenu), "_Ready")]
internal static class NCompendiumSubmenuPatches
{
    private static void Postfix(NCompendiumSubmenu __instance)
    {
        FontScalingService.RegisterControlTree(__instance);
    }
}

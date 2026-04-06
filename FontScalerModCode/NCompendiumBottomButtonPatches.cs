using HarmonyLib;
using MegaCrit.Sts2.Core.Nodes.Screens.MainMenu;

namespace FontScalerMod.FontScalerModCode;

[HarmonyPatch(typeof(NCompendiumBottomButton), "_Ready")]
internal static class NCompendiumBottomButtonPatches
{
    private static void Postfix(NCompendiumBottomButton __instance)
    {
        FontScalingService.RegisterControlTree(__instance);
    }
}

using HarmonyLib;
using MegaCrit.sts2.Core.Nodes.TopBar;
using MegaCrit.Sts2.addons.mega_text;

namespace FontScalerMod.FontScalerModCode;

[HarmonyPatch(typeof(NTopBarGold), "_Ready")]
internal static class NTopBarGoldPatches
{
    private static readonly AccessTools.FieldRef<NTopBarGold, MegaLabel> GoldLabelRef =
        AccessTools.FieldRefAccess<NTopBarGold, MegaLabel>("_goldLabel");

    private static readonly AccessTools.FieldRef<NTopBarGold, MegaLabel> GoldPopupLabelRef =
        AccessTools.FieldRefAccess<NTopBarGold, MegaLabel>("_goldPopupLabel");

    private static void Postfix(NTopBarGold __instance)
    {
        FontScalingService.RegisterLabelFont(GoldLabelRef(__instance));
        FontScalingService.RegisterLabelFont(GoldPopupLabelRef(__instance));
    }
}

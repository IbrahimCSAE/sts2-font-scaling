using HarmonyLib;
using MegaCrit.sts2.Core.Nodes.TopBar;
using MegaCrit.Sts2.addons.mega_text;

namespace FontScalerMod.FontScalerModCode;

[HarmonyPatch(typeof(NTopBarHp), "_Ready")]
internal static class NTopBarHpPatches
{
    private static readonly AccessTools.FieldRef<NTopBarHp, MegaLabel> HpLabelRef =
        AccessTools.FieldRefAccess<NTopBarHp, MegaLabel>("_hpLabel");

    private static void Postfix(NTopBarHp __instance)
    {
        MegaLabel label = HpLabelRef(__instance);
        FontScalingService.RegisterLabelFont(label);
    }
}

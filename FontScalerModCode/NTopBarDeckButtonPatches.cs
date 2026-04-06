using HarmonyLib;
using MegaCrit.Sts2.Core.Nodes.TopBar;
using MegaCrit.Sts2.addons.mega_text;

namespace FontScalerMod.FontScalerModCode;

[HarmonyPatch(typeof(NTopBarDeckButton), "_Ready")]
internal static class NTopBarDeckButtonPatches
{
    private static readonly AccessTools.FieldRef<NTopBarDeckButton, MegaLabel> CountLabelRef =
        AccessTools.FieldRefAccess<NTopBarDeckButton, MegaLabel>("_countLabel");

    private static void Postfix(NTopBarDeckButton __instance)
    {
        FontScalingService.RegisterLabelFont(CountLabelRef(__instance));
    }
}

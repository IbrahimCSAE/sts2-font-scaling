using Godot;
using HarmonyLib;
using MegaCrit.Sts2.Core.Nodes.HoverTips;

namespace FontScalerMod.FontScalerModCode;

[HarmonyPatch(typeof(NHoverTipSet), "Init")]
internal static class NHoverTipSetPatches
{
    private static readonly AccessTools.FieldRef<NHoverTipSet, VFlowContainer> TextContainerRef =
        AccessTools.FieldRefAccess<NHoverTipSet, VFlowContainer>("_textHoverTipContainer");

    private static readonly AccessTools.FieldRef<NHoverTipSet, NHoverTipCardContainer> CardContainerRef =
        AccessTools.FieldRefAccess<NHoverTipSet, NHoverTipCardContainer>("_cardHoverTipContainer");

    private static void Postfix(NHoverTipSet __instance)
    {
        FontScalingService.RegisterControlTree(TextContainerRef(__instance));
        var cardContainer = CardContainerRef(__instance);
        if (cardContainer != null)
        {
            foreach (Node child in cardContainer.GetChildren())
            {
                if (child is Control control)
                {
                    FontScalingService.RegisterControlTree(control);
                }
            }
        }
    }
}

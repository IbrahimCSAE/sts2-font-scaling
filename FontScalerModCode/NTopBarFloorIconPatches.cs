using HarmonyLib;
using MegaCrit.sts2.Core.Nodes.TopBar;
using MegaCrit.Sts2.addons.mega_text;

namespace FontScalerMod.FontScalerModCode;

[HarmonyPatch(typeof(NTopBarFloorIcon), "_Ready")]
internal static class NTopBarFloorIconPatches
{
    private static readonly AccessTools.FieldRef<NTopBarFloorIcon, MegaLabel> FloorLabelRef =
        AccessTools.FieldRefAccess<NTopBarFloorIcon, MegaLabel>("_floorNumLabel");

    private static void Postfix(NTopBarFloorIcon __instance)
    {
        FontScalingService.RegisterLabelFont(FloorLabelRef(__instance));
    }
}

using HarmonyLib;
using MegaCrit.Sts2.Core.Nodes.Combat;
using MegaCrit.Sts2.Core.Nodes.Screens.CardLibrary;
using MegaCrit.Sts2.Core.Nodes.Screens.MainMenu;
using MegaCrit.Sts2.Core.Nodes.Screens.RunHistoryScreen;
using MegaCrit.Sts2.Core.Nodes.Screens.RelicCollection;
using MegaCrit.Sts2.Core.Nodes.Screens.PotionLab;
using MegaCrit.Sts2.Core.Nodes.CommonUi;

namespace FontScalerMod.FontScalerModCode;

[HarmonyPatch(typeof(NHealthBar), "_Ready")]
internal static class NHealthBarPatches
{
    private static readonly AccessTools.FieldRef<NHealthBar, MegaCrit.Sts2.addons.mega_text.MegaLabel> HpLabelRef =
        AccessTools.FieldRefAccess<NHealthBar, MegaCrit.Sts2.addons.mega_text.MegaLabel>("_hpLabel");

    private static void Postfix(NHealthBar __instance)
    {
        FontScalingService.RegisterLabelFont(HpLabelRef(__instance));
    }
}

[HarmonyPatch(typeof(NCardLibrary), "_Ready")]
internal static class CardLibrarySearchPatch
{
    private static void Postfix(NCardLibrary __instance)
    {
        FontScalingService.RegisterControlTree(__instance);
    }
}

[HarmonyPatch(typeof(NRelicCollectionCategory), "_Ready")]
internal static class RelicCollectionCategoryPatch
{
    private static void Postfix(NRelicCollectionCategory __instance)
    {
        FontScalingService.RegisterControlTree(__instance);
    }
}

[HarmonyPatch(typeof(NPotionLab), "_Ready")]
internal static class PotionLabPatch
{
    private static void Postfix(NPotionLab __instance)
    {
        FontScalingService.RegisterControlTree(__instance);
    }
}

[HarmonyPatch(typeof(NRunHistory), "_Ready")]
internal static class RunHistoryPatch
{
    private static void Postfix(NRunHistory __instance)
    {
        FontScalingService.RegisterControlTree(__instance);
    }
}

[HarmonyPatch(typeof(NPatchNotesScreen), "_Ready")]
internal static class PatchNotesPatch
{
    private static void Postfix(NPatchNotesScreen __instance)
    {
        FontScalingService.RegisterControlTree(__instance);
    }
}

[HarmonyPatch(typeof(NTopBar), "_Ready")]
internal static class TopBarPatch
{
    private static void Postfix(NTopBar __instance)
    {
        FontScalingService.RegisterControlTree(__instance);
    }
}

using HarmonyLib;
using MegaCrit.Sts2.Core.Nodes.CommonUi;
using MegaCrit.Sts2.Core.Nodes.Screens;
using MegaCrit.Sts2.Core.Nodes.Screens.CardLibrary;
using MegaCrit.Sts2.Core.Nodes.Screens.MainMenu;
using MegaCrit.Sts2.Core.Nodes.Screens.PotionLab;
using MegaCrit.Sts2.Core.Nodes.Screens.RelicCollection;
using MegaCrit.Sts2.Core.Nodes.Screens.RunHistoryScreen;
using MegaCrit.Sts2.Core.Nodes.Screens.Settings;
using MegaCrit.Sts2.Core.Nodes.Screens.StatsScreen;

namespace FontScalerMod.FontScalerModCode;

[HarmonyPatch(typeof(NCardLibrary), "_Ready")]
internal static class NCardLibraryTreePatch
{
    private static void Postfix(NCardLibrary __instance) => FontScalingService.RegisterControlTree(__instance);
}

[HarmonyPatch(typeof(NCardLibraryStats), "_Ready")]
internal static class NCardLibraryStatsTreePatch
{
    private static void Postfix(NCardLibraryStats __instance) => FontScalingService.RegisterControlTree(__instance);
}

[HarmonyPatch(typeof(NRelicCollection), "_Ready")]
internal static class NRelicCollectionTreePatch
{
    private static void Postfix(NRelicCollection __instance) => FontScalingService.RegisterControlTree(__instance);
}

[HarmonyPatch(typeof(NPotionLab), "_Ready")]
internal static class NPotionLabTreePatch
{
    private static void Postfix(NPotionLab __instance) => FontScalingService.RegisterControlTree(__instance);
}

[HarmonyPatch(typeof(NStatsScreen), "_Ready")]
internal static class NStatsScreenTreePatch
{
    private static void Postfix(NStatsScreen __instance) => FontScalingService.RegisterControlTree(__instance);
}

[HarmonyPatch(typeof(NRunHistory), "_Ready")]
internal static class NRunHistoryTreePatch
{
    private static void Postfix(NRunHistory __instance) => FontScalingService.RegisterControlTree(__instance);
}

[HarmonyPatch(typeof(NPatchNotesScreen), "_Ready")]
internal static class NPatchNotesScreenTreePatch
{
    private static void Postfix(NPatchNotesScreen __instance) => FontScalingService.RegisterControlTree(__instance);
}

[HarmonyPatch(typeof(NSettingsScreen), "_Ready")]
internal static class NSettingsScreenTreePatch
{
    private static void Postfix(NSettingsScreen __instance) => FontScalingService.RegisterControlTree(__instance);
}

[HarmonyPatch(typeof(NMainMenu), "_Ready")]
internal static class NMainMenuTreePatch
{
    private static void Postfix(NMainMenu __instance) => FontScalingService.RegisterControlTree(__instance);
}

[HarmonyPatch(typeof(NTopBar), "_Ready")]
internal static class NTopBarTreePatch
{
    private static void Postfix(NTopBar __instance) => FontScalingService.RegisterControlTree(__instance);
}

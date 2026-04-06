using HarmonyLib;
using MegaCrit.Sts2.Core.Nodes.TopBar;
using MegaCrit.Sts2.addons.mega_text;

namespace FontScalerMod.FontScalerModCode;

[HarmonyPatch(typeof(NRunTimer), "_Ready")]
internal static class NRunTimerPatches
{
    private static readonly AccessTools.FieldRef<NRunTimer, MegaLabel> TimerLabelRef =
        AccessTools.FieldRefAccess<NRunTimer, MegaLabel>("_timerLabel");

    private static void Postfix(NRunTimer __instance)
    {
        FontScalingService.RegisterLabelFont(TimerLabelRef(__instance));
    }
}

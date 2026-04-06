using HarmonyLib;
using MegaCrit.Sts2.Core.Nodes.Screens.MainMenu;
using MegaCrit.Sts2.addons.mega_text;

namespace FontScalerMod.FontScalerModCode;

[HarmonyPatch(typeof(NMainMenuTextButton), "_Ready")]
internal static class NMainMenuTextButtonPatches
{
    private static readonly AccessTools.FieldRef<NMainMenuTextButton, MegaLabel> LabelRef =
        AccessTools.FieldRefAccess<NMainMenuTextButton, MegaLabel>("label");

    private static void Postfix(NMainMenuTextButton __instance)
    {
        FontScalingService.RegisterLabelFont(LabelRef(__instance));
    }
}

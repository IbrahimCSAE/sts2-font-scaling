using Godot;
using HarmonyLib;
using MegaCrit.Sts2.addons.mega_text;

namespace FontScalerMod.FontScalerModCode;

[HarmonyPatch(typeof(MegaRichTextLabel), "SetFontSize")]
internal static class MegaRichTextLabelPatches
{
    private static void Postfix(MegaRichTextLabel __instance, int size)
    {
        foreach (StringName fontName in FontScalingService.RichTextFontNames)
        {
            FontScalingService.RegisterFont(__instance, fontName, size);
        }
    }
}

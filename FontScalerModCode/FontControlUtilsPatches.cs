using Godot;
using HarmonyLib;
using MegaCrit.Sts2.Core.Localization.Fonts;

namespace FontScalerMod.FontScalerModCode;

[HarmonyPatch(typeof(FontControlUtils), nameof(FontControlUtils.ApplyLocaleFontSubstitution))]
internal static class FontControlUtilsPatches
{
    private static void Postfix(Control control, FontType fontType, StringName themeFontName)
    {
        FontScalingService.ApplyFontScale(control, themeFontName);
    }
}

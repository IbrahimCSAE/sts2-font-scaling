using BaseLib.Config;

namespace FontScalerMod.FontScalerModCode;

internal enum FontScalingMode
{
    Percentage,
    Absolute
}

internal sealed class FontScalerConfig : SimpleModConfig
{
    [ConfigSection("Mode")]
    public static FontScalingMode Mode { get; set; } = FontScalingMode.Percentage;

    [SliderRange(1.0, 3.0, 0.05)]
    [SliderLabelFormat("{0:P0}")]
    public static double FontScale { get; set; } = 1.0;

    [SliderRange(14.0, 60.0, 1.0)]
    [SliderLabelFormat("{0:0}px")]
    public static double AbsoluteFontSize { get; set; } = 24.0;
}

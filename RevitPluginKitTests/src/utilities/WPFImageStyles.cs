namespace RevitPluginKitTests.Utilities
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;

    /// <summary>
    /// Image styles generator.
    /// </summary>
    public class WPFImageStyles
    {
        /// <summary>
        /// Gets base image style.
        /// </summary>
        public static readonly Style IconStyle = new Style(targetType: typeof(Image))
        {
            Setters =
            {
                new Setter(
                    property: Image.VerticalAlignmentProperty,
                    value: VerticalAlignment.Center),
                new Setter(
                    property: Image.HorizontalAlignmentProperty,
                    value: HorizontalAlignment.Center),
                new Setter(
                    property: RenderOptions.BitmapScalingModeProperty,
                    value: BitmapScalingMode.HighQuality),
                new Setter(
                    property: Image.HeightProperty,
                    value: 20.0),
            },
        };
    }
}

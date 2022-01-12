namespace RevitPluginKitTests.Utilities
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;

    /// <summary>
    /// Grid styles generator.
    /// </summary>
    public class WPFGridStyles
    {
        /// <summary>
        /// Gets base result row Grid style.
        /// </summary>
        public static readonly Style ResultRowGrid = new Style(targetType: typeof(Grid))
        {
            Setters =
            {
                new Setter(
                    property: FrameworkElement.HeightProperty,
                    value: 42.0),
            },
        };

        /// <summary>
        /// Gets gray result row Grid style.
        /// </summary>
        public static readonly Style ResultRowGrayGrid = new Style(
            targetType: typeof(Grid),
            basedOn: ResultRowGrid)
        {
            Setters =
            {
                new Setter(
                    property: Panel.BackgroundProperty,
                    value: Brushes.WhiteSmoke),
            },
        };
    }
}

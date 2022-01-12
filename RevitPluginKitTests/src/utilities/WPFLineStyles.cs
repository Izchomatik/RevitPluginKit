namespace RevitPluginKitTests.Utilities
{
    using System.Windows;
    using System.Windows.Data;
    using System.Windows.Media;
    using System.Windows.Shapes;

    /// <summary>
    /// Line styles generator.
    /// </summary>
    public class WPFLineStyles
    {
        /// <summary>
        /// Gets base result row Grid style.
        /// </summary>
        public static readonly Style BaseStyle = new Style(targetType: typeof(Line))
        {
            Setters =
            {
                new Setter(
                    property: Line.MarginProperty,
                    value: new Thickness(uniformLength: 10.0)),
                new Setter(
                    property: Line.StrokeThicknessProperty,
                    value: 0.5),
                new Setter(
                    property: Line.StrokeProperty,
                    value: Brushes.Black),
                new Setter(
                    property: Line.X1Property,
                    value: 0.0),
                new Setter(
                    property: Line.X2Property,
                    value: new Binding(path: "ActualWidth") { RelativeSource = RelativeSource.Self }),
            },
        };
    }
}

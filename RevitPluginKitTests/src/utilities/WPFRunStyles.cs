namespace RevitPluginKitTests.Utilities
{
    using System.Windows;
    using System.Windows.Documents;
    using System.Windows.Media;

    /// <summary>
    /// Run styles generator.
    /// </summary>
    public class WPFRunStyles
    {
        /// <summary>
        /// Gets base run style.
        /// </summary>
        public static readonly Style BaseRun = new Style(targetType: typeof(Run));

        /// <summary>
        /// Gets demiBold run style.
        /// </summary>
        public static readonly Style DemiBoldRun = new Style(
            targetType: typeof(Run),
            basedOn: BaseRun)
        {
            Setters =
            {
                new Setter(
                    property: TextElement.FontWeightProperty,
                    value: FontWeights.DemiBold),
            },
        };

        /// <summary>
        /// Gets green run style.
        /// </summary>
        public static readonly Style GreenRun = new Style(
            targetType: typeof(Run),
            basedOn: BaseRun)
        {
            Setters =
            {
                new Setter(
                    property: TextElement.ForegroundProperty,
                    value: Brushes.Green),
            },
        };

        /// <summary>
        /// Gets red run style.
        /// </summary>
        public static readonly Style RedRun = new Style(
            targetType: typeof(Run),
            basedOn: BaseRun)
        {
            Setters =
            {
                new Setter(
                    property: TextElement.ForegroundProperty,
                    value: Brushes.Red),
            },
        };
    }
}

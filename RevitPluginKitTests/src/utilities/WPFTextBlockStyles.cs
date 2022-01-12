namespace RevitPluginKitTests.Utilities
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;

    /// <summary>
    /// TextBlock styles generator.
    /// </summary>
    public class WPFTextBlockStyles
    {
        /// <summary>
        /// Gets base TextBlock style.
        /// </summary>
        public static readonly Style BaseStyle = new Style(targetType: typeof(TextBlock))
        {
            Setters =
            {
                new Setter(
                    property: FrameworkElement.MarginProperty,
                    value: new Thickness(left: 10, right: 0, top: 0, bottom: 10)),
                new Setter(
                    property: FrameworkElement.VerticalAlignmentProperty,
                    value: VerticalAlignment.Center),
                new Setter(
                    property: TextBlock.TextWrappingProperty,
                    value: TextWrapping.Wrap),
            },
        };

        /// <summary>
        /// Gets center body TextBlock style.
        /// </summary>
        public static readonly Style CenterBodyStyle = new Style(
            targetType: typeof(TextBlock),
            basedOn: BaseStyle)
        {
            Setters =
            {
                new Setter(
                    property: FrameworkElement.HorizontalAlignmentProperty,
                    value: HorizontalAlignment.Center),
                new Setter(
                    property: TextBlock.TextAlignmentProperty,
                    value: TextAlignment.Center),
            },
        };

        /// <summary>
        /// Gets table headers TextBlock style.
        /// </summary>
        public static readonly Style TableHeaderStyle = new Style(
            targetType: typeof(TextBlock),
            basedOn: CenterBodyStyle)
        {
            Setters =
            {
                new Setter(
                    property: TextBlock.FontWeightProperty,
                    value: FontWeights.DemiBold),
            },
        };

        /// <summary>
        /// Gets left body TextBlock style.
        /// </summary>
        public static readonly Style LeftBodyStyle = new Style(
            targetType: typeof(TextBlock),
            basedOn: BaseStyle)
        {
            Setters =
            {
                new Setter(
                    property: FrameworkElement.HorizontalAlignmentProperty,
                    value: HorizontalAlignment.Left),
                new Setter(
                    property: TextBlock.TextAlignmentProperty,
                    value: TextAlignment.Left),
            },
        };

        /// <summary>
        /// Gets top left body TextBlock style.
        /// </summary>
        public static readonly Style TopLeftBodyStyle = new Style(
            targetType: typeof(TextBlock),
            basedOn: LeftBodyStyle)
        {
            Setters =
            {
                new Setter(
                    property: FrameworkElement.VerticalAlignmentProperty,
                    value: VerticalAlignment.Top),
            },
        };

        /// <summary>
        /// Gets center green body TextBlock style.
        /// </summary>
        public static readonly Style CenterGreenBodyStyle = new Style(
            targetType: typeof(TextBlock),
            basedOn: CenterBodyStyle)
        {
            Setters =
            {
                new Setter(
                    property: TextBlock.ForegroundProperty,
                    value: Brushes.Green),
            },
        };

        /// <summary>
        /// Gets center red body TextBlock style.
        /// </summary>
        public static readonly Style CenterRedBodyStyle = new Style(
            targetType: typeof(TextBlock),
            basedOn: CenterBodyStyle)
        {
            Setters =
            {
                new Setter(
                    property: TextBlock.ForegroundProperty,
                    value: Brushes.Red),
            },
        };

        /// <summary>
        /// Gets right body TextBlock style.
        /// </summary>
        public static readonly Style RightBodyStyle = new Style(
            targetType: typeof(TextBlock),
            basedOn: BaseStyle)
        {
            Setters =
            {
                new Setter(
                    property: FrameworkElement.HorizontalAlignmentProperty,
                    value: HorizontalAlignment.Right),
                new Setter(
                    property: TextBlock.TextAlignmentProperty,
                    value: TextAlignment.Right),
            },
        };

        /// <summary>
        /// Gets title TextBlock style.
        /// </summary>
        public static readonly Style TitleStyle = new Style(
            targetType: typeof(TextBlock),
            basedOn: BaseStyle)
        {
            Setters =
            {
                new Setter(
                    property: TextBlock.FontWeightProperty,
                    value: FontWeights.Bold),
            },
        };
    }
}

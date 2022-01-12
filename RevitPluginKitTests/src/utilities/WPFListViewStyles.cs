namespace RevitPluginKitTests.Utilities
{
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Grid styles generator.
    /// </summary>
    public class WPFListViewStyles
    {
        /// <summary>
        /// Gets ScrollableListView style.
        /// </summary>
        public static readonly Style ScrollableListView = new Style(targetType: typeof(ListView))
        {
            Setters =
            {
                new Setter(
                    property: Control.BorderThicknessProperty,
                    value: new Thickness(0)),
                new Setter(
                    property: ScrollViewer.VerticalScrollBarVisibilityProperty,
                    value: ScrollBarVisibility.Visible),
                new Setter(
                    property: ListBox.SelectionModeProperty,
                    value: SelectionMode.Single),
            },
        };
    }
}

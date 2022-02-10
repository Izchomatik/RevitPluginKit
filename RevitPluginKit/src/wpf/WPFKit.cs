﻿namespace RevitPluginKit.Wpf
{
    using System.Text.RegularExpressions;
    using System.Windows.Controls;
    using System.Windows.Input;

    /// <summary>
    /// A set of tools designed to work with WPF elements and objects.
    /// </summary>
    public class WPFKit
    {
        /// <summary>
        /// Number validation method for wpf textBox.
        /// <para>Accepts user input and returns a boolean value indicating whether the input matches a numeric value.</para>
        /// <para>This method is designed to be used when processing data coming through the WPF (System.Windows.Input.TextCompositionEventArgs).</para>
        /// </summary>
        /// <returns>
        /// Text composition event handler that checks if the input is a number or a period.
        /// </returns>
        public static TextCompositionEventHandler ReturnNumberValidationEventHandler()
        {
            Regex regexDigits = new Regex("[^0-9]+");
            Regex regexDigitsAndPeriod = new Regex("[^0-9,]+");
            return new TextCompositionEventHandler((sender, e) => e.Handled = (e.Source as TextBox).Text.Contains(",") == true ? regexDigits.IsMatch(e.Text) : regexDigitsAndPeriod.IsMatch(e.Text));
        }

        /// <summary>
        /// ScrollViewer scroll action called when mouse wheel is used.
        /// </summary>
        /// <param name="sender">
        /// WPF sender object as ScrollViewer.
        /// </param>
        /// <param name="e">
        /// Mouse wheel scroll event arguments.
        /// </param>
        public static void MouseWheelScroll(
            object sender,
            System.Windows.Input.MouseWheelEventArgs e)
        {
            ScrollViewer scrollViewer = (ScrollViewer)sender;
            scrollViewer.ScrollToVerticalOffset(offset: scrollViewer.VerticalOffset - e.Delta);
            e.Handled = true;
        }
    }
}

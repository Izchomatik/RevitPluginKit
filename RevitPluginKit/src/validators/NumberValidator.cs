namespace RevitPluginKit.Validators
{
    using System.Text.RegularExpressions;
    using System.Windows.Input;

    /// <summary>
    /// Number validator class.
    /// <para>Designed to check incoming numeric values. Mainly used to process incoming user data.</para>
    /// </summary>
    public class NumberValidator
    {
        /// <summary>
        /// Number validation method for wpf textBox.
        /// <para>Accepts user input and returns a boolean value indicating whether the input matches a numeric value.</para>
        /// <para>This method is designed to be used when processing data coming through the WPF (System.Windows.Input.TextCompositionEventArgs).</para>
        /// </summary>
        /// <param name="sender"> WPF sender object. </param>
        /// <param name="e"> WPF text composition event. </param>
        public static void NumberValidation(
            object sender,
            TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}

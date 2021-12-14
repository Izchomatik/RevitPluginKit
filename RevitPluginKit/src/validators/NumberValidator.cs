namespace RevitPluginKit.Validators
{
    using System.Text.RegularExpressions;
    using System.Windows.Input;

    /// <summary>
    /// Number validator class.
    /// </summary>
    public class NumberValidator
    {
        /// <summary>
        /// Number validation method for wpf textBox.
        /// </summary>
        /// <param name="sender"> Sender object. </param>
        /// <param name="e"> Text composition event. </param>
        public static void NumberValidation(
            object sender,
            TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}

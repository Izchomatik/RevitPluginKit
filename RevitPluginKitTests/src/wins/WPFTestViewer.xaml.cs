namespace RevitPluginKitTests.Wins
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using RevitPluginKit.Wpf;

    /// <summary>
    /// WPF tests window.
    /// </summary>
    public partial class WPFTestViewer : Window
    {
        private string testNumber = "1";

        /// <summary>
        /// Initializes a new instance of the <see cref="WPFTestViewer"/> class.
        /// </summary>
        public WPFTestViewer()
        {
            this.InitializeComponent();

            // WPF Test TextBox initialization
            this.wpfTestTextBox.Text = this.testNumber;
            this.wpfTestTextBox.PreviewTextInput += WPFKit.ReturnNumberValidationEventHandler();
            this.wpfTestTextBox.TextChanged += new TextChangedEventHandler((sender, e) => this.testNumber = (sender as TextBox).Text);
        }

        /// <summary>
        /// Test number resulting value.
        /// </summary>
        private void CheckNumberResultClick(object sender, RoutedEventArgs e)
        {
            double numberValue = Convert.ToDouble(value: this.testNumber);
            MinorResultsViewer viewer = new MinorResultsViewer(
                title: "Number validator test.",
                results: $"Test TextBox field value: {numberValue};");
            viewer.ShowDialog();
        }
    }
}

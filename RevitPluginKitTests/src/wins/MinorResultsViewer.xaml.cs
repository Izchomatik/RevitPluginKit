namespace RevitPluginKitTests.Wins
{
    using System.Windows;

    /// <summary>
    /// Minor results report window.
    /// </summary>
    public partial class MinorResultsViewer : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MinorResultsViewer"/> class.
        /// </summary>
        /// <param name="title">
        /// Minor report title.
        /// </param>
        /// <param name="results">
        /// Minor report text.
        /// </param>
        public MinorResultsViewer(
            string title,
            string results)
        {
            this.InitializeComponent();
            this.wpfTitleBlock.Text = title;
            this.wpfResultsBlock.Text = results;
        }
    }
}

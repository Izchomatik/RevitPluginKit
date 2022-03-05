namespace RevitPluginKitTests.Src
{
    using Autodesk.Revit.Attributes;
    using Autodesk.Revit.DB;
    using Autodesk.Revit.UI;
    using RevitPluginKitTests.Wins;

    /// <summary>
    /// Test utility tools using: RevitPluginKit.Wpf.
    /// </summary>
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    internal class WPFTest : IExternalCommand
    {
        /// <inheritdoc/>
        public Result Execute(
            ExternalCommandData commandData,
            ref string message,
            ElementSet elements)
        {
            WPFTestViewer viewer = new WPFTestViewer();
            viewer.ShowDialog();
            return Result.Succeeded;
        }
    }
}

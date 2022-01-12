namespace RevitPluginKitTests.Src
{
    using System.Collections.Generic;
    using Autodesk.Revit.Attributes;
    using Autodesk.Revit.DB;
    using Autodesk.Revit.UI;
    using RevitPluginKitTests.Utilities;
    using RevitPluginKitTests.Wins;

    /// <summary>
    /// Runs all RevitPluginKit tests.
    /// </summary>
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    internal class GeneralTest : IExternalCommand
    {
        /// <inheritdoc/>
        public Result Execute(
            ExternalCommandData commandData,
            ref string message,
            ElementSet elements)
        {
            UIApplication uiApp = commandData.Application;
            Document document = uiApp.ActiveUIDocument.Document;
            List<TestResultData> generalTestsResults = new List<TestResultData>();
            generalTestsResults.AddRange(collection: CollectorsTest.AddCollectorsTest(document: document));
            generalTestsResults.AddRange(collection: ConvertersTest.AddConvertersTest());
            ResultsViewer viewer = new ResultsViewer(
                title: "General test",
                description: "Runs all RevitPluginKit tests.",
                testsResults: generalTestsResults);
            viewer.ShowDialog();
            return Result.Succeeded;
        }
    }
}

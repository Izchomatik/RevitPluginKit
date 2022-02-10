namespace RevitPluginKitTests
{
    using System.Collections.Generic;
    using Autodesk.Revit.UI;
    using RevitPluginKit.Ui;
    using static RevitPluginKit.Ui.RibbonKit;

    /// <summary>
    /// Main test plug-in entry point.
    /// </summary>
    public class TestsPluginMain : IExternalApplication
    {
        /// <inheritdoc/>
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        /// <inheritdoc/>
        public Result OnStartup(UIControlledApplication application)
        {
            AddRibbonTab(
                application: application,
                tabName: "RPK Tests",
                panelsSettings: new List<RibbonPanelSettings>()
                {
                    new RibbonPanelSettings(
                        name: "Major tests",
                        buttonsSettings: new List<ButtonSettings>()
                        {
                            new PushButtonSettings(
                                internalName: "generalTest",
                                name: "General\ntest",
                                tooltip: "Runs all RevitPluginKit tests.",
                                imageAddress: "RevitPluginKitTests.assets.icons.GeneralTestIcon.png",
                                className: "RevitPluginKitTests.Src.GeneralTest"),
                        }),
                    new RibbonPanelSettings(
                        name: "Minor tests",
                        buttonsSettings: new List<ButtonSettings>()
                        {
                            new PushButtonSettings(
                                internalName: "collectorsTest",
                                name: "Collectors\ntest",
                                tooltip: "Runs multiple checks related to collecting items in the model using RevitPluginKit",
                                imageAddress: "RevitPluginKitTests.assets.icons.CollectorsTestIcon.png",
                                className: "RevitPluginKitTests.Src.CollectorsTest"),
                            new PushButtonSettings(
                                internalName: "utilitiesTest",
                                name: "Utility\ntools test",
                                tooltip: "Runs multiple checks related to utility tools using RevitPluginKit",
                                imageAddress: "RevitPluginKitTests.assets.icons.UtilitiesTestIcon.png",
                                className: "RevitPluginKitTests.Src.UtilitiesTest"),
                        }),
                    new RibbonPanelSettings(
                        name: "Manual tests",
                        buttonsSettings: new List<ButtonSettings>()
                        {
                            new PushButtonSettings(
                                internalName: "wpfTest",
                                name: "WPF tools\ntest",
                                tooltip: "A set of manual tests designed to check the RevitPluginKit.Wpf tools.",
                                imageAddress: "1",
                                className: "RevitPluginKitTests.Src.WPFTest"),
                        }),
                });
            return Result.Succeeded;
        }
    }
}

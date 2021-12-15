# Quick start guide

## Add Revit plug-in ribbon tab

* Find the starter class where the base interface 'IExternalApplication' for your plugin is defined.

* In 'OnStartup' method implemented by 'IExternalApplication' add 'AddRibbonTab' method, defined in 'RevitPluginKit.Ui.RibbonKit'.

	    When your plugin is initialized during the start of the Revit session, this method will add a ribbon tab to the Revit upper working panel.

* Code snippet:

	'
    namespace RevitPluginKitTemplate
    {
        using System.Collections.Generic;
        using Autodesk.Revit.UI;
        using RevitPluginKit.Ui;
        using static RevitPluginKit.Ui.RibbonKit;

        /// <summary>
        /// Main plug-in entry point.
        /// </summary>
        public class PluginMain : IExternalApplication
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
                    tabName: "Plug-in tab",
                    panelsSettings: new List<RibbonPanelSettings>());
                return Result.Succeeded;
            }
        }
    }
    '

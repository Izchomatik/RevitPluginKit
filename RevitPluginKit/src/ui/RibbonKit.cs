namespace RevitPluginKit.Ui
{
    using System.Collections.Generic;
    using System.Reflection;
    using System.Windows.Media.Imaging;
    using Autodesk.Revit.UI;
    using static RevitPluginKit.Ui.ImageKit;

    /// <summary>
    /// Services for working with Revit plug-in ribbon tabs.
    /// </summary>
    public class RibbonKit
    {
        /// <summary>
        /// Adds a revit plug-in ribbon tab.
        /// </summary>
        /// <param name="application"> Current revit application instance. </param>
        /// <param name="tabName"> New revit plug-in tab name. </param>
        /// <param name="panelsSettings"> List of RibbonPanelData class instances required to generate ribbon panels and its buttons. </param>
        public static void AddRibbonTab(
            UIControlledApplication application,
            string tabName,
            List<RibbonPanelSettings> panelsSettings)
        {
            application.CreateRibbonTab(tabName);
            if (panelsSettings.Count > 0)
            {
                foreach (var panelSettings in panelsSettings)
                {
                    RibbonPanel ribbonPanel = application.CreateRibbonPanel(
                        tabName: tabName,
                        panelName: panelSettings.Name);
                    if (panelSettings.ButtonsSettings.Count > 0)
                    {
                        Assembly assembly = Assembly.GetExecutingAssembly();
                        string assemblyLocation = assembly.Location;
                        foreach (var buttonSettings in panelSettings.ButtonsSettings)
                        {
                            if (buttonSettings is PushButtonSettings)
                            {
                                PushButtonSettings pushButtonSettings = buttonSettings as PushButtonSettings;
                                PushButtonData buttonData = new PushButtonData(
                                    name: pushButtonSettings.InternalName,
                                    text: pushButtonSettings.Name,
                                    assemblyName: assemblyLocation,
                                    className: pushButtonSettings.Function);
                                PushButton button = ribbonPanel.AddItem(buttonData) as PushButton;
                                button.ToolTip = pushButtonSettings.Tooltip;
                                BitmapSource image = GetEmbeddedImage(
                                    assembly: assembly,
                                    address: pushButtonSettings.ImageAddress);
                                button.LargeImage = image;
                            }
                            else if (buttonSettings is PullDownButtonSettings)
                            {
                                PullDownButtonSettings pullDownButtonSettings = buttonSettings as PullDownButtonSettings;
                                PulldownButtonData parentButtonData = new PulldownButtonData(
                                    name: pullDownButtonSettings.InternalName,
                                    text: pullDownButtonSettings.Name);
                                PulldownButton parentButton = ribbonPanel.AddItem(parentButtonData) as PulldownButton;
                                parentButton.ToolTip = pullDownButtonSettings.Tooltip;
                                BitmapSource image = GetEmbeddedImage(
                                    assembly: assembly,
                                    address: pullDownButtonSettings.ImageAddress);
                                parentButton.LargeImage = image;
                                if (pullDownButtonSettings.PushButtonsSettings.Count > 0)
                                {
                                    foreach (var childButtonSettings in pullDownButtonSettings.PushButtonsSettings)
                                    {
                                        PushButtonData childButtonData = new PushButtonData(
                                            name: childButtonSettings.InternalName,
                                            text: childButtonSettings.Name,
                                            assemblyName: assemblyLocation,
                                            className: childButtonSettings.Function);
                                        PushButton childButton = parentButton.AddPushButton(childButtonData) as PushButton;
                                        childButton.ToolTip = childButtonSettings.Tooltip;
                                        BitmapSource childImage = GetEmbeddedImage(
                                            assembly: assembly,
                                            address: childButtonSettings.ImageAddress);
                                        childButton.LargeImage = childImage;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}

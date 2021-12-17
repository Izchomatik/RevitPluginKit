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
                        Assembly assembly = Assembly.GetCallingAssembly();
                        foreach (var buttonSettings in panelSettings.ButtonsSettings)
                        {
                            if (buttonSettings is PushButtonSettings)
                            {
                                AddPushButton(
                                    assembly: assembly,
                                    ribbonPanel: ribbonPanel,
                                    pushButtonSettings: buttonSettings as PushButtonSettings);
                            }
                            else if (buttonSettings is PullDownButtonSettings)
                            {
                                PullDownButtonSettings pullDownButtonSettings = buttonSettings as PullDownButtonSettings;
                                PulldownButton parentButton = AddPullDownButton(
                                    assembly: assembly,
                                    ribbonPanel: ribbonPanel,
                                    pullDownButtonSettings: buttonSettings as PullDownButtonSettings);
                                if (pullDownButtonSettings.PushButtonsSettings.Count > 0)
                                {
                                    foreach (var childButtonSettings in pullDownButtonSettings.PushButtonsSettings)
                                    {
                                        AddChildPushButton(
                                            assembly: assembly,
                                            parentButton: parentButton,
                                            childButtonSettings: childButtonSettings);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Adds push button to ribbon panel.
        /// </summary>
        private static void AddPushButton(
            Assembly assembly,
            RibbonPanel ribbonPanel,
            PushButtonSettings pushButtonSettings)
        {
            PushButtonData buttonData = new PushButtonData(
                name: pushButtonSettings.InternalName,
                text: pushButtonSettings.Name,
                assemblyName: assembly.Location,
                className: pushButtonSettings.ClassName);
            PushButton button = ribbonPanel.AddItem(buttonData) as PushButton;
            AssignButtonData(
                assembly: assembly,
                button: button,
                buttonSettings: pushButtonSettings);
        }

        /// <summary>
        /// Adds pull down button to ribbon panel.
        /// </summary>
        private static PulldownButton AddPullDownButton(
            Assembly assembly,
            RibbonPanel ribbonPanel,
            PullDownButtonSettings pullDownButtonSettings)
        {
            PulldownButtonData buttonData = new PulldownButtonData(
                name: pullDownButtonSettings.InternalName,
                text: pullDownButtonSettings.Name);
            PulldownButton button = ribbonPanel.AddItem(buttonData) as PulldownButton;
            AssignButtonData(
                assembly: assembly,
                button: button,
                buttonSettings: pullDownButtonSettings);
            return button;
        }

        /// <summary>
        /// Adds push button to parent pull down button.
        /// </summary>
        private static void AddChildPushButton(
            Assembly assembly,
            PulldownButton parentButton,
            PushButtonSettings childButtonSettings)
        {
            PushButtonData buttonData = new PushButtonData(
                name: childButtonSettings.InternalName,
                text: childButtonSettings.Name,
                assemblyName: assembly.Location,
                className: childButtonSettings.ClassName);
            PushButton button = parentButton.AddPushButton(buttonData) as PushButton;
            AssignButtonData(
                assembly: assembly,
                button: button,
                buttonSettings: childButtonSettings);
        }

        /// <summary>
        /// Assign secondary button data.
        /// </summary>
        private static void AssignButtonData(
            Assembly assembly,
            RibbonButton button,
            ButtonSettings buttonSettings)
        {
            BitmapSource icon = GetEmbeddedImage(
                assembly: assembly,
                address: buttonSettings.ImageAddress);
            button.ToolTip = buttonSettings.Tooltip;
            button.LargeImage = icon;
        }
    }
}

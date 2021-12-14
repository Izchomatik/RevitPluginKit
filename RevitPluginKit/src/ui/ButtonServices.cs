namespace RevitPluginKit.Ui
{
    using System.Windows.Media.Imaging;
    using Autodesk.Revit.UI;
    using static RevitPluginKit.Ui.ImageServices;

    /// <summary>
    /// Services for working with Revit plug-in buttons.
    /// </summary>
    internal class ButtonServices
    {
        /// <summary>
        /// Add pull down button to required ribbon panel.
        /// </summary>
        /// <param name="buttonSettings"> PullDownButtonSettings required. </param>
        /// <param name="ribbonPanel"> Button ribbon panel data. </param>
        /// <returns>
        /// Return PulldownButton instance.
        /// </returns>
        public static PulldownButton AddPullDownButton(
            ButtonSettings buttonSettings,
            RibbonPanel ribbonPanel)
        {
            // Create button
            PulldownButtonData newButtonData = new PulldownButtonData(
                name: buttonSettings.InternalName,
                text: buttonSettings.Name);
            PulldownButton newButton = ribbonPanel.AddItem(newButtonData) as PulldownButton;

            // Assign button data
            newButton.ToolTip = buttonSettings.Tooltip;
            BitmapSource image = GetEmbeddedImage(
                assembly: buttonSettings.Assembly,
                address: buttonSettings.ImageAddress);
            newButton.LargeImage = image;

            // Return button
            return newButton;
        }

        /// <summary>
        /// Add push button to required ribbon panel.
        /// </summary>
        /// <param name="pushButtonSettings"> PushButtonSettings required. </param>
        /// <param name="ribbonPanel"> Button ribbon panel data. </param>
        public static void AddPushButton(
            ButtonSettings pushButtonSettings,
            RibbonPanel ribbonPanel)
        {
            // Create button
            string assemblyPath = pushButtonSettings.Assembly.Location;
            PushButtonData newButtonData = new PushButtonData(
                name: pushButtonSettings.InternalName,
                text: pushButtonSettings.Name,
                assemblyName: assemblyPath,
                className: pushButtonSettings.Function);
            PushButton newButton;
            newButton = ribbonPanel.AddItem(newButtonData) as PushButton;

            // Assign button data
            newButton.ToolTip = pushButtonSettings.Tooltip;
            BitmapSource image = GetEmbeddedImage(
                assembly: pushButtonSettings.Assembly,
                pushButtonSettings.ImageAddress);
            newButton.LargeImage = image;
        }

        /// <summary>
        /// Add child push button to required pull down button.
        /// </summary>
        /// <param name="buttonSettings"> ChildPushButtonSettings required. </param>
        /// <param name="pulldownButton"> Pull down button to add to. </param>
        public static void AddChildPushButton(
            ButtonSettings buttonSettings,
            PulldownButton pulldownButton)
        {
            // Create button
            string assemblyPath = buttonSettings.Assembly.Location;
            PushButtonData newButtonData = new PushButtonData(
                name: buttonSettings.InternalName,
                text: buttonSettings.Name,
                assemblyName: assemblyPath,
                className: buttonSettings.Function);
            PushButton newButton;
            newButton = pulldownButton.AddPushButton(newButtonData) as PushButton;

            // Assign button data
            newButton.ToolTip = buttonSettings.Tooltip;
            BitmapSource image = GetEmbeddedImage(
                assembly: buttonSettings.Assembly,
                buttonSettings.ImageAddress);
            newButton.LargeImage = image;
        }
    }
}

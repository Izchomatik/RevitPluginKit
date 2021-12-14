namespace RevitPluginKit.Ui
{
    using System.Reflection;
    using System.Windows.Media.Imaging;
    using Autodesk.Revit.UI;
    using static RevitPluginKit.Ui.ImageServices;

    /// <summary>
    /// Services for working with Revit plug-in buttons.
    /// </summary>
    public class ButtonServices
    {
        /// <summary>
        /// Add pull down button to required ribbon panel.
        /// </summary>
        /// <param name="internalName"> Internal button name data. </param>
        /// <param name="name"> Button name data. </param>
        /// <param name="tooltip"> Button tooltip data. </param>
        /// <param name="imageAddress"> Button image storage address. </param>
        /// <param name="assembly"> Current assembly data. </param>
        /// <param name="ribbonPanel"> Button ribbon panel data. </param>
        /// <returns>
        /// Return PulldownButton instance.
        /// </returns>
        public static PulldownButton AddPullDownButton(
            string internalName,
            string name,
            string tooltip,
            string imageAddress,
            Assembly assembly,
            RibbonPanel ribbonPanel)
        {
            // Create button
            PulldownButtonData newButtonData = new PulldownButtonData(
                name: internalName,
                text: name);
            PulldownButton newButton = ribbonPanel.AddItem(newButtonData) as PulldownButton;

            // Assign button data
            newButton.ToolTip = tooltip;
            BitmapSource image = GetEmbeddedImage(
                assembly: assembly,
                address: imageAddress);
            newButton.LargeImage = image;

            // Return button
            return newButton;
        }

        /// <summary>
        /// Add push button to required ribbon panel.
        /// </summary>
        /// <param name="internalName"> Internal button name data. </param>
        /// <param name="name"> Button name data. </param>
        /// <param name="tooltip"> Button tooltip data. </param>
        /// <param name="imageAddress"> Button image storage address. </param>
        /// <param name="assembly"> Current assembly data. </param>
        /// <param name="function"> Main button function to call. </param>
        /// <param name="ribbonPanel"> Button ribbon panel data. </param>
        public static void AddPushButton(
            string internalName,
            string name,
            string tooltip,
            string imageAddress,
            Assembly assembly,
            string function,
            RibbonPanel ribbonPanel)
        {
            // Create button
            string assemblyPath = assembly.Location;
            PushButtonData newButtonData = new PushButtonData(
                name: internalName,
                text: name,
                assemblyName: assemblyPath,
                className: function);
            PushButton newButton;
            newButton = ribbonPanel.AddItem(newButtonData) as PushButton;

            // Assign button data
            newButton.ToolTip = tooltip;
            BitmapSource image = GetEmbeddedImage(
                assembly: assembly,
                address: imageAddress);
            newButton.LargeImage = image;
        }

        /// <summary>
        /// Add child push button to required pull down button.
        /// </summary>
        /// <param name="internalName"> Internal button name data. </param>
        /// <param name="name"> Button name data. </param>
        /// <param name="tooltip"> Button tooltip data. </param>
        /// <param name="imageAddress"> Button image storage address. </param>
        /// <param name="assembly"> Current assembly data. </param>
        /// <param name="function"> Main button function to call. </param>
        /// <param name="pulldownButton"> Pull down button to add to. </param>
        public static void AddChildPushButton(
            string internalName,
            string name,
            string tooltip,
            string imageAddress,
            Assembly assembly,
            string function,
            PulldownButton pulldownButton)
        {
            // Create button
            string assemblyPath = assembly.Location;
            PushButtonData newButtonData = new PushButtonData(
                name: internalName,
                text: name,
                assemblyName: assemblyPath,
                className: function);
            PushButton newButton;
            newButton = pulldownButton.AddPushButton(newButtonData) as PushButton;

            // Assign button data
            newButton.ToolTip = tooltip;
            BitmapSource image = GetEmbeddedImage(
                assembly: assembly,
                address: imageAddress);
            newButton.LargeImage = image;
        }
    }
}

namespace RevitPluginKit.Ui
{
    /// <summary>
    /// A class for storing data needed to generate a push button instance.
    /// <para>Please note that the push button can only be added to the Revit panel or other pull down button
    /// (as part of the RevitPluginKit.Ui.RibbonPanelSettings or RevitPluginKit.Ui.PullDownButtonSettings data).</para>
    /// </summary>
    public class PushButtonSettings : ButtonSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PushButtonSettings"/> class.
        /// </summary>
        /// <param name="internalName">
        /// Internal button name data.
        /// </param>
        /// <param name="name">
        /// Button name data (visible to the user).
        /// </param>
        /// <param name="tooltip">
        /// Button tooltip data.
        /// </param>
        /// <param name="imageAddress">
        /// Button image storage address.
        /// </param>
        /// <param name="className">
        /// The name of the class to call when the button is clicked.
        /// </param>
        /// <param name="isActive">
        /// Value indicating whether to render this UI push button element or not.
        /// <para>In the general case, it is used to quickly turn off the display of a particular UI element.</para>
        /// </param>
        public PushButtonSettings(
            string internalName,
            string name,
            string tooltip,
            string imageAddress,
            string className,
            bool isActive = true)
            : base(
                internalName: internalName,
                name: name,
                tooltip: tooltip,
                imageAddress: imageAddress,
                isActive: isActive)
        {
            this.ClassName = className;
        }

        /// <summary>
        /// Gets main button function to call.
        /// </summary>
        /// <value>
        /// String representing the name - corresponding to the full path to the class in which the IExternalCommand interface is implemented.
        /// Also - this class is the direct execution function that must be called when the user clicks on this button (as intended by the creator of the custom plugin).
        /// </value>
        public string ClassName { get; }
    }
}

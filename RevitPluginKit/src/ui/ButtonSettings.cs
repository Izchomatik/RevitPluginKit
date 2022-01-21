namespace RevitPluginKit.Ui
{
    /// <summary>
    /// A class for storing data needed to generate a button instance.
    /// Base class for PushButtonSettings and PullDownButtonSettings.
    /// <para>This class contains the general minimum required information needed to generate an instance of a button inside a panel placed in a custom Revit tab.</para>
    /// </summary>
    public class ButtonSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ButtonSettings"/> class.
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
        /// <param name="isActive">
        /// Value indicating whether to render this UI button element or not.
        /// <para>In the general case, it is used to quickly turn off the display of a particular UI element.</para>
        /// </param>
        internal ButtonSettings(
            string internalName,
            string name,
            string tooltip,
            string imageAddress,
            bool isActive = true)
        {
            this.InternalName = internalName;
            this.Name = name;
            this.Tooltip = tooltip;
            this.ImageAddress = imageAddress;
            this.IsActive = isActive;
        }

        /// <summary>
        /// Gets internal button name data.
        /// </summary>
        /// <value>
        /// String representing the value for the function's internal naming.
        /// </value>
        public string InternalName { get; }

        /// <summary>
        /// Gets public button name data (visible to the user).
        /// </summary>
        /// <value>
        /// String representing a value indicating the name of the button - visible to the user (only used as part of your plugin's UI).
        /// </value>
        public string Name { get; }

        /// <summary>
        /// Gets public button tooltip data.
        /// </summary>
        /// <value>
        /// String representing the data corresponding to the explanation text that pops up when you hover the mouse over this element of the UI.
        /// </value>
        public string Tooltip { get; }

        /// <summary>
        /// Gets button image storage address.
        /// </summary>
        /// <value>
        /// String representing the location of the image to be used as an icon inside your project/solution.
        /// </value>
        public string ImageAddress { get; }

        /// <summary>
        /// Gets a value indicating whether to render this UI element or not.
        /// <para>In the general case, it is used to quickly turn off the display of a particular UI element.</para>
        /// </summary>
        /// <value>
        /// Specifies whether to generate the UI for this element.
        /// <para>Predefined value "true" - causes the UI element to be rendered.
        /// The value "false" is perceived as a temporary need to cancel the rendering of this UI element.</para>
        /// </value>
        public bool IsActive { get; }
    }
}

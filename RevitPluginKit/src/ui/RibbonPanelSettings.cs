namespace RevitPluginKit.Ui
{
    using System.Collections.Generic;

    /// <summary>
    /// A class for storing data needed to generate a ribbon panel.
    /// <para>A panel in Revit terms is a highlighted area within a tab.
    /// This UI area has a name.
    /// Adding any form of buttons is possible only to the panel.</para>
    /// </summary>
    public class RibbonPanelSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RibbonPanelSettings"/> class.
        /// Contains basic information needed to generate the ribbon panel.
        /// Includes information about the buttons that the ribbon panel should contain.
        /// </summary>
        /// <param name="name">
        /// Ribbon panel name (part of UI - visible to the user).
        /// </param>
        /// <param name="buttonsSettings">
        /// List of ButtonSettings class instances required to generate ribbon panel buttons.
        /// </param>
        /// <param name="isActive">
        /// Value indicating whether to render this UI panel element or not.
        /// <para>In the general case, it is used to quickly turn off the display of a particular UI element.</para>
        /// </param>
        public RibbonPanelSettings(
            string name,
            List<ButtonSettings> buttonsSettings,
            bool isActive = true)
        {
            this.Name = name;
            this.ButtonsSettings = buttonsSettings;
            this.IsActive = isActive;
        }

        /// <summary>
        /// Gets panel name data (part of UI - visible to the user).
        /// </summary>
        /// <value>
        /// String representing a value indicating the name of the panel - visible to the user (only used as part of your plugin's UI).
        /// </value>
        public string Name { get; }

        /// <summary>
        /// Gets list of ButtonSettings class instances required to generate ribbon panel buttons.
        /// </summary>
        /// <value>
        /// List of data elements - on the basis of which the set of buttons (included in this panel) will be rendered.
        /// </value>
        public List<ButtonSettings> ButtonsSettings { get; }

        /// <summary>
        /// Gets a value indicating whether to render this UI panel element or not.
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

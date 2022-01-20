namespace RevitPluginKit.Ui
{
    using System.Collections.Generic;

    /// <summary>
    /// A class for storing data needed to generate a ribbon panel.
    /// <para>A panel in Revit terms is a highlighted area within a tab.
    /// This area has a name.
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
        public RibbonPanelSettings(
            string name,
            List<ButtonSettings> buttonsSettings)
        {
            this.Name = name;
            this.ButtonsSettings = buttonsSettings;
        }

        /// <summary>
        /// Gets panel name data (part of UI - visible to the user).
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets list of ButtonSettings class instances required to generate ribbon panel buttons.
        /// </summary>
        public List<ButtonSettings> ButtonsSettings { get; }
    }
}

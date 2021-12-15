namespace RevitPluginKit.Ui
{
    using System.Collections.Generic;
    using Autodesk.Revit.UI;

    /// <summary>
    /// A class for storing data needed to generate a pull down button instance.
    /// </summary>
    public class PullDownButtonSettings : ButtonSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PullDownButtonSettings"/> class.
        /// </summary>
        /// <param name="internalName"> Internal button name data. </param>
        /// <param name="name"> Button name data. </param>
        /// <param name="tooltip"> Button tooltip data. </param>
        /// <param name="imageAddress"> Button image storage address. </param>
        /// <param name="ribbonPanel"> Button ribbon panel data. </param>
        /// <param name="childPushButtonsSettings"> A list of child push button instances for the current parent pull down button. </param>
        public PullDownButtonSettings(
            string internalName,
            string name,
            string tooltip,
            string imageAddress,
            RibbonPanel ribbonPanel,
            List<ChildPushButtonSettings> childPushButtonsSettings)
            : base(
                internalName: internalName,
                name: name,
                tooltip: tooltip,
                imageAddress: imageAddress)
        {
            this.RibbonPanel = ribbonPanel;
            this.ChildPushButtonsSettings = childPushButtonsSettings;
        }

        /// <summary>
        /// Gets button ribbon panel data.
        /// </summary>
        public RibbonPanel RibbonPanel { get; }

        /// <summary>
        /// Gets a list of child push button instances for the current parent pull down button.
        /// </summary>
        public List<ChildPushButtonSettings> ChildPushButtonsSettings { get; }
    }
}

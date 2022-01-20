﻿namespace RevitPluginKit.Ui
{
    using System.Collections.Generic;

    /// <summary>
    /// A class for storing data needed to generate a pull down button instance.
    /// <para>Please note that the pull down button can only be added to the Revit panel
    /// (as part of the RevitPluginKit.Ui.RibbonPanelSettings data).</para>
    /// </summary>
    public class PullDownButtonSettings : ButtonSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PullDownButtonSettings"/> class.
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
        /// <param name="pushButtonsSettings">
        /// A list of child push button instances for the current parent pull down button.
        /// </param>
        public PullDownButtonSettings(
            string internalName,
            string name,
            string tooltip,
            string imageAddress,
            List<PushButtonSettings> pushButtonsSettings)
            : base(
                internalName: internalName,
                name: name,
                tooltip: tooltip,
                imageAddress: imageAddress)
        {
            this.PushButtonsSettings = pushButtonsSettings;
        }

        /// <summary>
        /// Gets a list of child push button instances for the current parent pull down button.
        /// </summary>
        public List<PushButtonSettings> PushButtonsSettings { get; }
    }
}

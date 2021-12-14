﻿namespace RevitPluginKit.Ui
{
    using System.Reflection;
    using Autodesk.Revit.UI;

    /// <summary>
    /// A class for storing data needed to generate a button instance.
    /// </summary>
    public class ButtonSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ButtonSettings"/> class.
        /// </summary>
        /// <param name="internalName"> Internal button name data. </param>
        /// <param name="name"> Button name data. </param>
        /// <param name="tooltip"> Button tooltip data. </param>
        /// <param name="imageAddress"> Button image storage address. </param>
        /// <param name="assembly"> Current assembly data. </param>
        /// <param name="function"> Main button function to call. </param>
        private ButtonSettings(
            string internalName,
            string name,
            string tooltip,
            string imageAddress,
            Assembly assembly,
            string function = null)
        {
            this.InternalName = internalName;
            this.Name = name;
            this.Tooltip = tooltip;
            this.ImageAddress = imageAddress;
            this.Function = function;
            this.Assembly = assembly;
        }

        /// <summary>
        /// Gets internal button name data.
        /// </summary>
        public string InternalName { get; }

        /// <summary>
        /// Gets public button name data.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets public button tooltip data.
        /// </summary>
        public string Tooltip { get; }

        /// <summary>
        /// Gets button image storage address.
        /// </summary>
        public string ImageAddress { get; }

        /// <summary>
        /// Gets main button function to call.
        /// </summary>
        public string Function { get; }

        /// <summary>
        /// Gets current assembly data.
        /// </summary>
        public Assembly Assembly { get; }

        /// <summary>
        /// Named constructor idiom - pull down button constructor method.
        /// </summary>
        /// <param name="internalName"> Internal button name data. </param>
        /// <param name="name"> Button name data. </param>
        /// <param name="tooltip"> Button tooltip data. </param>
        /// <param name="imageAddress"> Button image storage address. </param>
        /// <param name="assembly"> Current assembly data. </param>
        /// <returns>
        /// Return ButtonSettings instance.
        /// </returns>
        public static ButtonSettings PullDownButtonSettings(
            string internalName,
            string name,
            string tooltip,
            string imageAddress,
            Assembly assembly)
        {
            return new ButtonSettings(
                internalName: internalName,
                name: name,
                tooltip: tooltip,
                imageAddress: imageAddress,
                assembly: assembly);
        }

        /// <summary>
        /// Named constructor idiom - push button constructor method.
        /// </summary>
        /// <param name="internalName"> Internal button name data. </param>
        /// <param name="name"> Button name data. </param>
        /// <param name="tooltip"> Button tooltip data. </param>
        /// <param name="imageAddress"> Button image storage address. </param>
        /// <param name="assembly"> Current assembly data. </param>
        /// <param name="function"> Main button function to call. </param>
        /// <returns>
        /// Return ButtonSettings instance.
        /// </returns>
        public static ButtonSettings PushButtonSettings(
            string internalName,
            string name,
            string tooltip,
            string imageAddress,
            Assembly assembly,
            string function)
        {
            return new ButtonSettings(
                internalName: internalName,
                name: name,
                tooltip: tooltip,
                imageAddress: imageAddress,
                assembly: assembly,
                function: function);
        }
    }
}

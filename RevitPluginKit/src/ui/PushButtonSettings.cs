namespace RevitPluginKit.Ui
{
    using Autodesk.Revit.UI;

    /// <summary>
    /// A class for storing data needed to generate a push button instance.
    /// </summary>
    public class PushButtonSettings : ButtonSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PushButtonSettings"/> class.
        /// </summary>
        /// <param name="internalName"> Internal button name data. </param>
        /// <param name="name"> Button name data. </param>
        /// <param name="tooltip"> Button tooltip data. </param>
        /// <param name="imageAddress"> Button image storage address. </param>
        /// <param name="function"> Main button function to call. </param>
        /// <param name="ribbonPanel"> Button ribbon panel data. </param>
        public PushButtonSettings(
            string internalName,
            string name,
            string tooltip,
            string imageAddress,
            string function,
            RibbonPanel ribbonPanel)
            : base(
                internalName: internalName,
                name: name,
                tooltip: tooltip,
                imageAddress: imageAddress)
        {
            this.Function = function;
            this.RibbonPanel = ribbonPanel;
        }

        /// <summary>
        /// Gets main button function to call.
        /// </summary>
        public string Function { get; }

        /// <summary>
        /// Gets button ribbon panel data.
        /// </summary>
        public RibbonPanel RibbonPanel { get; }
    }
}

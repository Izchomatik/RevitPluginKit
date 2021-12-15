namespace RevitPluginKit.Ui
{
    /// <summary>
    /// A class for storing data needed to generate a push button instance stored inside parent pull down button.
    /// </summary>
    public class ChildPushButtonSettings : ButtonSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChildPushButtonSettings"/> class.
        /// </summary>
        /// <param name="internalName"> Internal button name data. </param>
        /// <param name="name"> Button name data. </param>
        /// <param name="tooltip"> Button tooltip data. </param>
        /// <param name="imageAddress"> Button image storage address. </param>
        /// <param name="function"> Main button function to call. </param>
        public ChildPushButtonSettings(
            string internalName,
            string name,
            string tooltip,
            string imageAddress,
            string function)
            : base(
                internalName: internalName,
                name: name,
                tooltip: tooltip,
                imageAddress: imageAddress)
        {
            this.Function = function;
        }

        /// <summary>
        /// Gets main button function to call.
        /// </summary>
        public string Function { get; }
    }
}

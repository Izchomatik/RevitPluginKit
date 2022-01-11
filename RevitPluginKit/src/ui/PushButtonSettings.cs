namespace RevitPluginKit.Ui
{
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
        /// <param name="className"> The name of the class to call when the button is clicked. </param>
        public PushButtonSettings(
            string internalName,
            string name,
            string tooltip,
            string imageAddress,
            string className)
            : base(
                internalName: internalName,
                name: name,
                tooltip: tooltip,
                imageAddress: imageAddress)
        {
            this.ClassName = className;
        }

        /// <summary>
        /// Gets main button function to call.
        /// </summary>
        public string ClassName { get; }
    }
}

namespace RevitPluginKit.Ui
{
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
        internal ButtonSettings(
            string internalName,
            string name,
            string tooltip,
            string imageAddress)
        {
            this.InternalName = internalName;
            this.Name = name;
            this.Tooltip = tooltip;
            this.ImageAddress = imageAddress;
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
    }
}

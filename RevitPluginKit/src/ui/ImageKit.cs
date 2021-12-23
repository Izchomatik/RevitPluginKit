namespace RevitPluginKit.Ui
{
    using System.IO;
    using System.Reflection;
    using System.Windows.Media.Imaging;

    /// <summary>
    /// Services for working with images.
    /// </summary>
    public class ImageKit
    {
        /// <summary>
        /// Image extractor. Read specific embed image using address string.
        /// </summary>
        /// <param name="address"> The address in the solution where the image is located. </param>
        /// <param name="assembly"> Current assembly. </param>
        /// <returns>
        /// Return BitmapSource instance.
        /// </returns>
        public static BitmapSource GetEmbeddedImage(
            string address,
            Assembly assembly = null)
        {
            try
            {
                if (assembly == null)
                {
                    assembly = Assembly.GetCallingAssembly();
                }

                Stream stream = assembly.GetManifestResourceStream(name: address);
                return BitmapFrame.Create(stream);
            }
            catch
            {
                return null;
            }
        }
    }
}

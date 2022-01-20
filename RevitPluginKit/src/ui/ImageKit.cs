namespace RevitPluginKit.Ui
{
    using System;
    using System.IO;
    using System.Reflection;
    using System.Windows.Media.Imaging;

    /// <summary>
    /// Services for working with images.
    /// </summary>
    public class ImageKit
    {
        /// <summary>
        /// Image extractor. Read specific resource image using address string.
        /// </summary>
        /// <param name="uriString">
        /// The Uri address in the solution where the image is located.
        /// </param>
        /// <returns>
        /// Return BitmapImage instance.
        /// </returns>
        public static BitmapImage GetResourceImage(string uriString)
        {
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(uriString: uriString);
            image.EndInit();
            return image;
        }

        /// <summary>
        /// Image extractor. Read specific embed image using address string.
        /// </summary>
        /// <param name="assembly">
        /// Current assembly.
        /// </param>
        /// <param name="address">
        /// The address in the solution where the image is located.
        /// </param>
        /// <returns>
        /// Return BitmapSource instance.
        /// </returns>
        internal static BitmapSource GetEmbeddedImage(
            Assembly assembly,
            string address)
        {
            try
            {
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

namespace RevitPluginKit.Converters
{
    /// <summary>
    /// Class for converting values from metric to imperial and vice versa.
    /// </summary>
    public class MetricConverter
    {
        /// <summary>
        /// Convert square feet to square meters.
        /// </summary>
        /// <param name="squareFeet"> Square feet value. </param>
        /// <returns>
        /// Return square meters.
        /// </returns>
        public static double SquareFeetToSquareMeters(double squareFeet)
        {
            return squareFeet * 0.09290304;
        }

        /// <summary>
        /// Convert square meters to square feet.
        /// </summary>
        /// <param name="squareMeters"> Square meters value. </param>
        /// <returns>
        /// Return square feets.
        /// </returns>
        public static double SquareMetersToSquareFeet(double squareMeters)
        {
            return squareMeters / 0.09290304;
        }

        /// <summary>
        /// Convert feet to millimeters.
        /// </summary>
        /// <param name="feet"> Feet value. </param>
        /// <returns>
        /// Return millimeters.
        /// </returns>
        public static double FeetToMM(double feet)
        {
            return feet * 304.8;
        }

        /// <summary>
        /// Convert millimeters to feet.
        /// </summary>
        /// <param name="millimeters"> Millimeters value. </param>
        /// <returns>
        /// Return feets.
        /// </returns>
        public static double MMToFeet(double millimeters)
        {
            return millimeters / 304.8;
        }
    }
}

namespace RevitPluginKit.Converters
{
    /// <summary>
    /// Class for converting values from metric to imperial and vice versa.
    /// <para>Please note that Revit makes all internal calculations in imperial units.
    /// As a consequence, when working with metric units, for example in cases of user input, one must be aware of the need to convert between unit types.</para>
    /// </summary>
    public class MetricConverter
    {
        // Coefficient describing the ratio between square feet and square meters.
        private const double SquareFeetToSquareMetersRatio = 0.09290304;

        // Coefficient describing the ratio between feet and millimeters.
        private const double FeetToMMRatio = 304.8;

        /// <summary>
        /// Convert square feet to square meters.
        /// <para>This method is often used to provide data to a user working in the metric system.</para>
        /// </summary>
        /// <param name="squareFeet">
        /// Square feet value. </param>
        /// <returns>
        /// Returns a double representing square meters converted from square feet.
        /// </returns>
        public static double SquareFeetToSquareMeters(double squareFeet)
        {
            return squareFeet * SquareFeetToSquareMetersRatio;
        }

        /// <summary>
        /// Convert square meters to square feet.
        /// <para>This method is often used to convert user-entered metric data for further correct use by internal Revit entities (running in the imperial system).</para>
        /// </summary>
        /// <param name="squareMeters">
        /// Square meters value. </param>
        /// <returns>
        /// Returns a double representing square feet converted from square meters.
        /// </returns>
        public static double SquareMetersToSquareFeet(double squareMeters)
        {
            return squareMeters / SquareFeetToSquareMetersRatio;
        }

        /// <summary>
        /// Convert feet to millimeters.
        /// <para>This method is often used to provide data to a user working in the metric system.</para>
        /// </summary>
        /// <param name="feet"> Feet value. </param>
        /// <returns>
        /// Returns a double representing millimeters converted from feet.
        /// </returns>
        public static double FeetToMM(double feet)
        {
            return feet * FeetToMMRatio;
        }

        /// <summary>
        /// Convert millimeters to feet.
        /// <para>This method is often used to convert user-entered metric data for further correct use by internal Revit entities (running in the imperial system).</para>
        /// </summary>
        /// <param name="millimeters">
        /// Millimeters value. </param>
        /// <returns>
        /// Returns a double representing feet converted from millimeters.
        /// </returns>
        public static double MMToFeet(double millimeters)
        {
            return millimeters / FeetToMMRatio;
        }
    }
}

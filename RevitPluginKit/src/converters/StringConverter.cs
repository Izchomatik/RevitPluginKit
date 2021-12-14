namespace RevitPluginKit.Converters
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// Class for converting and formatting string values.
    /// </summary>
    public class StringConverter
    {
        /// <summary>
        /// Convert stopwatch to string.
        /// </summary>
        /// <param name="stopwatch"> System stopwatch value. </param>
        /// <returns>
        /// Return formatted string.
        /// </returns>
        public static string StopwatchToString(Stopwatch stopwatch)
        {
            TimeSpan timespan = stopwatch.Elapsed;
            return string.Format(
                format: "{0:00}:{1:00}:{2:00}.{3:00}",
                timespan.Hours,
                timespan.Minutes,
                timespan.Seconds,
                timespan.Milliseconds / 10);
        }
    }
}

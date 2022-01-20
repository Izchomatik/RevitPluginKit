namespace RevitPluginKit.Converters
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// Class for converting and formatting various string values.
    /// </summary>
    public class StringConverter
    {
        /// <summary>
        /// Convert stopwatch data to formatted string.
        /// </summary>
        /// <param name="stopwatch">
        /// System stopwatch value.
        /// </param>
        /// <param name="useHours">
        /// Optional parameter: if necessary, specify whether to include hours in the output data.
        /// </param>
        /// <param name="useMinutes">
        /// Optional parameter: if necessary, specify whether to include minutes in the output data.
        /// </param>
        /// <param name="useSeconds">
        /// Optional parameter: if necessary, specify whether to include seconds in the output data.
        /// </param>
        /// <param name="useMilliseconds">
        /// Optional parameter: if necessary, specify whether to include milliseconds in the output data.
        /// </param>
        /// <returns>
        /// Return formatted string, describing the results of the stopwatch.
        /// </returns>
        public static string StopwatchToString(
            Stopwatch stopwatch,
            bool useHours = true,
            bool useMinutes = true,
            bool useSeconds = true,
            bool useMilliseconds = true)
        {
            List<string> results = new List<string>();
            string format = "{0:00}";
            TimeSpan timespan = stopwatch.Elapsed;
            if (useHours == true)
            {
                results.Add(item: string.Format(format: format, timespan.Hours));
            }

            if (useMinutes == true)
            {
                results.Add(item: string.Format(format: format, timespan.Minutes));
            }

            if (useSeconds == true)
            {
                results.Add(item: string.Format(format: format, timespan.Seconds));
            }

            if (useMilliseconds == true)
            {
                results.Add(item: string.Format(format: format, timespan.Milliseconds / 10));
            }

            return string.Join(separator: ":", value: results.ToArray());
        }
    }
}

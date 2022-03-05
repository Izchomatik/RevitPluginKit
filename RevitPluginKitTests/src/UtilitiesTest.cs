namespace RevitPluginKitTests.Src
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading;
    using Autodesk.Revit.Attributes;
    using Autodesk.Revit.DB;
    using Autodesk.Revit.UI;
    using RevitPluginKit.Converters;
    using RevitPluginKitTests.Utilities;
    using RevitPluginKitTests.Wins;

    /// <summary>
    /// Test utility tools using: RevitPluginKit.Converters.
    /// </summary>
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    internal class UtilitiesTest : IExternalCommand
    {
        private const double SquareFeetToSquareMetersRatio = 0.09290304;
        private const double FeetToMMRatio = 304.8;

        /// <inheritdoc/>
        public Result Execute(
            ExternalCommandData commandData,
            ref string message,
            ElementSet elements)
        {
            List<TestResultData> testsResults = AddUtilitiesTest();
            ResultsViewer viewer = new ResultsViewer(
                title: "Utility tools tests",
                description: "Checks for different ways to use the methods defined in: RevitPluginKit.Converters.",
                testsResults: testsResults);
            viewer.ShowDialog();
            return Result.Succeeded;
        }

        /// <summary>
        /// Test value converters using: RevitPluginKit.Converters (main method).
        /// </summary>
        /// <returns>
        /// List of test results data objects.
        /// </returns>
        internal static List<TestResultData> AddUtilitiesTest()
        {
            List<TestResultData> testResultDatas = new List<TestResultData>();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            testResultDatas.Add(TestSquareFeetToSquareMeters());
            testResultDatas.Add(TestSquareMetersToSquareFeet());
            testResultDatas.Add(TestFeetToMM());
            testResultDatas.Add(TestMMToFeet());

            // Just not to get zero in stopwatch tests results
            Thread.Sleep(100);

            stopwatch.Stop();
            testResultDatas.Add(TestStopwatchHours(stopwatch: stopwatch));
            testResultDatas.Add(TestStopwatchMinutes(stopwatch: stopwatch));
            testResultDatas.Add(TestStopwatchSeconds(stopwatch: stopwatch));
            testResultDatas.Add(TestStopwatchMilliseconds(stopwatch: stopwatch));

            return testResultDatas;
        }

        /// <summary>
        /// Test square feet to square meters conversion results.
        /// </summary>
        private static bool AreNearlyEqual(
            double firstValue,
            double secondValue)
        {
            double tolerance = 0.000001;
            return Math.Abs(firstValue - secondValue) < tolerance;
        }

        /// <summary>
        /// Test square feet to square meters conversion results.
        /// </summary>
        private static TestResultData TestSquareFeetToSquareMeters()
        {
            int testsCount = 0;
            bool isCorrect = true;
            string description = string.Empty;
            double[] testValues = new double[] { 1, 15, -3, 2200, 88, 550, 61.389, -23.98 };
            foreach (double testValue in testValues)
            {
                testsCount++;
                double convertedValue = MetricConverter.SquareFeetToSquareMeters(squareFeet: testValue);
                double correctValue = testValue * SquareFeetToSquareMetersRatio;
                bool areEqual = AreNearlyEqual(
                    firstValue: convertedValue,
                    secondValue: correctValue);
                string status = areEqual == true ? "passed" : "failed";
                if (areEqual == false)
                {
                    isCorrect = false;
                }

                description = $"{description}Test {testsCount} - {status}\nSquare feet value: {testValue}\nConverted square meters value: {convertedValue}\nCorrect value: {correctValue}\n\n";
            }

            return new TestResultData(
                testName: "Convert square feet to square meters",
                isCorrect: isCorrect,
                description: description);
        }

        /// <summary>
        /// Test square meters to square feet conversion results.
        /// </summary>
        private static TestResultData TestSquareMetersToSquareFeet()
        {
            int testsCount = 0;
            bool isCorrect = true;
            string description = string.Empty;
            double[] testValues = new double[] { 1, 0.5, 20, 100, -31, -0.89, 22.515, -77.2 };
            foreach (double testValue in testValues)
            {
                testsCount++;
                double convertedValue = MetricConverter.SquareMetersToSquareFeet(squareMeters: testValue);
                double correctValue = testValue / SquareFeetToSquareMetersRatio;
                bool areEqual = AreNearlyEqual(
                    firstValue: convertedValue,
                    secondValue: correctValue);
                string status = areEqual == true ? "passed" : "failed";
                if (areEqual == false)
                {
                    isCorrect = false;
                }

                description = $"{description}Test {testsCount} - {status}\nSquare meters value: {testValue}\nConverted square feet value: {convertedValue}\nCorrect value: {correctValue}\n\n";
            }

            return new TestResultData(
                testName: "Convert square meters to square feet",
                isCorrect: isCorrect,
                description: description);
        }

        /// <summary>
        /// Test feet to millimeters conversion results.
        /// </summary>
        private static TestResultData TestFeetToMM()
        {
            int testsCount = 0;
            bool isCorrect = true;
            string description = string.Empty;
            double[] testValues = new double[] { 1, 8, -2, 120, 62, -378, 13.293, -5.02 };
            foreach (double testValue in testValues)
            {
                testsCount++;
                double convertedValue = MetricConverter.FeetToMM(feet: testValue);
                double correctValue = testValue * FeetToMMRatio;
                bool areEqual = AreNearlyEqual(
                    firstValue: convertedValue,
                    secondValue: correctValue);
                string status = areEqual == true ? "passed" : "failed";
                if (areEqual == false)
                {
                    isCorrect = false;
                }

                description = $"{description}Test {testsCount} - {status}\nFeet value: {testValue}\nConverted millimeters value: {convertedValue}\nCorrect value: {correctValue}\n\n";
            }

            return new TestResultData(
                testName: "Convert feet to millimeters",
                isCorrect: isCorrect,
                description: description);
        }

        /// <summary>
        /// Test millimeters to feet conversion results.
        /// </summary>
        private static TestResultData TestMMToFeet()
        {
            int testsCount = 0;
            bool isCorrect = true;
            string description = string.Empty;
            double[] testValues = new double[] { 1, 1200, -550, 11000, -380, 270000, 389.56, -567.1 };
            foreach (double testValue in testValues)
            {
                testsCount++;
                double convertedValue = MetricConverter.MMToFeet(millimeters: testValue);
                double correctValue = testValue / FeetToMMRatio;
                bool areEqual = AreNearlyEqual(
                    firstValue: convertedValue,
                    secondValue: correctValue);
                string status = areEqual == true ? "passed" : "failed";
                if (areEqual == false)
                {
                    isCorrect = false;
                }

                description = $"{description}Test {testsCount} - {status}\nMillimeters value: {testValue}\nConverted feet value: {convertedValue}\nCorrect value: {correctValue}\n\n";
            }

            return new TestResultData(
                testName: "Convert millimeters to feet",
                isCorrect: isCorrect,
                description: description);
        }

        /// <summary>
        /// Test stopwatch string conversion - only hours otput.
        /// </summary>
        private static TestResultData TestStopwatchHours(Stopwatch stopwatch)
        {
            bool isCorrect = true;
            string description = string.Empty;

            TimeSpan timespan = stopwatch.Elapsed;
            string correctValue = string.Format(
                format: "{0:00}",
                timespan.Hours);
            string convertedValue = StringConverter.StopwatchToString(
                stopwatch: stopwatch,
                useMinutes: false,
                useSeconds: false,
                useMilliseconds: false);
            if (correctValue.Equals(convertedValue))
            {
                description = $"Correct value: {correctValue}";
            }
            else
            {
                isCorrect = false;
                description = $"Correct value: {correctValue}\nConverted value: {convertedValue}";
            }

            return new TestResultData(
                testName: "Stopwatch test - hours output",
                isCorrect: isCorrect,
                description: description);
        }

        /// <summary>
        /// Test stopwatch string conversion - only hours and minutes otput.
        /// </summary>
        private static TestResultData TestStopwatchMinutes(Stopwatch stopwatch)
        {
            bool isCorrect = true;
            string description = string.Empty;

            TimeSpan timespan = stopwatch.Elapsed;
            string correctValue = string.Format(
                format: "{0:00}:{1:00}",
                timespan.Hours,
                timespan.Minutes);
            string convertedValue = StringConverter.StopwatchToString(
                stopwatch: stopwatch,
                useSeconds: false,
                useMilliseconds: false);
            if (correctValue.Equals(convertedValue))
            {
                description = $"Correct value: {correctValue}";
            }
            else
            {
                isCorrect = false;
                description = $"Correct value: {correctValue}\nConverted value: {convertedValue}";
            }

            return new TestResultData(
                testName: "Stopwatch test - hours, minutes output",
                isCorrect: isCorrect,
                description: description);
        }

        /// <summary>
        /// Test stopwatch string conversion - only hours, minutes and seconds otput.
        /// </summary>
        private static TestResultData TestStopwatchSeconds(Stopwatch stopwatch)
        {
            bool isCorrect = true;
            string description = string.Empty;

            TimeSpan timespan = stopwatch.Elapsed;
            string correctValue = string.Format(
                format: "{0:00}:{1:00}:{2:00}",
                timespan.Hours,
                timespan.Minutes,
                timespan.Seconds);
            string convertedValue = StringConverter.StopwatchToString(
                stopwatch: stopwatch,
                useMilliseconds: false);
            if (correctValue.Equals(convertedValue))
            {
                description = $"Correct value: {correctValue}";
            }
            else
            {
                isCorrect = false;
                description = $"Correct value: {correctValue}\nConverted value: {convertedValue}";
            }

            return new TestResultData(
                testName: "Stopwatch test - hours, minutes, seconds output",
                isCorrect: isCorrect,
                description: description);
        }

        /// <summary>
        /// Test stopwatch string conversion - hours, minutes, seconds and milliseconds otput.
        /// </summary>
        private static TestResultData TestStopwatchMilliseconds(Stopwatch stopwatch)
        {
            bool isCorrect = true;
            string description = string.Empty;

            TimeSpan timespan = stopwatch.Elapsed;
            string correctValue = string.Format(
                format: "{0:00}:{1:00}:{2:00}:{3:00}",
                timespan.Hours,
                timespan.Minutes,
                timespan.Seconds,
                timespan.Milliseconds / 10);
            string convertedValue = StringConverter.StopwatchToString(stopwatch: stopwatch);
            if (correctValue.Equals(convertedValue))
            {
                description = $"Correct value: {correctValue}";
            }
            else
            {
                isCorrect = false;
                description = $"Correct value: {correctValue}\nConverted value: {convertedValue}";
            }

            return new TestResultData(
                testName: "Stopwatch test - hours, minutes, seconds, milliseconds output",
                isCorrect: isCorrect,
                description: description);
        }
    }
}

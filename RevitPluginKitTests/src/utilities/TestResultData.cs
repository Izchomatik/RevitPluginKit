namespace RevitPluginKitTests.Utilities
{
    using System.Collections.Generic;

    /// <summary>
    /// Test results data object.
    /// </summary>
    public class TestResultData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestResultData"/> class.
        /// </summary>
        /// <param name="testName"> Name of current test. </param>
        /// <param name="isCorrect"> Value indicating whether this test passed or not. </param>
        /// <param name="description"> Detailed explanation of the test results. </param>
        public TestResultData(
            string testName,
            bool isCorrect,
            string description)
        {
            this.IsFactTest = true;
            this.TestName = testName;
            this.IsCorrect = isCorrect;
            this.Description = description;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TestResultData"/> class.
        /// </summary>
        /// <param name="testName"> Name of current test. </param>
        /// <param name="actualResults"> List of incoming test entities. </param>
        /// <param name="requiredResults"> List of required entities. </param>
        public TestResultData(
            string testName,
            List<string> actualResults,
            List<string> requiredResults)
        {
            this.IsFactTest = false;
            this.TestName = testName;
            this.ActualResults = actualResults;
            this.TestNumber = actualResults.Count;
            this.RequiredResults = requiredResults;
            this.CorrectNumber = requiredResults.Count;
            this.IsCorrect = this.CorrectNumber == this.TestNumber ? true : false;
        }

        /// <summary>
        /// Gets a value indicating whether the given test contains one fact value.
        /// If not, then this test is defined as a test that compares lists of values.
        /// </summary>
        public bool IsFactTest { get; }

        /// <summary>
        /// Gets test name.
        /// </summary>
        public string TestName { get; }

        /// <summary>
        /// Gets the list of incoming test entities.
        /// </summary>
        public List<string> ActualResults { get; }

        /// <summary>
        /// Gets the actual count of incoming test entities.
        /// </summary>
        public int TestNumber { get; }

        /// <summary>
        /// Gets the list of required entities.
        /// </summary>
        public List<string> RequiredResults { get; }

        /// <summary>
        /// Gets the correct number of incoming test entities.
        /// </summary>
        public int CorrectNumber { get; }

        /// <summary>
        /// Gets a value indicating whether this test passed or not.
        /// </summary>
        public bool IsCorrect { get; }

        /// <summary>
        /// Gets detailed explanation of the test results.
        /// </summary>
        public string Description { get; }
    }
}

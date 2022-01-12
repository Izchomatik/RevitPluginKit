namespace RevitPluginKitTests.Wins
{
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Documents;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Shapes;
    using RevitPluginKit.Ui;
    using RevitPluginKitTests.Utilities;

    /// <summary>
    /// Main results report window.
    /// </summary>
    public partial class ResultsViewer : Window
    {
        private static readonly string DetailsContentName = "DetailsContent";

        /// <summary>
        /// Initializes a new instance of the <see cref="ResultsViewer"/> class.
        /// </summary>
        /// <param name="title"> Title of tests block. </param>
        /// <param name="description"> Description for tests block. </param>
        /// <param name="testsResults"> List of test results data objects. </param>
        public ResultsViewer(
            string title,
            string description,
            List<TestResultData> testsResults)
        {
            this.InitializeComponent();
            StackPanel mainStackPanel = this.wpfMainStackPanel;

            mainStackPanel.Children.Add(element: this.HeaderStackPanel(
                title: title,
                description: description,
                testsResults: testsResults));
            mainStackPanel.Children.Add(element: this.ResultsGrid(testsResults: testsResults));
        }

        /// <summary>
        /// Header StackPanel main definition method.
        /// </summary>
        private StackPanel HeaderStackPanel(
            string title,
            string description,
            List<TestResultData> testsResults)
        {
            StackPanel titleStackPanel = new StackPanel() { Margin = new Thickness(uniformLength: 20) };
            titleStackPanel.Children.Add(element: this.TitleTextBlock(
                title: title,
                description: description));
            Line separator = new Line() { Style = WPFLineStyles.BaseStyle };
            titleStackPanel.Children.Add(separator);
            titleStackPanel.Children.Add(this.ReportTextBlock(testsResults: testsResults));
            return titleStackPanel;
        }

        /// <summary>
        /// Title TextBlock main definition method.
        /// </summary>
        private TextBlock TitleTextBlock(
            string title,
            string description)
        {
            TextBlock titleBlock = new TextBlock() { Style = WPFTextBlockStyles.LeftBodyStyle };
            Run titleRun = new Run(text: title) { FontWeight = FontWeights.Bold };
            Run descriptionRun = new Run(text: description);
            titleBlock.Inlines.AddRange(range: new List<Inline>()
            {
                new Run(text: "Test: "),
                titleRun,
                new LineBreak(),
                new Run(text: "Test description: "),
                descriptionRun,
            });
            return titleBlock;
        }

        /// <summary>
        /// Report TextBlock main definition method.
        /// </summary>
        private TextBlock ReportTextBlock(List<TestResultData> testsResults)
        {
            int testsNumber = 0;
            int passedTestsNumber = 0;
            int failedTestsNumber = 0;
            foreach (var testsResult in testsResults)
            {
                testsNumber++;
                if (testsResult.IsCorrect)
                {
                    passedTestsNumber++;
                }
                else
                {
                    failedTestsNumber++;
                }
            }

            bool noErrors = failedTestsNumber == 0;
            TextBlock reportBlock = new TextBlock() { Style = WPFTextBlockStyles.LeftBodyStyle };
            reportBlock.Inlines.AddRange(range: new List<Inline>()
            {
                new Run(text: "General report: "),
                new Run(text: noErrors ? "no errors" : "errors detected") { Style = noErrors ? WPFRunStyles.GreenRun : WPFRunStyles.RedRun },
                new LineBreak(),
                new Run(text: $"Tests number: {testsNumber}"),
                new LineBreak(),
                new Run(text: "Passed tests number: "),
                new Run(text: $"{passedTestsNumber}") { Style = passedTestsNumber == 0 ? WPFRunStyles.BaseRun : WPFRunStyles.GreenRun },
                new LineBreak(),
                new Run(text: "Failed tests number: "),
                new Run(text: $"{failedTestsNumber}") { Style = noErrors ? WPFRunStyles.GreenRun : WPFRunStyles.RedRun },
            });
            return reportBlock;
        }

        /// <summary>
        /// Results grid main definition method.
        /// </summary>
        private List<ColumnDefinition> DefineResultsTableGrid()
        {
            ColumnDefinition markerColumn = new ColumnDefinition() { Width = new GridLength(pixels: 50) };
            ColumnDefinition nameColumn = new ColumnDefinition() { Width = new GridLength(pixels: 260) };
            ColumnDefinition statusColumn = new ColumnDefinition() { Width = new GridLength(pixels: 80) };
            ColumnDefinition resultColumn = new ColumnDefinition() { Width = new GridLength(pixels: 65) };
            ColumnDefinition correctColumn = new ColumnDefinition() { Width = new GridLength(pixels: 65) };
            return new List<ColumnDefinition>()
            {
                markerColumn,
                nameColumn,
                statusColumn,
                resultColumn,
                correctColumn,
            };
        }

        /// <summary>
        /// Results Grid main definition method.
        /// </summary>
        private Grid ResultsGrid(List<TestResultData> testsResults)
        {
            Grid resultsGrid = new Grid();
            resultsGrid.ColumnDefinitions.Add(value: new ColumnDefinition());
            resultsGrid.ColumnDefinitions.Add(value: new ColumnDefinition() { Width = new GridLength(pixels: 300) });
            resultsGrid.Children.Add(element: this.ResultsTableStackPanel(testsResults: testsResults));
            StackPanel resultDetailsStackPanel = this.ResultDetailsStackPanel();
            Grid.SetColumn(
                element: resultDetailsStackPanel,
                value: 1);
            resultsGrid.Children.Add(element: resultDetailsStackPanel);
            return resultsGrid;
        }

        /// <summary>
        /// Results table StackPanel main definition method.
        /// </summary>
        private StackPanel ResultsTableStackPanel(List<TestResultData> testsResults)
        {
            StackPanel stackPanel = new StackPanel() { Margin = new Thickness(uniformLength: 20) };
            stackPanel.Children.Add(element: this.ResultsTableHeader());
            stackPanel.Children.Add(element: this.ResultsListView(testsResults: testsResults));
            return stackPanel;
        }

        /// <summary>
        /// Results table header main definition method.
        /// </summary>
        private Grid ResultsTableHeader()
        {
            Grid headerGrid = new Grid() { Height = 42 };
            this.DefineResultsTableGrid().ForEach(i => headerGrid.ColumnDefinitions.Add(value: i));

            // nameHeader definition
            TextBlock nameHeader = new TextBlock() { Text = "Test name" };
            Grid.SetColumn(
                element: nameHeader,
                value: 1);
            headerGrid.Children.Add(element: nameHeader);

            // statusHeader definition
            TextBlock statusHeader = new TextBlock() { Text = "Status" };
            Grid.SetColumn(
                element: statusHeader,
                value: 2);
            headerGrid.Children.Add(element: statusHeader);

            // resultHeader definition
            TextBlock resultHeader = new TextBlock() { Text = "Resulting value" };
            Grid.SetColumn(
                element: resultHeader,
                value: 3);
            headerGrid.Children.Add(element: resultHeader);

            // correctHeader definition
            TextBlock correctHeader = new TextBlock() { Text = "Correct value" };
            Grid.SetColumn(
                element: correctHeader,
                value: 4);
            headerGrid.Children.Add(element: correctHeader);
            nameHeader.Style = statusHeader.Style = resultHeader.Style = correctHeader.Style = WPFTextBlockStyles.TableHeaderStyle;

            return headerGrid;
        }

        /// <summary>
        /// Results StackPanel main definition method.
        /// </summary>
        private ListView ResultsListView(List<TestResultData> testsResults)
        {
            BitmapImage passedIconImage = ImageKit.GetResourceImage(uriString: "pack://application:,,,/RevitPluginKitTests;component/assets/icons/PassedIcon.png");
            BitmapImage failedIconImage = ImageKit.GetResourceImage(uriString: "pack://application:,,,/RevitPluginKitTests;component/assets/icons/FailedIcon.png");
            ListView resultsListView = new ListView()
            {
                Style = WPFListViewStyles.ScrollableListView,
                Height = 500,
            };
            resultsListView.SelectionChanged += this.ResultsSelectionChanged;
            bool isGrayLine = true;
            foreach (var testsResult in testsResults)
            {
                // Grid definition
                Grid resultsGrid = new Grid() { Style = WPFGridStyles.ResultRowGrid };
                this.DefineResultsTableGrid().ForEach(i => resultsGrid.ColumnDefinitions.Add(value: i));

                // statusIcon definition
                Image statusIcon = new Image()
                {
                    Source = testsResult.IsCorrect == true ? passedIconImage : failedIconImage,
                    Style = WPFImageStyles.IconStyle,
                };
                resultsGrid.Children.Add(element: statusIcon);

                // testNameBlock definition
                TextBlock testNameBlock = new TextBlock()
                {
                    Text = testsResult.TestName,
                    Style = WPFTextBlockStyles.LeftBodyStyle,
                };
                Grid.SetColumn(
                    element: testNameBlock,
                    value: 1);
                resultsGrid.Children.Add(element: testNameBlock);

                // statusBlock definition
                TextBlock statusBlock = new TextBlock()
                {
                    Text = testsResult.IsCorrect == true ? "passed" : "failed",
                    Style = testsResult.IsCorrect == true ? WPFTextBlockStyles.CenterGreenBodyStyle : WPFTextBlockStyles.CenterRedBodyStyle,
                };
                Grid.SetColumn(
                    element: statusBlock,
                    value: 2);
                resultsGrid.Children.Add(element: statusBlock);

                if (testsResult.IsFactTest == false)
                {
                    // resultBlock definition
                    TextBlock resultBlock = new TextBlock()
                    {
                        Text = $"{testsResult.TestNumber}",
                        Style = testsResult.IsCorrect == true ? WPFTextBlockStyles.CenterGreenBodyStyle : WPFTextBlockStyles.CenterRedBodyStyle,
                    };
                    Grid.SetColumn(
                        element: resultBlock,
                        value: 3);
                    resultsGrid.Children.Add(element: resultBlock);

                    // correctBlock definition
                    if (testsResult.IsCorrect == false)
                    {
                        TextBlock correctBlock = new TextBlock()
                        {
                            Text = $"{testsResult.CorrectNumber}",
                            Style = WPFTextBlockStyles.CenterBodyStyle,
                        };
                        Grid.SetColumn(
                            element: correctBlock,
                            value: 4);
                        resultsGrid.Children.Add(element: correctBlock);
                    }
                }

                ListViewItem newListItem = new ListViewItem()
                {
                    Content = resultsGrid,
                    DataContext = testsResult,
                    Background = isGrayLine == true ? Brushes.WhiteSmoke : Brushes.Transparent,
                };
                isGrayLine = !isGrayLine;
                resultsListView.Items.Add(newItem: newListItem);
            }

            return resultsListView;
        }

        /// <summary>
        /// Results table StackPanel main definition method.
        /// </summary>
        private StackPanel ResultDetailsStackPanel()
        {
            StackPanel stackPanel = new StackPanel() { Margin = new Thickness(uniformLength: 20) };
            Grid headerGrid = new Grid()
            {
                Height = 42,
                Margin = new Thickness(right: 17, left: 0, top: 0, bottom: 0),
            };
            TextBlock nameHeader = new TextBlock()
            {
                Text = "Test results details:",
                Style = WPFTextBlockStyles.TableHeaderStyle,
            };
            headerGrid.Children.Add(element: nameHeader);
            stackPanel.Children.Add(element: headerGrid);
            TextBlock detailsContent = new TextBlock()
            {
                Text = "Click on any test line to see details",
                Style = WPFTextBlockStyles.CenterBodyStyle,
            };
            this.RegisterName(
                name: DetailsContentName,
                scopedElement: detailsContent);
            ScrollViewer detailsScrollViewer = new ScrollViewer()
            {
                Height = 500,
                VerticalScrollBarVisibility = ScrollBarVisibility.Visible,
                Content = detailsContent,
            };
            stackPanel.Children.Add(element: detailsScrollViewer);
            return stackPanel;
        }

        /// <summary>
        /// Result selection changed event method.
        /// </summary>
        private void ResultsSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListViewItem selctedItem = (sender as ListView).SelectedItem as ListViewItem;
            TextBlock detailsContentTextBlock = (TextBlock)this.FindName(DetailsContentName);
            detailsContentTextBlock.Text = string.Empty;
            detailsContentTextBlock.Style = WPFTextBlockStyles.TopLeftBodyStyle;
            TestResultData testsResult = selctedItem.DataContext as TestResultData;
            List<Inline> reportLines = new List<Inline>()
            {
                new Run(text: $"Report for test:\n") { Style = WPFRunStyles.DemiBoldRun },
                new Run(text: testsResult.TestName),
                new Run(text: "\n\nStatus: ") { Style = WPFRunStyles.DemiBoldRun },
                new Run(text: testsResult.IsCorrect ? "Test passed" : "Test failed") { Style = testsResult.IsCorrect ? WPFRunStyles.GreenRun : WPFRunStyles.RedRun },
                new LineBreak(),
                new LineBreak(),
            };
            if (testsResult.IsFactTest == true)
            {
                reportLines.AddRange(collection: new List<Inline>()
                {
                    new Run(text: "Results description:\n\n") { Style = WPFRunStyles.DemiBoldRun },
                    new Run(text: testsResult.Description),
                });
            }
            else
            {
                reportLines.AddRange(collection: new List<Inline>()
                {
                    new Run(text: "Actual test results:\n\n") { Style = WPFRunStyles.DemiBoldRun },
                    new Run(text: string.Join(
                        separator: "\n",
                        values: testsResult.ActualResults)),
                });
                if (testsResult.IsCorrect == false)
                {
                    reportLines.AddRange(collection: new List<Inline>()
                    {
                        new Run(text: "\n\n---\n\nRequired test results:\n\n") { Style = WPFRunStyles.DemiBoldRun },
                        new Run(text: string.Join(
                            separator: "\n",
                            values: testsResult.RequiredResults)),
                    });
                }
            }

            detailsContentTextBlock.Inlines.AddRange(range: reportLines);
        }
    }
}

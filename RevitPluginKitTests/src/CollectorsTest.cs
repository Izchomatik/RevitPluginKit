namespace RevitPluginKitTests.Src
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Autodesk.Revit.Attributes;
    using Autodesk.Revit.DB;
    using Autodesk.Revit.UI;
    using RevitPluginKit.Collectors;
    using RevitPluginKitTests.Utilities;
    using RevitPluginKitTests.Wins;

    /// <summary>
    /// Test collectors using Revit model: RevitPluginKitTests.
    /// </summary>
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    internal class CollectorsTest : IExternalCommand
    {
        private const string TestOption = "Option 1";
        private const string TestWallType = "Generic - 200mm";
        private const string TestDoorFamily = "M_Single-Flush";
        private const string TestDoorType = "0915 x 2032mm";
        private const string TestFloorType = "Generic Floor - 200mm";
        private const string TestLevel1 = "Level 1";
        private const string TestLevel2 = "Level 2";

        /// <inheritdoc/>
        public Result Execute(
            ExternalCommandData commandData,
            ref string message,
            ElementSet elements)
        {
            UIApplication uiApp = commandData.Application;
            Document document = uiApp.ActiveUIDocument.Document;
            List<TestResultData> testsResults = AddCollectorsTest(document: document);
            ResultsViewer viewer = new ResultsViewer(
                title: "Collector tests",
                description: "Checks for different ways to use the methods defined in: RevitPluginKit.Collectors.",
                testsResults: testsResults);
            viewer.ShowDialog();
            return Result.Succeeded;
        }

        /// <summary>
        /// Test collectors using Revit model: RevitPluginKitTests (main method).
        /// </summary>
        /// <param name="document"> Current revit document instance. </param>
        /// <returns>
        /// List of test results data objects.
        /// </returns>
        internal static List<TestResultData> AddCollectorsTest(Document document)
        {
            List<TestResultData> testResultDatas = new List<TestResultData>();

            // Extract and test design options data
            List<DesignOption> designOptions = ElementsCollector.InstancesByCategory<DesignOption>(
                document: document,
                category: BuiltInCategory.OST_DesignOptions);
            DesignOption designOption = designOptions.Find(i => Regex.IsMatch(
                input: i.Name,
                pattern: TestOption));
            ElementDesignOptionFilter optionFilter = new ElementDesignOptionFilter(designOptionId: designOption.Id);
            ElementDesignOptionFilter currentOptionFilter = new ElementDesignOptionFilter(designOptionId: DesignOption.GetActiveDesignOptionId(document));

            // Extract and test levels data
            List<Level> levels = ElementsCollector.InstancesByCategory<Level>(
                document: document,
                category: BuiltInCategory.OST_Levels);
            ElementId level1Id = levels.Find(i => i.Name.Equals(TestLevel1)).Id;
            ElementId level2Id = levels.Find(i => i.Name.Equals(TestLevel2)).Id;

            // Test general data
            testResultDatas.Add(TestDesignOptions(document: document));
            testResultDatas.Add(TestLevels(document: document));

            // Wall collectors tests
            testResultDatas.Add(TestAllWalls(document: document));
            testResultDatas.Add(TestAllTypeWalls(document: document));
            testResultDatas.Add(TestCurrentOptionWalls(document: document, currentOptionFilter: currentOptionFilter));
            testResultDatas.Add(TestCurrentOptionTypeWalls(document: document, currentOptionFilter: currentOptionFilter));
            testResultDatas.Add(TestOptionWalls(document: document, optionFilter: optionFilter));
            testResultDatas.Add(TestOptionTypeWalls(document: document, optionFilter: optionFilter));

            // Door collectors tests
            testResultDatas.Add(TestCurrentOptionDoors(document: document, currentOptionFilter: currentOptionFilter));
            testResultDatas.Add(TestCurrentOptionFamilyDoors(document: document, currentOptionFilter: currentOptionFilter));
            testResultDatas.Add(TestCurrentOptionTypeDoors(document: document, currentOptionFilter: currentOptionFilter));
            testResultDatas.Add(TestCurrentOptionFamilyTypeDoors(document: document, currentOptionFilter: currentOptionFilter));
            testResultDatas.Add(TestOptionTypeDoors(document: document, optionFilter: optionFilter));

            // Floor collectors tests
            testResultDatas.Add(TestAllFloors(document: document));
            testResultDatas.Add(TestAllLevel1Floors(document: document, levelId: level1Id));
            testResultDatas.Add(TestAllLevel12Floors(document: document, level1Id: level1Id, level2Id: level2Id));
            testResultDatas.Add(TestOptionLevel2Floors(document: document, optionFilter: optionFilter, levelId: level2Id));
            testResultDatas.Add(TestOptionTypeLevel1Floors(document: document, optionFilter: optionFilter, levelId: level1Id));

            // Test types
            testResultDatas.Add(TestWallTypes(document: document));
            testResultDatas.Add(TestFamilyDoorTypes(document: document));
            testResultDatas.Add(TestTypeFloorTypes(document: document));

            return testResultDatas;
        }

        /// <summary>
        /// Test all design options collector.
        /// </summary>
        private static TestResultData TestDesignOptions(Document document)
        {
            List<DesignOption> referenceOptions = new FilteredElementCollector(document)
                .WhereElementIsNotElementType()
                .OfCategory(BuiltInCategory.OST_DesignOptions)
                .Cast<DesignOption>()
                .ToList();
            List<DesignOption> designOptions = ElementsCollector.InstancesByCategory<DesignOption>(
                document: document,
                category: BuiltInCategory.OST_DesignOptions);
            return new TestResultData(
                testName: "Collector of design options in model",
                actualResults: designOptions.Select(i => i.Name).ToList(),
                requiredResults: referenceOptions.Select(i => i.Name).ToList());
        }

        /// <summary>
        /// Test all levels collector.
        /// </summary>
        private static TestResultData TestLevels(Document document)
        {
            List<Level> referenceOptions = new FilteredElementCollector(document)
                .WhereElementIsNotElementType()
                .OfCategory(BuiltInCategory.OST_Levels)
                .Cast<Level>()
                .ToList();
            List<Level> designOptions = ElementsCollector.InstancesByCategory<Level>(
                document: document,
                category: BuiltInCategory.OST_Levels);
            return new TestResultData(
                testName: "Collector of levels in model",
                actualResults: designOptions.Select(i => i.Name).ToList(),
                requiredResults: referenceOptions.Select(i => i.Name).ToList());
        }

        /// <summary>
        /// Test all walls collector.
        /// </summary>
        private static TestResultData TestAllWalls(Document document)
        {
            List<Wall> referenceWalls = new FilteredElementCollector(document)
                .WhereElementIsNotElementType()
                .OfCategory(BuiltInCategory.OST_Walls)
                .Cast<Wall>()
                .ToList();
            List<Wall> testWalls = ElementsCollector.InstancesByCategory<Wall>(
                document: document,
                category: BuiltInCategory.OST_Walls,
                useOptionFilter: false);
            return new TestResultData(
                testName: "Collector of walls in model",
                actualResults: testWalls.Select(i => i.Name).ToList(),
                requiredResults: referenceWalls.Select(i => i.Name).ToList());
        }

        /// <summary>
        /// Test walls of specific type in model.
        /// </summary>
        private static TestResultData TestAllTypeWalls(Document document)
        {
            List<Wall> referenceWalls = new FilteredElementCollector(document)
                .WhereElementIsNotElementType()
                .OfCategory(BuiltInCategory.OST_Walls)
                .Where(i => i.Name.Equals(TestWallType))
                .Cast<Wall>()
                .ToList();
            List<Wall> testWalls = ElementsCollector.InstancesByCategory<Wall>(
                document: document,
                category: BuiltInCategory.OST_Walls,
                typeName: TestWallType,
                useOptionFilter: false);
            return new TestResultData(
                testName: $"Collector of \"{TestWallType}\" walls in model",
                actualResults: testWalls.Select(i => i.Name).ToList(),
                requiredResults: referenceWalls.Select(i => i.Name).ToList());
        }

        /// <summary>
        /// Test walls in current option collector.
        /// </summary>
        private static TestResultData TestCurrentOptionWalls(
            Document document,
            ElementDesignOptionFilter currentOptionFilter)
        {
            List<Wall> referenceWalls = new FilteredElementCollector(document)
                .WhereElementIsNotElementType()
                .WherePasses(filter: currentOptionFilter)
                .OfCategory(BuiltInCategory.OST_Walls)
                .Cast<Wall>()
                .ToList();
            List<Wall> testWalls = ElementsCollector.InstancesByCategory<Wall>(
                document: document,
                category: BuiltInCategory.OST_Walls);
            return new TestResultData(
                testName: $"Collector of walls in current option",
                actualResults: testWalls.Select(i => i.Name).ToList(),
                requiredResults: referenceWalls.Select(i => i.Name).ToList());
        }

        /// <summary>
        /// Test walls of specific type in current option collector.
        /// </summary>
        private static TestResultData TestCurrentOptionTypeWalls(
            Document document,
            ElementDesignOptionFilter currentOptionFilter)
        {
            List<Wall> referenceWalls = new FilteredElementCollector(document)
                .WhereElementIsNotElementType()
                .WherePasses(filter: currentOptionFilter)
                .OfCategory(BuiltInCategory.OST_Walls)
                .Where(i => i.Name.Equals(TestWallType))
                .Cast<Wall>()
                .ToList();
            List<Wall> testWalls = ElementsCollector.InstancesByCategory<Wall>(
                document: document,
                category: BuiltInCategory.OST_Walls,
                typeName: TestWallType);
            return new TestResultData(
                testName: $"Collector of \"{TestWallType}\" walls in current option",
                actualResults: testWalls.Select(i => i.Name).ToList(),
                requiredResults: referenceWalls.Select(i => i.Name).ToList());
        }

        /// <summary>
        /// Test walls in specific option collector.
        /// </summary>
        private static TestResultData TestOptionWalls(
            Document document,
            ElementDesignOptionFilter optionFilter)
        {
            List<Wall> referenceWalls = new FilteredElementCollector(document)
                .WhereElementIsNotElementType()
                .WherePasses(filter: optionFilter)
                .OfCategory(BuiltInCategory.OST_Walls)
                .Cast<Wall>()
                .ToList();
            List<Wall> testWalls = ElementsCollector.InstancesByCategory<Wall>(
                document: document,
                category: BuiltInCategory.OST_Walls,
                optionFilter: optionFilter);
            return new TestResultData(
                testName: $"Collector of walls in \"{TestOption}\"",
                actualResults: testWalls.Select(i => i.Name).ToList(),
                requiredResults: referenceWalls.Select(i => i.Name).ToList());
        }

        /// <summary>
        /// Test walls of specific type in specific option collector.
        /// </summary>
        private static TestResultData TestOptionTypeWalls(
            Document document,
            ElementDesignOptionFilter optionFilter)
        {
            List<Wall> referenceWalls = new FilteredElementCollector(document)
                .WhereElementIsNotElementType()
                .WherePasses(filter: optionFilter)
                .OfCategory(BuiltInCategory.OST_Walls)
                .Where(i => i.Name.Equals(TestWallType))
                .Cast<Wall>()
                .ToList();
            List<Wall> testWalls = ElementsCollector.InstancesByCategory<Wall>(
                document: document,
                category: BuiltInCategory.OST_Walls,
                typeName: TestWallType,
                optionFilter: optionFilter);
            return new TestResultData(
                testName: $"Collector of \"{TestWallType}\" walls in \"{TestOption}\"",
                actualResults: testWalls.Select(i => i.Name).ToList(),
                requiredResults: referenceWalls.Select(i => i.Name).ToList());
        }

        /// <summary>
        /// Test doors in current option collector.
        /// </summary>
        private static TestResultData TestCurrentOptionDoors(
            Document document,
            ElementDesignOptionFilter currentOptionFilter)
        {
            List<Element> referenceElements = new FilteredElementCollector(document)
                .WhereElementIsNotElementType()
                .WherePasses(filter: currentOptionFilter)
                .OfCategory(BuiltInCategory.OST_Doors)
                .Cast<Element>()
                .ToList();
            List<Element> testElements = ElementsCollector.InstancesByCategory<Element>(
                document: document,
                category: BuiltInCategory.OST_Doors);
            return new TestResultData(
                testName: $"Collector of doors in current option",
                actualResults: testElements.Select(i => i.Name).ToList(),
                requiredResults: referenceElements.Select(i => i.Name).ToList());
        }

        /// <summary>
        /// Test doors of specific family in current option collector.
        /// </summary>
        private static TestResultData TestCurrentOptionFamilyDoors(
            Document document,
            ElementDesignOptionFilter currentOptionFilter)
        {
            List<Element> referenceElements = new FilteredElementCollector(document)
                .WhereElementIsNotElementType()
                .WherePasses(filter: currentOptionFilter)
                .OfCategory(BuiltInCategory.OST_Doors)
                .Where(i => ((FamilyInstance)i).Symbol.Family.Name.Equals(TestDoorFamily))
                .Cast<Element>()
                .ToList();
            List<Element> testElements = ElementsCollector.InstancesByCategory<Element>(
                document: document,
                category: BuiltInCategory.OST_Doors,
                familyName: TestDoorFamily);
            return new TestResultData(
                testName: $"Collector of \"{TestDoorFamily}\" doors in current option",
                actualResults: testElements.Select(i => i.Name).ToList(),
                requiredResults: referenceElements.Select(i => i.Name).ToList());
        }

        /// <summary>
        /// Test doors of specific type in current option collector.
        /// </summary>
        private static TestResultData TestCurrentOptionTypeDoors(
            Document document,
            ElementDesignOptionFilter currentOptionFilter)
        {
            List<Element> referenceElements = new FilteredElementCollector(document)
                .WhereElementIsNotElementType()
                .WherePasses(filter: currentOptionFilter)
                .OfCategory(BuiltInCategory.OST_Doors)
                .Where(i => i.Name.Equals(TestDoorType))
                .Cast<Element>()
                .ToList();
            List<Element> testElements = ElementsCollector.InstancesByCategory<Element>(
                document: document,
                category: BuiltInCategory.OST_Doors,
                typeName: TestDoorType);
            return new TestResultData(
                testName: $"Collector of \"{TestDoorType}\" doors in current option",
                actualResults: testElements.Select(i => i.Name).ToList(),
                requiredResults: referenceElements.Select(i => i.Name).ToList());
        }

        /// <summary>
        /// Test doors of specific family and type in current option collector.
        /// </summary>
        private static TestResultData TestCurrentOptionFamilyTypeDoors(
            Document document,
            ElementDesignOptionFilter currentOptionFilter)
        {
            List<Element> referenceElements = new FilteredElementCollector(document)
                .WhereElementIsNotElementType()
                .WherePasses(filter: currentOptionFilter)
                .OfCategory(BuiltInCategory.OST_Doors)
                .Where(i => ((FamilyInstance)i).Symbol.Family.Name.Equals(TestDoorFamily) && i.Name.Equals(TestDoorType))
                .Cast<Element>()
                .ToList();
            List<Element> testElements = ElementsCollector.InstancesByCategory<Element>(
                document: document,
                category: BuiltInCategory.OST_Doors,
                familyName: TestDoorFamily,
                typeName: TestDoorType);
            return new TestResultData(
                testName: $"Collector of \"{TestDoorFamily}\" - \"{TestDoorType}\" doors in current option",
                actualResults: testElements.Select(i => i.Name).ToList(),
                requiredResults: referenceElements.Select(i => i.Name).ToList());
        }

        /// <summary>
        /// Test doors of specific type in specific option collector.
        /// </summary>
        private static TestResultData TestOptionTypeDoors(
            Document document,
            ElementDesignOptionFilter optionFilter)
        {
            List<Element> referenceElements = new FilteredElementCollector(document)
                .WhereElementIsNotElementType()
                .WherePasses(filter: optionFilter)
                .OfCategory(BuiltInCategory.OST_Doors)
                .Where(i => i.Name.Equals(TestDoorType))
                .Cast<Element>()
                .ToList();
            List<Element> testElements = ElementsCollector.InstancesByCategory<Element>(
                document: document,
                category: BuiltInCategory.OST_Doors,
                typeName: TestDoorType,
                optionFilter: optionFilter);
            return new TestResultData(
                testName: $"Collector of \"{TestDoorType}\" doors in \"{TestOption}\"",
                actualResults: testElements.Select(i => i.Name).ToList(),
                requiredResults: referenceElements.Select(i => i.Name).ToList());
        }

        /// <summary>
        /// Test all floors collector.
        /// </summary>
        private static TestResultData TestAllFloors(Document document)
        {
            List<Floor> referenceFloors = new FilteredElementCollector(document)
                .WhereElementIsNotElementType()
                .OfCategory(BuiltInCategory.OST_Floors)
                .Cast<Floor>()
                .ToList();
            List<Floor> testFloors = ElementsCollector.InstancesByCategory<Floor>(
                document: document,
                category: BuiltInCategory.OST_Floors,
                useOptionFilter: false);
            return new TestResultData(
                testName: "Collector of floors in model",
                actualResults: testFloors.Select(i => i.Name).ToList(),
                requiredResults: referenceFloors.Select(i => i.Name).ToList());
        }

        /// <summary>
        /// Test floors at specific level 1 collector.
        /// </summary>
        private static TestResultData TestAllLevel1Floors(
            Document document,
            ElementId levelId)
        {
            List<Floor> referenceFloors = new FilteredElementCollector(document)
                .WhereElementIsNotElementType()
                .OfCategory(BuiltInCategory.OST_Floors)
                .Where(i => document.GetElement(id: i.LevelId).Name.Equals(TestLevel1))
                .Cast<Floor>()
                .ToList();
            List<Floor> testFloors = ElementsCollector.InstancesByCategory<Floor>(
                document: document,
                category: BuiltInCategory.OST_Floors,
                useOptionFilter: false,
                levelIdsToFilterBy: new List<ElementId>() { levelId });
            return new TestResultData(
                testName: $"Collector of floors at the \"{TestLevel1}\"",
                actualResults: testFloors.Select(i => i.Name).ToList(),
                requiredResults: referenceFloors.Select(i => i.Name).ToList());
        }

        /// <summary>
        /// Test floors at specific levels 1 and 2 collector.
        /// </summary>
        private static TestResultData TestAllLevel12Floors(
            Document document,
            ElementId level1Id,
            ElementId level2Id)
        {
            List<Floor> referenceFloors = new FilteredElementCollector(document)
                .WhereElementIsNotElementType()
                .OfCategory(BuiltInCategory.OST_Floors)
                .Where(i => new List<string>() { TestLevel1, TestLevel2 }.Contains(document.GetElement(id: i.LevelId).Name))
                .Cast<Floor>()
                .ToList();
            List<Floor> testFloors = ElementsCollector.InstancesByCategory<Floor>(
                document: document,
                category: BuiltInCategory.OST_Floors,
                useOptionFilter: false,
                levelIdsToFilterBy: new List<ElementId>() { level1Id, level2Id });
            return new TestResultData(
                testName: $"Collector of floors at the \"{TestLevel1}\" and \"{TestLevel2}\"",
                actualResults: testFloors.Select(i => i.Name).ToList(),
                requiredResults: referenceFloors.Select(i => i.Name).ToList());
        }

        /// <summary>
        /// Test floors at specific level 2 and in specific option collector.
        /// </summary>
        private static TestResultData TestOptionLevel2Floors(
            Document document,
            ElementDesignOptionFilter optionFilter,
            ElementId levelId)
        {
            List<Floor> referenceFloors = new FilteredElementCollector(document)
                .WhereElementIsNotElementType()
                .WherePasses(filter: optionFilter)
                .OfCategory(BuiltInCategory.OST_Floors)
                .Where(i => document.GetElement(id: i.LevelId).Name.Equals(TestLevel2))
                .Cast<Floor>()
                .ToList();
            List<Floor> testFloors = ElementsCollector.InstancesByCategory<Floor>(
                document: document,
                category: BuiltInCategory.OST_Floors,
                optionFilter: optionFilter,
                levelIdsToFilterBy: new List<ElementId>() { levelId });
            return new TestResultData(
                testName: $"Collector of floors at the \"{TestLevel2}\" in \"{TestOption}\"",
                actualResults: testFloors.Select(i => i.Name).ToList(),
                requiredResults: referenceFloors.Select(i => i.Name).ToList());
        }

        /// <summary>
        /// Test floors of specific type at specific level 1 and in specific option collector.
        /// </summary>
        private static TestResultData TestOptionTypeLevel1Floors(
            Document document,
            ElementDesignOptionFilter optionFilter,
            ElementId levelId)
        {
            List<Floor> referenceFloors = new FilteredElementCollector(document)
                .WhereElementIsNotElementType()
                .WherePasses(filter: optionFilter)
                .OfCategory(BuiltInCategory.OST_Floors)
                .Where(i => document.GetElement(id: i.LevelId).Name.Equals(TestLevel1) && i.Name.Equals(TestFloorType))
                .Cast<Floor>()
                .ToList();
            List<Floor> testFloors = ElementsCollector.InstancesByCategory<Floor>(
                document: document,
                category: BuiltInCategory.OST_Floors,
                optionFilter: optionFilter,
                typeName: TestFloorType,
                levelIdsToFilterBy: new List<ElementId>() { levelId });
            return new TestResultData(
                testName: $"Collector of \"{TestFloorType}\" floors at the \"{TestLevel1}\" in \"{TestOption}\"",
                actualResults: testFloors.Select(i => i.Name).ToList(),
                requiredResults: referenceFloors.Select(i => i.Name).ToList());
        }

        /// <summary>
        /// Test all wall types number in model.
        /// </summary>
        private static TestResultData TestWallTypes(Document document)
        {
            List<WallType> referenceTypes = new FilteredElementCollector(document)
                .WhereElementIsElementType()
                .OfCategory(BuiltInCategory.OST_Walls)
                .Cast<WallType>()
                .ToList();
            List<WallType> testTypes = ElementsCollector.TypesByCategory<WallType>(
                document: document,
                category: BuiltInCategory.OST_Walls);
            return new TestResultData(
                testName: "Collector of wall types",
                actualResults: testTypes.Select(i => i.Name).ToList(),
                requiredResults: referenceTypes.Select(i => i.Name).ToList());
        }

        /// <summary>
        /// Test door types of specific family number in model.
        /// </summary>
        private static TestResultData TestFamilyDoorTypes(Document document)
        {
            List<Element> referenceTypes = new FilteredElementCollector(document)
                .WhereElementIsElementType()
                .OfCategory(BuiltInCategory.OST_Doors)
                .Where(i => ((FamilySymbol)i).FamilyName.Equals(TestDoorFamily))
                .Cast<Element>()
                .ToList();
            List<Element> testTypes = ElementsCollector.TypesByCategory<Element>(
                document: document,
                category: BuiltInCategory.OST_Doors,
                familyName: TestDoorFamily);
            return new TestResultData(
                testName: $"Collector of \"{TestDoorType}\" door types",
                actualResults: testTypes.Select(i => i.Name).ToList(),
                requiredResults: referenceTypes.Select(i => i.Name).ToList());
        }

        /// <summary>
        /// Test floor types of specific type number in model (must be 1).
        /// </summary>
        private static TestResultData TestTypeFloorTypes(Document document)
        {
            List<FloorType> referenceTypes = new FilteredElementCollector(document)
                .WhereElementIsElementType()
                .OfCategory(BuiltInCategory.OST_Floors)
                .Where(i => i.Name.Equals(TestFloorType))
                .Cast<FloorType>()
                .ToList();
            List<FloorType> testTypes = ElementsCollector.TypesByCategory<FloorType>(
                document: document,
                category: BuiltInCategory.OST_Floors,
                typeName: TestFloorType);
            return new TestResultData(
                testName: $"Collector of \"{TestFloorType}\" floor types",
                actualResults: testTypes.Select(i => i.Name).ToList(),
                requiredResults: referenceTypes.Select(i => i.Name).ToList());
        }
    }
}

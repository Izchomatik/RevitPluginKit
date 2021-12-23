﻿namespace RevitPluginKit.Collectors
{
    using System.Collections.Generic;
    using Autodesk.Revit.DB;

    /// <summary>
    /// A class containing methods for quickly finding elements in the Revit model.
    /// </summary>
    public class ElementsCollector
    {
        /// <summary>
        /// Collect Revit element instances by category.
        /// </summary>
        /// <typeparam name="T"> Revit category (For example: Element). </typeparam>
        /// <param name="document"> Current revit document instance. </param>
        /// <param name="category"> Revit BuiltIn category to collect. </param>
        /// <param name="familyName"> Optional parameter: if necessary, specify the name of the family of the elements to be collected. </param>
        /// <param name="typeName"> Optional parameter: if necessary, specify the type name of the elements to be collected. </param>
        /// <param name="levelIdsToFilterBy"> Optional parameter: if necessary, specify list of level ids of the elements to be collected. </param>
        /// <param name="useOptionFilter"> Optional parameter: indicate whether it is necessary to use an option filter. </param>
        /// <param name="optionFilter"> Optional parameter: specify option filter.
        /// If useOptionFilter == true and optionFilter == null => items from the currently active option will be collected. </param>
        /// <returns>
        /// Returns the list of Revit elements (Element).
        /// </returns>
        public static List<T> InstancesByCategory<T>(
            Document document,
            BuiltInCategory category,
            string familyName = null,
            string typeName = null,
            List<ElementId> levelIdsToFilterBy = null,
            bool useOptionFilter = true,
            ElementDesignOptionFilter optionFilter = null)
        {
            FilteredElementCollector collector = new FilteredElementCollector(document)
                .WhereElementIsNotElementType()
                .OfCategory(category);
            return FilterUtilities<T>.AddInstanceFilters(
                document: document,
                collector: collector,
                familyName: familyName,
                typeName: typeName,
                levelIdsToFilterBy: levelIdsToFilterBy,
                useOptionFilter: useOptionFilter,
                optionFilter: optionFilter);
        }

        /// <summary>
        /// Collect Revit element types by category.
        /// </summary>
        /// <typeparam name="T"> Revit category (For example: Element). </typeparam>
        /// <param name="document"> Current revit document instance. </param>
        /// <param name="category"> Revit BuiltIn category to collect. </param>
        /// <param name="familyName"> Optional parameter: if necessary, specify the name of the family of the elements to be collected. </param>
        /// <param name="typeName"> Optional parameter: if necessary, specify the type name of the elements to be collected. </param>
        /// <returns>
        /// Returns the list of Revit elements (Element).
        /// </returns>
        public static List<T> TypesByCategory<T>(
            Document document,
            BuiltInCategory category,
            string familyName = null,
            string typeName = null)
        {
            FilteredElementCollector collector = new FilteredElementCollector(document)
                .WhereElementIsElementType()
                .OfCategory(category);
            return FilterUtilities<T>.AddTypeFilters(
                collector: collector,
                familyName: familyName,
                typeName: typeName);
        }
    }
}
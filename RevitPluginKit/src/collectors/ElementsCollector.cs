namespace RevitPluginKit.Collectors
{
    using System.Collections.Generic;
    using Autodesk.Revit.DB;
    using static RevitPluginKit.Collectors.FilterUtilities;

    /// <summary>
    /// A class containing methods for quickly finding elements in the Revit model.
    /// </summary>
    public class ElementsCollector
    {
        /// <summary>
        /// Collect Revit element instances by category.
        /// </summary>
        /// <param name="document"> Current revit document instance. </param>
        /// <param name="category"> Revit BuiltIn category to collect. </param>
        /// <param name="familyName"> Optional parameter: if necessary, specify the name of the family of the elements to be collected. </param>
        /// <param name="typeName"> Optional parameter: if necessary, specify the type name of the elements to be collected. </param>
        /// <param name="useOptionFilter"> Optional parameter: indicate whether it is necessary to use an option filter. </param>
        /// <param name="optionFilter"> Optional parameter: specify option filter.
        /// If useOptionFilter == true and optionFilter == null => items from the currently active option will be collected. </param>
        /// <returns>
        /// Returns the list of Revit elements (Element).
        /// </returns>
        public static List<Element> InstancesByCategory(
            Document document,
            BuiltInCategory category,
            string familyName = null,
            string typeName = null,
            bool useOptionFilter = true,
            ElementDesignOptionFilter optionFilter = null)
        {
            FilteredElementCollector collector = new FilteredElementCollector(document)
                .WhereElementIsNotElementType()
                .OfCategory(category);
            if (useOptionFilter == true)
            {
                ElementDesignOptionFilter checkedOptionFilter = CheckOptionFilter(
                    document: document,
                    optionFilter: optionFilter);
                collector = collector.WherePasses(checkedOptionFilter);
            }

            return FilterByFamilyAndType(
                collector: collector,
                familyName: familyName,
                typeName: typeName);
        }
    }
}

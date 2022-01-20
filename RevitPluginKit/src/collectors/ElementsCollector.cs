namespace RevitPluginKit.Collectors
{
    using System.Collections.Generic;
    using Autodesk.Revit.DB;

    /// <summary>
    /// A class containing methods for quickly finding elements in the Revit model.
    /// <para>Supports both collection of element types and collection of element instances.</para>
    /// </summary>
    public class ElementsCollector
    {
        /// <summary>
        /// Collect Revit model element instances by category.
        /// <para>Specify document(model), element type category and optional parameters to collect element instances.</para>
        /// </summary>
        /// <typeparam name="T">
        /// Revit category (For example: Element). The function will search for elements in the model and return a list of the specified type "T".
        /// <para>The most versatile returnable entity for element instances is "Element" (Autodesk.Revit.DB.Element).</para>
        /// </typeparam>
        /// <param name="document">
        /// Current revit document instance.
        /// <para>It is possible to pass any document loaded to the current model (to search for elements in the specified document).</para>
        /// </param>
        /// <param name="category">
        /// Revit BuiltIn category to collect.
        /// <para>Example: <c>BuiltInCategory.OST_Walls</c>.</para>
        /// </param>
        /// <param name="familyName">
        /// Optional parameter: if necessary, specify the name of the family of the elements to be collected.
        /// <para>Please note that some categories of elements do not have a family name - as a result, an attempt to collect by family name in some situations may not have an effect.</para>
        /// </param>
        /// <param name="typeName">
        /// Optional parameter: if necessary, specify the type name of the elements to be collected.
        /// </param>
        /// <param name="levelIdsToFilterBy">
        /// Optional parameter: if necessary, specify list of level ids of the elements to be collected.
        /// <para>List elements correspond to class instances of Autodesk.Revit.DB.ElementId.</para>
        /// </param>
        /// <param name="useOptionFilter">
        /// Optional parameter: indicate whether it is necessary to use an option filter.
        /// <para>If useOptionFilter equals false => then - items from the currently active option will be collected.</para>
        /// </param>
        /// <param name="optionFilter">
        /// Optional parameter: specify option filter.
        /// <para>If useOptionFilter equals true and optionFilter equals null => then - items from the currently active option will be collected.</para>
        /// </param>
        /// <returns>
        /// Returns the list of Revit elements or other specified Revit entity.
        /// <para>The type of the returned entity is specified in the generic type "T".</para>
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
        /// Collect Revit model element types by category.
        /// <para>Specify document(model), element type category and optional parameters to collect element types.</para>
        /// </summary>
        /// <typeparam name="T">
        /// Revit category (For example: Element). The function will search for elements in the model and return a list of the specified type "T".
        /// <para>The most versatile returnable entity is Element (Autodesk.Revit.DB.Element).</para>
        /// <para>Also, when collecting element types, you should pay attention to specific standard type entities such as:
        /// Autodesk.Revit.DB.WallType, Autodesk.Revit.DB.FloorType, Autodesk.Revit.DB.CeilingType etc.</para>
        /// </typeparam>
        /// <param name="document">
        /// Current revit document instance.
        /// <para>It is possible to pass any document loaded to the current model (to search for elements in the specified document).</para>
        /// </param>
        /// <param name="category">
        /// Revit BuiltIn category to collect.
        /// <para>Example: <c>BuiltInCategory.OST_Walls</c>.</para>
        /// </param>
        /// <param name="familyName">
        /// Optional parameter: if necessary, specify the name of the family of the elements to be collected.
        /// <para>Please note that some categories of elements do not have a family name - as a result, an attempt to collect by family name in some situations may not have an effect.</para>
        /// </param>
        /// <param name="typeName">
        /// Optional parameter: if necessary, specify the type name of the elements to be collected.
        /// </param>
        /// <returns>
        /// Returns the list of Revit elements or other specified Revit entity.
        /// <para>The type of the returned entity is specified in the generic type "T".</para>
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

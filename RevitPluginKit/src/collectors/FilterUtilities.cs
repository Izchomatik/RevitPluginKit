namespace RevitPluginKit.Collectors
{
    using System.Collections.Generic;
    using System.Linq;
    using Autodesk.Revit.DB;

    /// <summary>
    /// A set of internal methods needed to work with filters.
    /// </summary>
    /// <typeparam name="T"> Revit category (For example: Element). </typeparam>
    internal class FilterUtilities<T>
    {
        /// <summary>
        /// Method used to apply the set of filters to instance collector: option filter, family name filter, type name filter, levels filter.
        /// </summary>
        /// <param name="document"> Current revit document instance. </param>
        /// <param name="collector"> Revit API FilteredElementCollector. </param>
        /// <param name="familyName"> Name of the family of the elements to be collected. </param>
        /// <param name="typeName"> Type name of the elements to be collected. </param>
        /// <param name="levelIdsToFilterBy"> List of level ids of the elements to be collected. </param>
        /// <param name="useOptionFilter"> A bool value that determines whether it is necessary to filter by Revit option. </param>
        /// <param name="optionFilter"> Incoming option filter to be checked. </param>
        /// <returns>
        /// Revit API FilteredElementCollector with option filter applied (if needed).
        /// </returns>
        internal static List<T> AddInstanceFilters(
            Document document,
            FilteredElementCollector collector,
            string familyName,
            string typeName,
            List<ElementId> levelIdsToFilterBy,
            bool useOptionFilter,
            ElementDesignOptionFilter optionFilter)
        {
            AddOptionFilter(
                document: document,
                collector: collector,
                useOptionFilter: useOptionFilter,
                optionFilter: optionFilter);
            return ApplyInstanceFilters(
                collector: collector,
                familyName: familyName,
                typeName: typeName,
                levelIdsToFilterBy: levelIdsToFilterBy);
        }

        /// <summary>
        /// Method used to apply the set of filters to type collector: family name filter, type name filter.
        /// </summary>
        /// <param name="collector"> Revit API FilteredElementCollector. </param>
        /// <param name="familyName"> Name of the family of the elements to be collected. </param>
        /// <param name="typeName"> Type name of the elements to be collected. </param>
        /// <returns>
        /// Revit API FilteredElementCollector with option filter applied (if needed).
        /// </returns>
        internal static List<T> AddTypeFilters(
            FilteredElementCollector collector,
            string familyName,
            string typeName)
        {
            return ApplyTypeFilters(
                collector: collector,
                familyName: familyName,
                typeName: typeName);
        }

        /// <summary>
        /// Filter elements by option filter.
        /// </summary>
        private static FilteredElementCollector AddOptionFilter(
            Document document,
            FilteredElementCollector collector,
            bool useOptionFilter,
            ElementDesignOptionFilter optionFilter)
        {
            if (useOptionFilter == true)
            {
                if (optionFilter == null)
                {
                    ElementId activeOptionID = DesignOption.GetActiveDesignOptionId(document);
                    optionFilter = new ElementDesignOptionFilter(activeOptionID);
                }

                collector.WherePasses(optionFilter);
            }

            return collector;
        }

        /// <summary>
        /// Filter instance elements by set of parameters.
        /// </summary>
        private static List<T> ApplyInstanceFilters(
            IEnumerable<Element> collector,
            string familyName,
            string typeName,
            List<ElementId> levelIdsToFilterBy)
        {
            if (familyName != null)
            {
                collector = collector.Where(i => ((FamilyInstance)i).Symbol.Family.Name.Equals(familyName));
            }

            if (typeName != null)
            {
                collector = collector.Where(i => i.Name.Equals(typeName));
            }

            if (levelIdsToFilterBy != null)
            {
                collector = collector.Where(i => levelIdsToFilterBy.Contains(i.LevelId));
            }

            return collector.Cast<T>().ToList();
        }

        /// <summary>
        /// Filter type elements by set of parameters.
        /// </summary>
        private static List<T> ApplyTypeFilters(
            IEnumerable<Element> collector,
            string familyName,
            string typeName)
        {
            if (familyName != null)
            {
                collector = collector.Where(i => ((FamilySymbol)i).FamilyName.Equals(familyName));
            }

            if (typeName != null)
            {
                collector = collector.Where(i => i.Name.Equals(typeName));
            }

            return collector.Cast<T>().ToList();
        }
    }
}

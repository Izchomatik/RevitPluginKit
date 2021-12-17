namespace RevitPluginKit.Collectors
{
    using System.Collections.Generic;
    using System.Linq;
    using Autodesk.Revit.DB;

    /// <summary>
    /// A set of internal methods needed to work with filters.
    /// </summary>
    internal class FilterUtilities
    {
        /// <summary>
        /// Method for verifying the incoming option filter.
        /// </summary>
        /// <param name="document"> Current revit document instance. </param>
        /// <param name="optionFilter"> Incoming option filter to be checked. </param>
        /// <returns>
        /// Checked option filter.
        /// </returns>
        internal static ElementDesignOptionFilter CheckOptionFilter(Document document, ElementDesignOptionFilter optionFilter)
        {
            if (optionFilter == null)
            {
                ElementId activeOptionID = DesignOption.GetActiveDesignOptionId(document);
                optionFilter = new ElementDesignOptionFilter(activeOptionID);
            }

            return optionFilter;
        }

        /// <summary>
        /// Filter elements by family name and/or type name.
        /// </summary>
        /// <param name="collector"> Revit API FilteredElementCollector. </param>
        /// <param name="familyName"> Name of the family of the elements to be collected. </param>
        /// <param name="typeName"> Type name of the elements to be collected. </param>
        /// <returns>
        /// Returns the list of Revit elements (Element).
        /// </returns>
        internal static List<Element> FilterByFamilyAndType(
            FilteredElementCollector collector,
            string familyName,
            string typeName)
        {
            if (familyName != null && typeName != null)
            {
                return collector
                    .Cast<FamilyInstance>()
                    .Where(i => i.Symbol.Family.Name.Equals(familyName) && i.Name.Equals(typeName))
                    .Cast<Element>()
                    .ToList();
            }
            else if (familyName != null)
            {
                return collector
                    .Cast<FamilyInstance>()
                    .Where(i => i.Symbol.Family.Name.Equals(familyName))
                    .Cast<Element>()
                    .ToList();
            }
            else if (typeName != null)
            {
                return collector
                    .Where(i => i.Name.Equals(typeName))
                    .Cast<Element>()
                    .ToList();
            }
            else
            {
                return collector
                    .Cast<Element>()
                    .ToList();
            }
        }
    }
}

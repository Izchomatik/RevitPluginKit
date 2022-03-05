namespace RevitPluginKit.Wpf
{
    using System.Collections.Generic;
    using System.Windows.Controls;

    /// <summary>
    /// A set of tools designed to work with ObservableItem elements.
    /// </summary>
    /// <typeparam name="T">
    /// The Type of the element that must be stored in the ObservableItem for further custom function interactions.
    /// </typeparam>
    public class ObservableItemUtilities<T>
    {
        /// <summary>
        /// Changes the IsChecked Boolean values of the ObservableItem List to the specified custom value.
        /// </summary>
        /// <param name="observableItems">
        /// List of ObservableItems whose IsChecked value needs to be changed.
        /// </param>
        /// <param name="requiredValue">
        /// Required value of the IsChecked property.
        /// </param>
        public static void IsCheckedChange(
            List<ObservableItem<T>> observableItems,
            bool requiredValue)
        {
            foreach (ObservableItem<T> observableItem in observableItems)
            {
                observableItem.IsChecked = requiredValue;
            }
        }

        /// <summary>
        /// Toggles the IsChecked booleans of the ListBox sender as an ObservableItem List.
        /// </summary>
        /// <param name="sender">
        /// WPF sender object as ListBox.
        /// </param>
        public static void SelectionIsCheckedToggle(object sender)
        {
            ListBox itemList = sender as ListBox;
            var selectedItems = itemList.SelectedItems;
            if (selectedItems != null && selectedItems.Count > 0)
            {
                foreach (var item in selectedItems)
                {
                    ObservableItem<T> observableItem = item as ObservableItem<T>;
                    observableItem.IsChecked = !observableItem.IsChecked;
                }
            }
        }
    }
}

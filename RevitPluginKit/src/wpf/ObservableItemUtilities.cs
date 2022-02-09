namespace RevitPluginKit.Wpf
{
    using System.Collections.Generic;
    using System.Windows.Controls;

    class ObservableItemUtilities<T>
    {
        public static void ChangeAllItems(
            List<ObservableItem<T>> observableItems,
            bool requiredValue)
        {
            foreach (ObservableItem<T> observableItem in observableItems)
            {
                observableItem.IsChecked = requiredValue;
            }
        }

        public static void SelectionClick(object sender)
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

namespace RevitPluginKit.Wpf
{
    using System.Collections.Generic;
    using System.Windows.Controls;

    /// <summary>
    /// A set of tools designed to work with ObservableNode elements.
    /// </summary>
    /// <typeparam name="T">
    /// The Type of the element that must be stored in the child ObservableItem elements for further custom function interactions.
    /// </typeparam>
    public class ObservableNodeUtilities<T>
    {
        /// <summary>
        /// Changes the IsChecked Boolean values of the ObservableNode List to the specified custom value.
        /// </summary>
        /// <param name="observableItems">
        /// List of ObservableNodes whose IsChecked value needs to be changed.
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
        /// Toggles the IsChecked booleans of the ListBox sender as an ObservableNode List.
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
                foreach (var node in selectedItems)
                {
                    ObservableNode<T> observableNode = node as ObservableNode<T>;
                    observableNode.IsChecked = !observableNode.IsChecked;
                }
            }
        }

        /// <summary>
        /// Creates a list of nodes from ObservableItems in the form of a tree based on ObservableItem fields: Section and SubSection.
        /// </summary>
        /// <param name="observableItems">
        /// List of elements from which you need to create a Node tree.
        /// </param>
        /// <returns>
        /// List of organized Nodes for use in WPF.
        /// </returns>
        public List<ObservableNode<T>> CreateNodeTree(List<ObservableItem<T>> observableItems)
        {
            List<ObservableNode<T>> nodes = new List<ObservableNode<T>>();
            foreach (ObservableItem<T> observableItem in observableItems)
            {
                string section = observableItem.Section;
                string subSection = observableItem.SubSection;
                if (section == null)
                {
                    section = string.Empty;
                }

                if (subSection == null || subSection == string.Empty)
                {
                    this.AddItemToNode(
                        nodes: ref nodes,
                        observableItem: observableItem,
                        section: section);
                }
                else
                {
                    ObservableNode<T> node = nodes.Find(i => i.Name.Equals(section));
                    if (node != null)
                    {
                        List<ObservableNode<T>> childNodes = node.ChildNodes;
                        this.AddItemToNode(
                            nodes: ref childNodes,
                            observableItem: observableItem,
                            section: subSection);
                    }
                    else
                    {
                        node = new ObservableNode<T>(name: section);
                        ObservableNode<T> subNode = new ObservableNode<T>(name: subSection);
                        subNode.AddChildItem(observableItem);
                        node.AddChildNode(subNode);
                        nodes.Add(node);
                    }
                }
            }

            return nodes;
        }

        /// <summary>
        /// Add ObservableItem to Node.
        /// </summary>
        private void AddItemToNode(
            ref List<ObservableNode<T>> nodes,
            ObservableItem<T> observableItem,
            string section)
        {
            ObservableNode<T> node = nodes.Find(i => i.Name.Equals(section));
            if (node != null)
            {
                node.AddChildItem(observableItem);
            }
            else
            {
                node = new ObservableNode<T>(name: section);
                node.AddChildItem(observableItem);
                nodes.Add(node);
            }
        }
    }
}

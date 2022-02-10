namespace RevitPluginKit.Wpf
{
    using System.Collections.Generic;
    using System.ComponentModel;

    /// <summary>
    /// An observable Node class required for easy interaction with WPF tree structure elements.
    /// </summary>
    /// <typeparam name="T">
    /// The Type of the element that must be stored in the child ObservableItem elements for further custom function interactions.
    /// </typeparam>
    public class ObservableNode<T> : INotifyPropertyChanged
    {
        private string name;
        private bool isChecked;

        /// <summary>
        /// Initializes a new instance of the <see cref="ObservableNode{T}"/> class.
        /// </param>
        /// <param name="name">
        /// Specify the string observable name of this ObservableNode.
        /// </param>
        /// <param name="isChecked">
        /// Optional parameter: if necessary, specify the bool observable value of this ObservableNode.
        /// </param>
        public ObservableNode(
            string name,
            bool isChecked = false)
        {
            this.name = name;
            this.isChecked = isChecked;
        }

        /// <inheritdoc/>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets name value of the ObservableNode.
        /// </summary>
        /// <value>
        /// String observable value. For example, it is often used as a changeable Node name in lists and similar.
        /// </value>
        public string Name
        {
            get => this.name;
            set
            {
                this.name = value;
                this.OnPropertyChanged(this, "Name");
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this ObservableNode control has been checked.
        /// </summary>
        /// <value>
        /// Boolean value indicating whether the Node element is checked.
        /// </value>
        public bool IsChecked
        {
            get => this.isChecked;
            set
            {
                this.isChecked = value;
                this.OnPropertyChanged(this, "IsChecked");
            }
        }

        /// <summary>
        /// Gets a list of child ObservableNode elements.
        /// </summary>
        /// <value>
        /// List of child ObservableNode elements.
        /// </value>
        public List<ObservableNode<T>> ChildNodes { get; }

        /// <summary>
        /// Gets a list of child ObservableItem elements.
        /// </summary>
        /// <value>
        /// List of child ObservableItem elements.
        /// </value>
        public List<ObservableItem<T>> ChildItems { get; }

        /// <summary>
        /// Adds a new child ObservableNode to the current ObservableNode List.
        /// </summary>
        /// <param name="newChildNode">
        /// New ObservableNode to add.
        /// </param>
        public void AddChildNode(ObservableNode<T> newChildNode)
        {
            this.ChildNodes.Add(newChildNode);
        }

        /// <summary>
        /// Removes a child ObservableNode from the current ObservableNode List.
        /// </summary>
        /// <param name="childNode">
        /// ObservableNode to remove.
        /// </param>
        public void RemoveChildNode(ObservableNode<T> childNode)
        {
            this.ChildNodes.Remove(childNode);
        }

        /// <summary>
        /// Adds a new child ObservableItem to the current ObservableItem List.
        /// </summary>
        /// <param name="newChildItem">
        /// New ObservableItem to add.
        /// </param>
        public void AddChildItem(ObservableItem<T> newChildItem)
        {
            this.ChildItems.Add(newChildItem);
        }

        /// <summary>
        /// Removes a child ObservableItem from the current ObservableItem List.
        /// </summary>
        /// <param name="childItem">
        /// ObservableItem to remove.
        /// </param>
        public void RemoveChildItem(ObservableItem<T> childItem)
        {
            this.ChildItems.Remove(childItem);
        }

        /// <summary>
        /// Main method called when the target value changes.
        /// </summary>
        private void OnPropertyChanged(object sender, string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(sender, new PropertyChangedEventArgs(propertyName));
                if (propertyName == "IsChecked")
                {
                    this.ChildNodes.ForEach(childNode => childNode.IsChecked = this.isChecked);
                    this.ChildItems.ForEach(childItem => childItem.IsChecked = this.isChecked);
                }
            }
        }
    }
}

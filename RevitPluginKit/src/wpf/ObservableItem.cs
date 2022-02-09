namespace RevitPluginKit.Wpf
{
    using System.ComponentModel;

    /// <summary>
    /// An observable element class required for easy interaction with WPF elements that require a boolean value.
    /// <para>This element can be used to track user interaction with elements of the WPF environment such as a ListBox.
    /// For example, to track whether a user has checked a checkbox in one of the rows.
    /// In this case, you will need to refer in your ListBox to the List of ObservableItems, in the fields of which the elements of the Revit model are passed for storage.</para>
    /// </summary>
    /// <typeparam name="T">
    /// The Type of the element that must be stored in the ObservableItem for further custom function interactions.
    /// </typeparam>
    public class ObservableItem<T> : INotifyPropertyChanged
    {
        private string name;
        private int number;
        private bool isChecked;

        /// <summary>
        /// Initializes a new instance of the <see cref="ObservableItem{T}"/> class.
        /// </summary>
        /// <param name="element">
        /// Generic element stored in this ObservableItem.
        /// </param>
        /// <param name="name">
        /// Optional parameter: if necessary, specify the string observable name of this ObservableItem.
        /// </param>
        /// <param name="number">
        /// Optional parameter: if necessary, specify the int observable number of this ObservableItem.
        /// </param>
        /// <param name="isChecked">
        /// Optional parameter: if necessary, specify the bool observable value of this ObservableItem.
        /// </param>
        public ObservableItem(
            T element,
            string name = null,
            int number = 0,
            bool isChecked = false)
        {
            this.Element = element;
            this.name = name;
            this.number = number;
            this.isChecked = isChecked;
        }

        /// <inheritdoc/>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets name value of the ObservableItem.
        /// </summary>
        /// <value>
        /// String observable value. For example, it is often used as a changeable row name in lists and similar.
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
        /// Gets or sets number value of the ObservableItem.
        /// </summary>
        /// <value>
        /// Integer observable value. For example, it is often used as a serial number in lists and similar.
        /// </value>
        public int Number
        {
            get => this.number;
            set
            {
                this.number = value;
                this.OnPropertyChanged(this, "Number");
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this ObservableItem control has been checked.
        /// </summary>
        /// <value>
        /// Boolean value indicating whether the element is checked.
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
        /// Gets the stored generic element.
        /// </summary>
        /// <value>
        /// Generic T element stored in the current ObservableItem.
        /// </value>
        public T Element { get; }

        /// <summary>
        /// Main method called when the target value changes.
        /// </summary>
        private void OnPropertyChanged(
            object sender,
            string propertyName)
        {
            this.PropertyChanged?.Invoke(sender, new PropertyChangedEventArgs(propertyName: propertyName));
        }
    }
}

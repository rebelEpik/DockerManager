using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace DockerManager
{


    public class SortableBindingList<T> : BindingList<T>
    {
        private bool isSorted;
        private ListSortDirection sortDirection;
        private PropertyDescriptor sortProperty;

        protected override bool SupportsSortingCore => true;
        protected override bool IsSortedCore => isSorted;

        protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
        {
            var items = (List<T>)Items;
            var property = typeof(T).GetProperty(prop.Name);
            if (property != null)
            {
                items.Sort((x, y) =>
                {
                    var valueX = property.GetValue(x);
                    var valueY = property.GetValue(y);
                    return direction == ListSortDirection.Ascending
                        ? Comparer<object>.Default.Compare(valueX, valueY)
                        : Comparer<object>.Default.Compare(valueY, valueX);
                });
                isSorted = true;
                sortDirection = direction;
                sortProperty = prop;
                OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
            }
        }

        protected override void RemoveSortCore()
        {
            isSorted = false;
            sortProperty = null;
        }

        protected override ListSortDirection SortDirectionCore => sortDirection;
        protected override PropertyDescriptor SortPropertyCore => sortProperty;

        // Public method to sort the list
        public void Sort(string propertyName, ListSortDirection direction)
        {
            PropertyDescriptor prop = TypeDescriptor.GetProperties(typeof(T))[propertyName];
            ApplySortCore(prop, direction);
        }
    }
}
using Data_Structures_lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DataTypesLib
{

    public class ObservableList<T> : ListOnArray<T>
    {
        public ObservableList() : base()
        { 
        }

        public override void Add(T item)
        {
            base.Add(item);
            OnItemAdded(new  ItemChangedEventArgs<T>(item));
        }

        public override bool Remove(T item)
        {
            bool result = base.Remove(item);
            if (result)
            {
                OnItemRemoved(new ItemChangedEventArgs<T>(item));
            }
            return result;
        }

        public override void Insert(int index, T item)
        {
            base.Insert(index, item);
            OnItemInserted(new ItemChangedEventArgs<T>(item, index));
        }

        protected virtual void OnItemAdded(ItemChangedEventArgs<T> e)
        {
            ItemAdded?.Invoke(this, e);
        }

        protected virtual void OnItemRemoved(ItemChangedEventArgs<T> e)
        {
            ItemRemoved?.Invoke(this, e);
        }

        protected virtual void OnItemInserted(ItemChangedEventArgs<T> e)
        {
            ItemInserted?.Invoke(this, e);
        }

        public event EventHandler<ItemChangedEventArgs<T>> ItemAdded;
        public event EventHandler<ItemChangedEventArgs<T>> ItemRemoved;
        public event EventHandler<ItemChangedEventArgs<T>> ItemInserted;
    }
    public class ItemChangedEventArgs<T> : EventArgs 
    { 
        public T Item { get; }
        public int Index { get; }

        public ItemChangedEventArgs(T item, int index = -1)
        {
            Item = item;
            Index = index;
        }
    }
}

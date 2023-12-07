using CollectionInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures_lib
{
    public class ListOnArray : IList
    {
        private object[] array;
        private int count;

        public ListOnArray()
        {
            array = new object[4]; 
            count = 0;
        }

        public int Count => count;

        public bool IsReadOnly => false;

        public object this[int index]
        {
            get
            {
                if (index < 0 || index >= count)
                    throw new ArgumentOutOfRangeException(nameof(index));

                return array[index];
            }
            set
            {
                if (index < 0 || index >= count)
                    throw new ArgumentOutOfRangeException(nameof(index));

                array[index] = value;
            }
        }

        public void Add(object item)
        {
            if (count == array.Length)
            {
                Array.Resize(ref array, array.Length * 2);
            }

            array[count++] = item;
        }

        public void Clear()
        {
            Array.Clear(array, 0, count);
            count = 0;
        }

        public bool Contains(object item)
        {
            return Array.IndexOf(array, item, 0, count) != -1;
        }

        public void CopyTo(object[] destination, int index)
        {
            Array.Copy(array, 0, destination, index, count);
        }

        public bool Remove(object item)
        {
            int index = Array.IndexOf(array, item, 0, count);
            if (index != -1)
            {
                Array.Copy(array, index + 1, array, index, count - index - 1);
                count--;
                return true;
            }
            return false;
        }

        public int IndexOf(object item)
        {
            return Array.IndexOf(array, item, 0, count);
        }

        public void Insert(int index, object item)
        {
            if (index < 0 || index > count)
                throw new ArgumentOutOfRangeException(nameof(index));

            if (count == array.Length)
            {
                Array.Resize(ref array, array.Length * 2);
            }

            Array.Copy(array, index, array, index + 1, count - index);
            array[index] = item;
            count++;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= count)
                throw new ArgumentOutOfRangeException(nameof(index));

            Array.Copy(array, index + 1, array, index, count - index - 1);
            count--;
        }
    }
}

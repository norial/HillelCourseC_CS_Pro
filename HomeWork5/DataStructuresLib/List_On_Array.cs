using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures_lib
{
    public class List_On_Array
    {

        private object[] items;
        private int count;
        private const int defaultCapacity = 4;

        

        public int Count => count;

        public object this[int index]
        {
            get
            {
                if (index < 0 || index >= count)
                {
                    throw new IndexOutOfRangeException();
                }

                return items[index];
            }
            set
            {
                if (index < 0 || index >= count)
                {
                    throw new IndexOutOfRangeException();
                }

                items[index] = value;
            }
        }

        private void EnsureCapacity()
        {
            if (count == items.Length)
            {
                int newCapacity = items.Length * 2;
                Array.Resize(ref items, newCapacity);
            }
        }

        public void Add(object item)
        {
            EnsureCapacity();
            items[count++] = item;
        }

        public void Insert(int index, object item)
        {
            if (index < 0 || index > count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            EnsureCapacity();

            for (int i = count; i > index; i--)
            {
                items[i] = items[i - 1];
            }

            items[index] = item;
            count++;
        }

        public void Remove(object item)
        {
            int index = IndexOf(item);

            if (index != -1)
            {
                RemoveAt(index);
            }
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            for (int i = index; i < count - 1; i++)
            {
                items[i] = items[i + 1];
            }

            count--;
        }

        public void Clear()
        {
            items = new object[defaultCapacity];
            count = 0;
        }

        public bool Contains(object item)
        {
            return IndexOf(item) != -1;
        }

        public int IndexOf(object item)
        {
            for (int i = 0; i < count; i++)
            {
                if (Equals(items[i], item))
                {
                    return i;
                }
            }

            return -1;
        }

        public object[] ToArray()
        {
            object[] result = new object[count];
            Array.Copy(items, result, count);
            return result;
        }

        public void Reverse()
        {
            int left = 0;
            int right = count - 1;

            while (left < right)
            {
                object temp = items[left];
                items[left] = items[right];
                items[right] = temp;

                left++;
                right--;
            }
        }

        
        public List_On_Array()
        {
            items = new object[defaultCapacity];
        }

        public List_On_Array(int capacity)
        {
            items = new object[capacity];
        }
    }
}

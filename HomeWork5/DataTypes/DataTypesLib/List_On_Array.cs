using CollectionInterfaces;


namespace Data_Structures_lib
{
    public class ListOnArray<T> : CollectionInterfaces.IList<T>
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

        public T Value { get; init; }

        public void Add(T item)
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

        public bool Contains(T item)
        {
            return Array.IndexOf(array, item, 0, count) != -1;
        }

        public void CopyTo(T[] destination, int index)
        {
            Array.Copy(array, 0, destination, index, count);
        }

        public bool Remove(T item)
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

        public int IndexOf(T item)
        {
            return Array.IndexOf(array, item, 0, count);
        }

        public void Insert(int index, T item)
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

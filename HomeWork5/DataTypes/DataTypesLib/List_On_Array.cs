using CollectionInterfaces;
using System.Collections;

namespace Data_Structures_lib
{
    public class ListOnArray<T> : CollectionInterfaces.IList<T>
    {
        private T[] array;
        private int count;
        private int currentIndex = -1;
        public ListOnArray()
        {
            array = new T[4]; 
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

                array[index] = (T?)value;
            }
        }


        public T Value { get; init; }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                currentIndex = i;
                yield return array[i];
            }
            currentIndex = -1;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerable<T> Filter(Func<T, bool> predicate)
        {
            var result = new List<T>();
            for (int i = 0; i < count; i++)
            {
                if (predicate(array[i]))
                {
                    result.Add(array[i]);
                }
            }
            return result;
        }

        public IEnumerable<T> Skip(int count)
        {
            var result = new List<T>();
            for (int i = count; i < this.count; i++)
            {
                result.Add(array[i]);
            }
            return result;
        }

        public IEnumerable<T> Take(int count)
        {
            var result = new List<T>();
            for (int i = 0; i < count && i < this.count; i++)
            {
                result.Add(array[i]);
            }
            return result;
        }

        public IEnumerable<T> TakeWhile(Func<T, bool> predicate)
        {
            var result = new List<T>();
            for (int i = 0; i < this.count && predicate(array[i]); i++)
            {
                result.Add(array[i]);
            }
            return result;
        }

        public T First(Func<T, bool> predicate)
        {
            for (int i = 0; i < count; i++)
            {
                if (predicate(array[i]))
                {
                    return array[i];
                }
            }
            throw new InvalidOperationException("Sequence contains no matching element");
        }

        public T FirstOrDefault(Func<T, bool> predicate)
        {
            for (int i = 0; i < count; i++)
            {
                if (predicate(array[i]))
                {
                    return array[i];
                }
            }
            return default(T);
        }

        public T Last(Func<T, bool> predicate)
        {
            for (int i = count - 1; i >= 0; i--)
            {
                if (predicate(array[i]))
                {
                    return array[i];
                }
            }
            throw new InvalidOperationException("Sequence contains no matching element");
        }

        public T LastOrDefault(Func<T, bool> predicate)
        {
            for (int i = count - 1; i >= 0; i--)
            {
                if (predicate(array[i]))
                {
                    return array[i];
                }
            }
            return default(T);
        }

        public IEnumerable<TResult> Select<TResult>(Func<T, TResult> selector)
        {
            var result = new List<TResult>();
            for (int i = 0; i < count; i++)
            {
                result.Add(selector(array[i]));
            }
            return result;
        }

        public IEnumerable<TResult> SelectMany<TResult>(Func<T, IEnumerable<TResult>> selector)
        {
            var result = new List<TResult>();
            for (int i = 0; i < count; i++)
            {
                result.AddRange(selector(array[i]));
            }
            return result;
        }

        public bool All(Func<T, bool> predicate)
        {
            for (int i = 0; i < count; i++)
            {
                if (!predicate(array[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public bool Any(Func<T, bool> predicate)
        {
            for (int i = 0; i < count; i++)
            {
                if (predicate(array[i]))
                {
                    return true;
                }
            }
            return false;
        }

        public List<T> ToList()
        {
            return new List<T>(array);
        }
    public virtual void Add(T item)
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

        public virtual bool Remove(T item)
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

        public virtual void Insert(int index, T item)
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

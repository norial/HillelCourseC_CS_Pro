using CollectionInterfaces;
using System.Collections;
using System.Collections.Generic;


namespace Data_Structures_lib
{

     public class ArrayQueue<T> : IQueue<T> 
    {
        private T[] array;
        private int front;
        private int rear;
        private int count;
        private int currentIndex = -1;


        public ArrayQueue()
        {
            array = new T[4];
            front = 0;
            rear = -1;
            count = 0;
        }

        public int Count => count;

        public bool IsReadOnly => false;

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = front; i < front + count; i++)
            {
                currentIndex = i % array.Length;
                yield return array[currentIndex];
            }

            currentIndex = -1;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public ArrayQueue<T> Filter(Func<T, bool> predicate)
        {
            var result = new ArrayQueue<T>();
            T[] tempArray = ToArray();

            foreach (var item in tempArray)
            {
                if (predicate(item))
                {
                    result.Enqueue(item);
                }
            }

            return result;
        }

        public ArrayQueue<T> Skip(int count)
        {
            var result = new ArrayQueue<T>();
            T[] tempArray = ToArray();

            for (int i = count; i < tempArray.Length; i++)
            {
                result.Enqueue(tempArray[i]);
            }

            return result;
        }

        public ArrayQueue<T> Take(int count)
        {
            var result = new ArrayQueue<T>();
            T[] tempArray = ToArray();

            for (int i = 0; i < count && i < tempArray.Length; i++)
            {
                result.Enqueue(tempArray[i]);
            }

            return result;
        }

        public ArrayQueue<T> TakeWhile(Func<T, bool> predicate)
        {
            var result = new ArrayQueue<T>();
            T[] tempArray = ToArray();

            foreach (var item in tempArray)
            {
                if (predicate(item))
                {
                    result.Enqueue(item);
                }
                else
                {
                    break;
                }
            }

            return result;
        }

        public T First(Func<T, bool> predicate)
        {
            T[] tempArray = ToArray();

            foreach (var item in tempArray)
            {
                if (predicate(item))
                {
                    return item;
                }
            }

            throw new InvalidOperationException("Sequence contains no matching element");
        }

        public T FirstOrDefault(Func<T, bool> predicate)
        {
            T[] tempArray = ToArray();

            foreach (var item in tempArray)
            {
                if (predicate(item))
                {
                    return item;
                }
            }

            return default(T);
        }

        public T Last(Func<T, bool> predicate)
        {
            T[] tempArray = ToArray();
            T lastMatch = default(T);

            foreach (var item in tempArray)
            {
                if (predicate(item))
                {
                    lastMatch = item;
                }
            }

            if (EqualityComparer<T>.Default.Equals(lastMatch, default(T)))
            {
                throw new InvalidOperationException("Sequence contains no matching element");
            }

            return lastMatch;
        }

        public T LastOrDefault(Func<T, bool> predicate)
        {
            T[] tempArray = ToArray();
            T lastMatch = default(T);

            foreach (var item in tempArray)
            {
                if (predicate(item))
                {
                    lastMatch = item;
                }
            }

            return lastMatch;
        }

        public IEnumerable<TResult> Select<TResult>(Func<T, TResult> selector)
        {
            T[] tempArray = ToArray();
            return tempArray.Select(selector);
        }

        public IEnumerable<TResult> SelectMany<TResult>(Func<T, IEnumerable<TResult>> selector)
        {
            T[] tempArray = ToArray();
            return tempArray.SelectMany(selector);
        }

        public bool All(Func<T, bool> predicate)
        {
            T[] tempArray = ToArray();
            return tempArray.All(predicate);
        }

        public bool Any(Func<T, bool> predicate)
        {
            T[] tempArray = ToArray();
            return tempArray.Any(predicate);
        }

        public T[] ToArray()
        {
            T[] result = new T[count];
            Array.Copy(array, front, result, 0, count);
            return result;
        }

        public void Enqueue(T item)
        {
            if (count == array.Length)
                Array.Resize(ref array, array.Length * 2);

            array[++rear] = item;
            count++;
        }

        public T Dequeue()
        {
            if (count == 0)
                throw new InvalidOperationException("Черга порожня");

            T item = array[front++];
            count--;

            if (front == count)
            {
                Array.Copy(array, front, array, 0, count);
                front = 0;
                rear = count - 1;
            }

            return item;
        }

        public T Peek()
        {
            if (count == 0)
                throw new InvalidOperationException("Черга порожня");

            return array[front];
        }

        public void Clear()
        {
            Array.Clear(array, 0, count);
            front = 0;
            rear = -1;
            count = 0;
        }

        public bool Contains(T item)
        {
            return Array.IndexOf(array, item, front, count) != -1;
        }

        public void Add(T item)
        {
            Enqueue(item);
        }

        bool CollectionInterfaces.ICollection<T>.Remove(T item)
        {
            if (!Contains(item))
                throw new ArgumentException("Елемент не знайдено в черзі", nameof(item));

            int index = Array.IndexOf(array, item, front, count);
            Array.Copy(array, front, array, index, count - index - 1);
            count--;
            rear--;
            array[count] = default;
            return true;
        }

        public void CopyTo(T[] array, int index)
        {
            Array.Copy(this.array, front, array, index, count);
        }
    }
}



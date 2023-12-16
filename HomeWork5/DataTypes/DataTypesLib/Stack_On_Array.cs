using CollectionInterfaces;
using System.Collections;


namespace Data_Structures_lib
{
    public class ArrayStack<T> : IStack<T>
    { 
        private T[] array;
        private int top;
        private int count;
        private int currentIndex;

        public ArrayStack()
        {
            array = new T[4];
            top = -1;
            count = 0;
        }

        public int Count => count;
        public T Value { get; init; }
        public bool IsReadOnly => false;

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = top; i >= 0; i++)
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

        public ArrayStack<T> Filter(Func<T, bool> predicate)
        {
            var result = new ArrayStack<T>();
            T[] tempArray = ToArray();

            foreach (var item in tempArray)
            {
                if (predicate(item))
                {
                    result.Push(item);
                }
            }

            return (ArrayStack<T>)result.Reverse();
        }

        public ArrayStack<T> Skip(int count)
        {
            var result = new ArrayStack<T>();
            T[] tempArray = ToArray();

            for (int i = count; i < tempArray.Length; i++)
            {
                result.Push(tempArray[i]);
            }

            return (ArrayStack<T>)result.Reverse();
        }

        public ArrayStack<T> Take(int count)
        {
            var result = new ArrayStack<T>();
            T[] tempArray = ToArray();

            for (int i = 0; i < count && i < tempArray.Length; i++)
            {
                result.Push(tempArray[i]);
            }

            return (ArrayStack<T>)result.Reverse();
        }

        public ArrayStack<T> TakeWhile(Func<T, bool> predicate)
        {
            var result = new ArrayStack<T>();
            T[] tempArray = ToArray();

            foreach (var item in tempArray)
            {
                if (predicate(item))
                {
                    result.Push(item);
                }
                else
                {
                    break;
                }
            }

            return (ArrayStack<T>)result.Reverse();
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
            Array.Copy(array, result, count);
            return result;
        }
        public void Push(T item)
        {
            if (count == array.Length)
                Array.Resize(ref array, array.Length * 2);

            array[++top] = item;
            count++;
        }

        public T Pop()
        {
            if (count == 0)
                throw new InvalidOperationException("Stack is empty");

            var item = array[top--];
            count--;
            return item;
        }

        public T Peek()
        {
            if (count == 0)
                throw new InvalidOperationException("Stack is empty");

            return array[top];
        }

        public void Clear()
        {
            Array.Clear(array, 0, count);
            top = -1;
            count = 0;
        }

        public bool Contains(T item)
        {
            return Array.IndexOf(array, item, 0, count) != -1;
        }

        public void Add(T item)
        {
            Push(item);
        }

        bool CollectionInterfaces.ICollection<T>.Remove(T item)
        {
            if (!Contains(item))
                throw new ArgumentException("Can't find element at Stack", nameof(item));

            int index = Array.LastIndexOf(array, item, count - 1, count);
            Array.Copy(array, index + 1, array, index, count - index - 1);
            count--;
            array[count] = default;
            return true;
        }

        public void CopyTo(T[] array, int index)
        {
            Array.Copy(this.array, 0, array, index, count);
        }
    }
}

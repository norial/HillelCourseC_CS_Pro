using CollectionInterfaces;
using System.Collections;


namespace Data_Structures_lib
{
     public class SinglyLinkedList<T> : ISinglyLinkedList<T>
    {
        public class Node
        {
            public readonly T Data;
            public Node Next { get; set; }

            public Node(T data)
            {
                Data = data;
                Next = null;
            }
        }

        private Node first;
        private Node last;

        public int Count { get; private set; }

        public T FirstValue => first != null ? first.Data : default;
        public T LastValue => last != null ? last.Data : default;

        public IEnumerator<T> GetEnumerator()
        {
            Node current = first;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public SinglyLinkedList<T> Filter(Func<T, bool> predicate)
        {
            var result = new SinglyLinkedList<T>();
            Node current = first;

            while (current != null)
            {
                if (predicate(current.Data))
                {
                    result.Add(current.Data);
                }

                current = current.Next;
            }

            return result;
        }

        public SinglyLinkedList<T> Skip(int count)
        {
            var result = new SinglyLinkedList<T>();
            Node current = first;

            while (count > 0 && current != null)
            {
                count--;
                current = current.Next;
            }

            while (current != null)
            {
                result.Add(current.Data);
                current = current.Next;
            }

            return result;
        }

        public SinglyLinkedList<T> Take(int count)
        {
            var result = new SinglyLinkedList<T>();
            Node current = first;

            while (count > 0 && current != null)
            {
                result.Add(current.Data);
                current = current.Next;
                count--;
            }

            return result;
        }

        public SinglyLinkedList<T> TakeWhile(Func<T, bool> predicate)
        {
            var result = new SinglyLinkedList<T>();
            Node current = first;

            while (current != null && predicate(current.Data))
            {
                result.Add(current.Data);
                current = current.Next;
            }

            return result;
        }

        public T First(Func<T, bool> predicate)
        {
            Node current = first;

            while (current != null)
            {
                if (predicate(current.Data))
                {
                    return current.Data;
                }

                current = current.Next;
            }

            throw new InvalidOperationException("Sequence contains no matching element");
        }

        public T FirstOrDefault(Func<T, bool> predicate)
        {
            Node current = first;

            while (current != null)
            {
                if (predicate(current.Data))
                {
                    return current.Data;
                }

                current = current.Next;
            }

            return default(T);
        }

        public T Last(Func<T, bool> predicate)
        {
            Node current = first;
            Node lastMatch = null;

            while (current != null)
            {
                if (predicate(current.Data))
                {
                    lastMatch = current;
                }

                current = current.Next;
            }

            if (lastMatch != null)
            {
                return lastMatch.Data;
            }

            throw new InvalidOperationException("Sequence contains no matching element");
        }

        public T LastOrDefault(Func<T, bool> predicate)
        {
            Node current = first;
            Node lastMatch = null;

            while (current != null)
            {
                if (predicate(current.Data))
                {
                    lastMatch = current;
                }

                current = current.Next;
            }

            return lastMatch.Data ?? default(T);
        }

        public IEnumerable<TResult> Select<TResult>(Func<T, TResult> selector)
        {
            var result = new List<TResult>();
            Node current = first;

            while (current != null)
            {
                result.Add(selector(current.Data));
                current = current.Next;
            }

            return result;
        }

        public IEnumerable<TResult> SelectMany<TResult>(Func<T, IEnumerable<TResult>> selector)
        {
            var result = new List<TResult>();
            Node current = first;

            while (current != null)
            {
                result.AddRange(selector(current.Data));
                current = current.Next;
            }

            return result;
        }

        public bool All(Func<T, bool> predicate)
        {
            Node current = first;

            while (current != null)
            {
                if (!predicate(current.Data))
                {
                    return false;
                }

                current = current.Next;
            }

            return true;
        }

        public bool Any(Func<T, bool> predicate)
        {
            Node current = first;

            while (current != null)
            {
                if (predicate(current.Data))
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        public T[] ToArray()
        {
            var result = new List<T>();
            Node current = first;

            while (current != null)
            {
                result.Add(current.Data);
                current = current.Next;
            }

            return result.ToArray();
        }

        public List<T> ToList()
        {
            var result = new List<T>();
            Node current = first;

            while (current != null)
            {
                result.Add(current.Data);
                current = current.Next;
            }

            return result;
        }

        public void Add(T data)
        {
            Node newNode = new Node(data);

            if (first == null)
            {
                first = newNode;
                last = newNode;
            }
            else
            {
                last.Next = newNode;
                last = newNode;
            }

            Count++;
        }

        public void AddFirst(T data)
        {
            Node newNode = new Node(data);

            if (first == null)
            {
                first = newNode;
                last = newNode;
            }
            else
            {
                newNode.Next = first;
                first = newNode;
            }

            Count++;
        }

        public void Insert(int index, T data)
        {
            if (index < 0 || index > Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            if (index == Count)
            {
                Add(data);
                return;
            }

            Node newNode = new Node(data);

            if (index == 0)
            {
                AddFirst(data);
                return;
            }

            Node current = first;
            for (int i = 0; i < index - 1; i++)
            {
                current = current.Next;
            }

            newNode.Next = current.Next;
            current.Next = newNode;

            Count++;
        }

        public void Clear()
        {
            first = null;
            last = null;
            Count = 0;
        }

        public bool Contains(T data)
        {
            Node current = first;

            while (current != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Data, data))
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }
    }
}
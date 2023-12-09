using CollectionInterfaces;


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

        public Node First => first;
        public Node Last => last;

        public T FirstValue => first != null ? first.Data : default;
        public T LastValue => last != null ? last.Data : default;

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

        public T[] ToArray()
        {
            T[] result = new T[Count];
            Node current = first;

            for (int i = 0; i < Count; i++)
            {
                result[i] = current.Data;
                current = current.Next;
            }

            return result;
        }
    }
}
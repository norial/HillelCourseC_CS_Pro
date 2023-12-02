namespace CollectionInterfaces
{
    public interface ICollection
    {
        int Count { get; }
        bool IsReadOnly { get; }

        void Add(object item);
        void Clear();
        bool Contains(object item);
        void CopyTo(object[] array, int arrayIndex);
        bool Remove(object item);
    }

    public interface IList : ICollection
    {
        object this[int index] { get; set; }

        int IndexOf(object item);
        void Insert(int index, object item);
        void RemoveAt(int index);
    }

    public interface IQueue : ICollection
    {
        void Enqueue(object item);
        object Dequeue();
        object Peek();
    }

    public interface IStack : ICollection
    {
        void Push(object item);
        object Pop();
        object Peek();
    }

    public interface ISinglyLinkedList : ICollection
    {
        void AddFirst(object value);
        void Insert(int index, object value);
        object First { get; }
        object Last { get; }
        bool IsSynchronized { get; }
        object SyncRoot { get; }
    }

    public interface IBinarySearchTree : ICollection
    {
        int[] ToArray();
        IEnumerable<int> InOrderTraversal();
        int Count { get; }
    }
}



namespace CollectionInterfaces
{
    public interface ISinglyLinkedList<T> : IEnumerable<T>
    {
        void AddFirst(T item);
        void Insert(int index, T item);
        T FirstValue { get; }
        T LastValue { get; }
    }
}

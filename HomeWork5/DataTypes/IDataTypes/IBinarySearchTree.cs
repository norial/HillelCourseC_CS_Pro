﻿
namespace CollectionInterfaces
{
    public interface IBinarySearchTree<T> : IEnumerable<T>
    {
        T[] ToArray();
        IEnumerable<T> InOrderTraversal();
        int Count { get; }
    }
}

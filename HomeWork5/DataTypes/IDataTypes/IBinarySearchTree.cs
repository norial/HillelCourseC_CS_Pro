
namespace CollectionInterfaces
{
    public interface IBinarySearchTree<T> 
    {
        T[] ToArray();
        IEnumerable<T> InOrderTraversal();
        int Count { get; }
    }
}

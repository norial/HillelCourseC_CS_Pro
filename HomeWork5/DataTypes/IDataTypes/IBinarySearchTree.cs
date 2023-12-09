using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionInterfaces
{
    public interface IBinarySearchTree<T> 
    {
        T[] ToArray();
        IEnumerable<T> InOrderTraversal();
        int Count { get; }
    }
}

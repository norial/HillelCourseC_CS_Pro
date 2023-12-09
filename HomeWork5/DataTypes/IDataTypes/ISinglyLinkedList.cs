using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CollectionInterfaces
{
    public interface ISinglyLinkedList<T> 
    {
        void AddFirst(T item);
        void Insert(int index, T item);
        T FirstValue { get; }
        T LastValue { get; }
    }
}

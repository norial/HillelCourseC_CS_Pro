using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionInterfaces
{
    public interface IList<T> : ICollection<T>
    {
        object this[int index] { get; set; }

        int IndexOf(T item);
        void Insert(int index, T item);
        void RemoveAt(int index);
    }
}

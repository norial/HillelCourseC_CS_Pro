using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionInterfaces
{
    public interface IStack<T> : ICollection<T>
    {
        void Push(T item);
        T Pop();
        T Peek();
    }
}

using CollectionInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures_lib
{
    public class ArrayStack : IStack
    {
        private object[] array;
        private int top;
        private int count;

        public ArrayStack()
        {
            array = new object[4];
            top = -1;
            count = 0;
        }

        public int Count => count;

        public bool IsReadOnly => false;

        public void Push(object item)
        {
            if (count == array.Length)
                Array.Resize(ref array, array.Length * 2);

            array[++top] = item;
            count++;
        }

        public object Pop()
        {
            if (count == 0)
                throw new InvalidOperationException("Stack is empty");

            var item = array[top--];
            count--;
            return item;
        }

        public object Peek()
        {
            if (count == 0)
                throw new InvalidOperationException("Stack is empty");

            return array[top];
        }

        public void Clear()
        {
            Array.Clear(array, 0, count);
            top = -1;
            count = 0;
        }

        public bool Contains(object item)
        {
            return Array.IndexOf(array, item, 0, count) != -1;
        }

        public void Add(object item)
        {
            Push(item);
        }

        bool ICollection.Remove(object item)
        {
            if (!Contains(item))
                throw new ArgumentException("Can't find element at Stack", nameof(item));

            int index = Array.LastIndexOf(array, item, count - 1, count);
            Array.Copy(array, index + 1, array, index, count - index - 1);
            count--;
            array[count] = null;
            return true;
        }

        public void CopyTo(object[] array, int index)
        {
            Array.Copy(this.array, 0, array, index, count);
        }

        public object[] ToArray()
        {
            var result = new object[count];
            Array.Copy(array, result, count);
            return result;
        }
    }
}

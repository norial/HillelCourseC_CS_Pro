using CollectionInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures_lib
{
    public class ArrayStack<T> : IStack<T>
    { 
        private T[] array;
        private int top;
        private int count;

        public ArrayStack()
        {
            array = new T[4];
            top = -1;
            count = 0;
        }

        public int Count => count;
        public T Value { get; init; }
        public bool IsReadOnly => false;

        public void Push(T item)
        {
            if (count == array.Length)
                Array.Resize(ref array, array.Length * 2);

            array[++top] = item;
            count++;
        }

        public T Pop()
        {
            if (count == 0)
                throw new InvalidOperationException("Stack is empty");

            var item = array[top--];
            count--;
            return item;
        }

        public T Peek()
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

        public bool Contains(T item)
        {
            return Array.IndexOf(array, item, 0, count) != -1;
        }

        public void Add(T item)
        {
            Push(item);
        }

        bool CollectionInterfaces.ICollection<T>.Remove(T item)
        {
            if (!Contains(item))
                throw new ArgumentException("Can't find element at Stack", nameof(item));

            int index = Array.LastIndexOf(array, item, count - 1, count);
            Array.Copy(array, index + 1, array, index, count - index - 1);
            count--;
            array[count] = default;
            return true;
        }

        public void CopyTo(T[] array, int index)
        {
            Array.Copy(this.array, 0, array, index, count);
        }

        public T[] ToArray()
        {
            var result = new T[count];
            Array.Copy(array, result, count);
            return result;
        }
    }
}

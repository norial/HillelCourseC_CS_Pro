using CollectionInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures_lib
{

    public class ArrayQueue<T> : IQueue<T> 
    {
        private T[] array;
        private int front;
        private int rear;
        private int count;
        private T item;

        public ArrayQueue()
        {
            array = new T[4];
            front = 0;
            rear = -1;
            count = 0;
        }

        public int Count => count;

        public bool IsReadOnly => false;

        public void Enqueue(T item)
        {
            if (count == array.Length)
                Array.Resize(ref array, array.Length * 2);

            array[++rear] = item;
            count++;
        }

        public T Dequeue()
        {
            if (count == 0)
                throw new InvalidOperationException("Черга порожня");

            T item = array[front++];
            count--;

            if (front == count)
            {
                Array.Copy(array, front, array, 0, count);
                front = 0;
                rear = count - 1;
            }

            return item;
        }

        public T Peek()
        {
            if (count == 0)
                throw new InvalidOperationException("Черга порожня");

            return array[front];
        }

        public void Clear()
        {
            Array.Clear(array, 0, count);
            front = 0;
            rear = -1;
            count = 0;
        }

        public bool Contains(T item)
        {
            return Array.IndexOf(array, item, front, count) != -1;
        }

        public void Add(T item)
        {
            Enqueue(item);
        }

        bool CollectionInterfaces.ICollection<T>.Remove(T item)
        {
            if (!Contains(item))
                throw new ArgumentException("Елемент не знайдено в черзі", nameof(item));

            int index = Array.IndexOf(array, item, front, count);
            Array.Copy(array, front, array, index, count - index - 1);
            count--;
            rear--;
            array[count] = default;
            return true;
        }

        public void CopyTo(T[] array, int index)
        {
            Array.Copy(this.array, front, array, index, count);
        }

        public T[] ToArray()
        {
            var result = new T[count];
            Array.Copy(array, front, result, 0, count);
            return result;
        }
    }
}



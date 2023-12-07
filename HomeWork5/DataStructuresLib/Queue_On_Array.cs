using CollectionInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures_lib
{

    public class ArrayQueue : IQueue
    {
        private object[] array;
        private int front;
        private int rear;
        private int count;

        public ArrayQueue()
        {
            array = new object[4];
            front = 0;
            rear = -1;
            count = 0;
        }

        public int Count => count;

        public bool IsReadOnly => false;

        public void Enqueue(object item)
        {
            if (count == array.Length)
                Array.Resize(ref array, array.Length * 2);

            array[++rear] = item;
            count++;
        }

        public object Dequeue()
        {
            if (count == 0)
                throw new InvalidOperationException("Черга порожня");

            var item = array[front++];
            count--;

            if (front == count)
            {
                Array.Copy(array, front, array, 0, count);
                front = 0;
                rear = count - 1;
            }

            return item;
        }

        public object Peek()
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

        public bool Contains(object item)
        {
            return Array.IndexOf(array, item, front, count) != -1;
        }

        public void Add(object item)
        {
            Enqueue(item);
        }

        bool ICollection.Remove(object item)
        {
            if (!Contains(item))
                throw new ArgumentException("Елемент не знайдено в черзі", nameof(item));

            int index = Array.IndexOf(array, item, front, count);
            Array.Copy(array, front, array, index, count - index - 1);
            count--;
            rear--;
            array[count] = null;
            return true;
        }

        public void CopyTo(object[] array, int index)
        {
            Array.Copy(this.array, front, array, index, count);
        }

        public object[] ToArray()
        {
            var result = new object[count];
            Array.Copy(array, front, result, 0, count);
            return result;
        }
    }
}



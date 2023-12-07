using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures_lib
{
    internal class QueueOnArray
    {
        public class Queue
        {
            private Node front;
            private Node rear;

            public int Count { get; private set; }

            public void Enqueue(object data)
            {
                Node newNode = new Node(data);

                if (rear == null)
                {
                    front = newNode;
                    rear = newNode;
                }
                else
                {
                    rear.Next = newNode;
                    rear = newNode;
                }

                Count++;
            }

            public object Dequeue()
            {
                if (front == null)
                {
                    throw new InvalidOperationException("Queue is empty");
                }

                object data = front.Data;
                front = front.Next;

                if (front == null)
                {
                    rear = null;
                }

                Count--;

                return data;
            }

            public void Clear()
            {
                front = null;
                rear = null;
                Count = 0;
            }

            public bool Contains(object data)
            {
                Node current = front;

                while (current != null)
                {
                    if (Equals(current.Data, data))
                    {
                        return true;
                    }

                    current = current.Next;
                }

                return false;
            }

            public object Peek()
            {
                if (front == null)
                {
                    throw new InvalidOperationException("Queue is empty");
                }

                return front.Data;
            }

            public object[] ToArray()
            {
                object[] result = new object[Count];
                Node current = front;

                for (int i = 0; i < Count; i++)
                {
                    result[i] = current.Data;
                    current = current.Next;
                }

                return result;
            }

            private class Node
            {
                public object Data;
                public Node Next;

                public Node(object data)
                {
                    Data = data;
                    Next = null;
                }
            }
        }
    }
}


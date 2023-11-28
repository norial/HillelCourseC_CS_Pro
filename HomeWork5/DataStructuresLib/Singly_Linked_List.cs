using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures_lib
{
    public class Node
    {
        public object Data;
        public Node Next;

        public Node(object data)
        {
            Data = data;
            Next = null;
        }
    }

    public class SinglyLinkedList
    {
        private Node first;
        private Node last;

        public int Count { get; private set; }

        public Node First => first;
        public Node Last => last;

        public void Add(object data)
        {
            Node newNode = new Node(data);

            if (first == null)
            {
                first = newNode;
                last = newNode;
            }
            else
            {
                last.Next = newNode;
                last = newNode;
            }

            Count++;
        }

        public void AddFirst(object data)
        {
            Node newNode = new Node(data);

            if (first == null)
            {
                first = newNode;
                last = newNode;
            }
            else
            {
                newNode.Next = first;
                first = newNode;
            }

            Count++;
        }

        public void Insert(int index, object data)
        {
            if (index < 0 || index > Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            if (index == Count)
            {
                Add(data);
                return;
            }

            Node newNode = new Node(data);

            if (index == 0)
            {
                AddFirst(data);
                return;
            }

            Node current = first;
            for (int i = 0; i < index - 1; i++)
            {
                current = current.Next;
            }

            newNode.Next = current.Next;
            current.Next = newNode;

            Count++;
        }

        public void Clear()
        {
            first = null;
            last = null;
            Count = 0;
        }

        public bool Contains(object data)
        {
            Node current = first;

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

        public object[] ToArray()
        {
            object[] result = new object[Count];
            Node current = first;

            for (int i = 0; i < Count; i++)
            {
                result[i] = current.Data;
                current = current.Next;
            }

            return result;
        }
    }
}

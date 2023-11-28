using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures_lib
{
    public class ArrayStack
    {
        private Node top;

        public int Count { get; private set; }

        public void Push(object data)
        {
            Node newNode = new Node(data);
            newNode.Next = top;
            top = newNode;
            Count++;
        }

        public object Pop()
        {
            if (top == null)
            {
                throw new InvalidOperationException("Stack is empty");
            }

            object data = top.Data;
            top = top.Next;
            Count--;

            return data;
        }

        public void Clear()
        {
            top = null;
            Count = 0;
        }

        public bool Contains(object data)
        {
            Node current = top;

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
            if (top == null)
            {
                throw new InvalidOperationException("Stack is empty");
            }

            return top.Data;
        }

        public object[] ToArray()
        {
            object[] result = new object[Count];
            Node current = top;

            for (int i = Count - 1; i >= 0; i--)
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

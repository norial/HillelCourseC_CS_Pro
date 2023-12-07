using CollectionInterfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures_lib
{
    public class BinarySearchTree
    {
        private class Node
        {
            public readonly int Value;
            public Node Left { get; set; }
            public Node Right { get; set; }

            public Node(int value)
            {
                Value = value;
                Left = null;
                Right = null;
            }
        }

        private Node root;
        private int count;

        public BinarySearchTree()
        {
            root = null;
            count = 0;
        }

        public void Add(int value)
        {
            root = AddRecursive(root, value);
            count++;
        }

        private Node AddRecursive(Node node, int value)
        {
            if (node == null)
            {
                return new Node(value);
            }

            if (value < node.Value)
            {
                node.Left = AddRecursive(node.Left, value);
            }
            else if (value > node.Value)
            {
                node.Right = AddRecursive(node.Right, value);
            }

            return node;
        }

        public bool Contains(int value)
        {
            return ContainsRecursive(root, value);
        }

        private bool ContainsRecursive(Node node, int value)
        {
            if (node == null)
            {
                return false;
            }

            if (value == node.Value)
            {
                return true;
            }

            return value < node.Value
                ? ContainsRecursive(node.Left, value)
                : ContainsRecursive(node.Right, value);
        }

        public void Clear()
        {
            root = null;
            count = 0;
        }

        public int[] ToArray()
        {
            List<int> result = new List<int>();
            InOrderTraversal(root, (value) => result.Add(value));
            return result.ToArray();
        }

        private void InOrderTraversal(Node node, Action<int> action)
        {
            if (node != null)
            {
                InOrderTraversal(node.Left, action);
                action(node.Value);
                InOrderTraversal(node.Right, action);
            }
        }

        public IEnumerable<int> InOrderTraversal()
        {
            List<int> result = new List<int>();
            InOrderTraversal(root, (value) => result.Add(value));
            return result;
        }

        public int Count
        {
            get { return count; }
        }
    }
}



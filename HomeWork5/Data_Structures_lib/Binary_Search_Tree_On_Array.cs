using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures_lib
{
    public class TreeNode
    {
        public int Value;
        public TreeNode? Left;
        public TreeNode? Right;

        public TreeNode(int value)
        {
            Value = value;
            Left = null;
            Right = null;
        }
    }

    public class BinarySearchTree
    {
        public TreeNode? Root { get; private set; }
        public int Count { get; private set; }

        public void Add(int value)
        {
            Root = AddRecursive(Root, value);
            Count++;
        }

        private TreeNode AddRecursive(TreeNode? node, int value)
        {
            if (node == null)
            {
                return new TreeNode(value);
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
            return ContainsRecursive(Root, value);
        }

        private bool ContainsRecursive(TreeNode? node, int value)
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
            Root = null;
            Count = 0;
        }

        public int[] ToArray()
        {
            int[] result = new int[Count];
            ToArrayRecursive(Root, ref result, 0);
            return result;
        }

        private int ToArrayRecursive(TreeNode? node, ref int[] result, int index)
        {
            if (node != null)
            {
                index = ToArrayRecursive(node.Left, ref result, index);
                result[index++] = node.Value;
                index = ToArrayRecursive(node.Right, ref result, index);
            }

            return index;
        }
    }
}



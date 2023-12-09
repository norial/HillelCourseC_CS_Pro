using CollectionInterfaces;


namespace Data_Structures_lib
{
    namespace Data_Structures_lib
    {
        public class BinarySearchTree<T> : IBinarySearchTree<T> where T : IComparable<T>
        {
            private class Node
            {
                public readonly T Value;
                public Node Left { get; set; }
                public Node Right { get; set; }

                public Node(T value)
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

            public void Add(T value)
            {
                root = AddRecursive(root, value);
                count++;
            }

            private Node AddRecursive(Node node, T value)
            {
                if (node == null)
                {
                    return new Node(value);
                }

                if (value.CompareTo(node.Value) < 0)
                {
                    node.Left = AddRecursive(node.Left, value);
                }
                else if (value.CompareTo(node.Value) > 0)
                {
                    node.Right = AddRecursive(node.Right, value);
                }

                return node;
            }

            public bool Contains(T value)
            {
                return ContainsRecursive(root, value);
            }

            private bool ContainsRecursive(Node node, T value)
            {
                if (node == null)
                {
                    return false;
                }

                if (value.CompareTo(node.Value) == 0)
                {
                    return true;
                }

                return value.CompareTo(node.Value) < 0
                    ? ContainsRecursive(node.Left, value)
                    : ContainsRecursive(node.Right, value);
            }

            public void Clear()
            {
                root = null;
                count = 0;
            }

            public T[] ToArray()
            {
                List<T> result = new List<T>();
                InOrderTraversal(root, (val) => result.Add(val));
                return result.ToArray();
            }

            private void InOrderTraversal(Node node, Action<T> action)
            {
                if (node != null)
                {
                    InOrderTraversal(node.Left, action);
                    action(node.Value);
                    InOrderTraversal(node.Right, action);
                }
            }

            public IEnumerable<T> InOrderTraversal()
            {
                List<T> result = new List<T>();
                InOrderTraversal(root, (val) => result.Add(val));
                return result;
            }

            public int Count
            {
                get { return count; }
            }
        }
    }
}

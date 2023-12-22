using CollectionInterfaces;
using System.Collections;


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

            public IEnumerator<T> GetEnumerator()
            {
                return InOrderTraversal(root).GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            private IEnumerable<T> InOrderTraversal(Node node)
            {
                if (node != null)
                {
                    foreach (var item in InOrderTraversal(node.Left))
                        yield return item;

                    yield return node.Value;

                    foreach (var item in InOrderTraversal(node.Right))
                        yield return item;
                }
            }

            public IEnumerable<T> Filter(Func<T, bool> predicate)
            {
                return InOrderTraversal(root).Where(predicate);
            }

            public IEnumerable<T> Skip(int count)
            {
                return InOrderTraversal(root).Skip(count);
            }

            public IEnumerable<T> Take(int count)
            {
                return InOrderTraversal(root).Take(count);
            }

            public IEnumerable<T> TakeWhile(Func<T, bool> predicate)
            {
                return InOrderTraversal(root).TakeWhile(predicate);
            }

            public T First(Func<T, bool> predicate)
            {
                return InOrderTraversal(root).First(predicate);
            }

            public T FirstOrDefault(Func<T, bool> predicate)
            {
                return InOrderTraversal(root).FirstOrDefault(predicate);
            }

            public T Last(Func<T, bool> predicate)
            {
                return InOrderTraversal(root).Last(predicate);
            }

            public T LastOrDefault(Func<T, bool> predicate)
            {
                return InOrderTraversal(root).LastOrDefault(predicate);
            }

            public IEnumerable<TResult> Select<TResult>(Func<T, TResult> selector)
            {
                return InOrderTraversal(root).Select(selector);
            }

            public IEnumerable<TResult> SelectMany<TResult>(Func<T, IEnumerable<TResult>> selector)
            {
                return InOrderTraversal(root).SelectMany(selector);
            }

            public bool All(Func<T, bool> predicate)
            {
                return InOrderTraversal(root).All(predicate);
            }

            public bool Any(Func<T, bool> predicate)
            {
                return InOrderTraversal(root).Any(predicate);
            }

            public T[] ToArray()
            {
                return InOrderTraversal(root).ToArray();
            }

            public List<T> ToList()
            {
                return InOrderTraversal(root).ToList();
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

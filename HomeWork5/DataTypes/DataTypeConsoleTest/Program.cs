using System.Collections.Generic;


namespace DataStructuresTest
{
    class Program
    {
        static void Main(string[] args)
        {
            AddToQueueTest();
            AddToStackTest();
            AddToSinglyLinkedListTest();
            AddToBinarySearchTreeTest();
            AddToListTest();

            Console.ReadLine();
        }
        private static void ShowTestResult(string testName, bool isSuccess)
        {
            Console.ResetColor();
            Console.Write($"{testName}: ");

            string resultMsg = string.Empty;
            if (isSuccess)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.White;
                resultMsg = "SUCCESS!";
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                resultMsg = "FAILED!";
            }

            Console.WriteLine(resultMsg);
            Console.ResetColor();
        }

        static void AddToSinglyLinkedListTest()
        {
            Console.WriteLine("Add to Singly Linked List Test:");

            Data_Structures_lib.SinglyLinkedList<int> singlyLinkedList = new Data_Structures_lib.SinglyLinkedList<int>();

            singlyLinkedList.Add(1);
            singlyLinkedList.Add(2);
            singlyLinkedList.Add(3);

            bool isSuccess =
                singlyLinkedList.Count == 3
                && singlyLinkedList.Contains(2)
                && singlyLinkedList.Contains(4) == false;

            ShowTestResult("Add to Singly Linked List", isSuccess);

            Console.WriteLine();
        }

        static void AddToStackTest()
        {
            Console.WriteLine("Add to Stack Test:");

            Data_Structures_lib.ArrayStack<int> stack = new Data_Structures_lib.ArrayStack<int>();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            bool isSuccess =
                stack.Count == 3
                && stack.Pop() == 3
                && stack.Pop() == 2
                && stack.Peek() == 1;

            ShowTestResult("Add to Stack", isSuccess);

            Console.WriteLine();
        }

        static void AddToListTest()
        {
            Console.WriteLine("Add to List Test:");

            Data_Structures_lib.ListOnArray<int> list = new Data_Structures_lib.ListOnArray<int>();

            list.Add(1);
            list.Add(2);
            list.Add(3);

            bool isSuccess =
                list.Count == 3
                && list.Contains(2)
                && list.Contains(4) == false;

            ShowTestResult("Add to List", isSuccess);

            Console.WriteLine();
        }

        static void AddToQueueTest()
        {
            Console.WriteLine("Add to Queue Test:");

            Data_Structures_lib.ArrayQueue<int> queue = new Data_Structures_lib.ArrayQueue<int>();

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            bool isSuccess =
                queue.Count == 3
                && queue.Dequeue() == 1
                && queue.Peek() == 2;

            ShowTestResult("Add to Queue", isSuccess);

            Console.WriteLine();
        }

        static void AddToBinarySearchTreeTest()
        {
            Console.WriteLine("Add to Binary Search Tree Test:");

            Data_Structures_lib.SinglyLinkedList<int> binarySearchTree = new Data_Structures_lib.SinglyLinkedList<int>();

            binarySearchTree.Add(2);
            binarySearchTree.Add(1);
            binarySearchTree.Add(3);

            bool isSuccess =
                binarySearchTree.Count == 3
                && binarySearchTree.Contains(2)
                && binarySearchTree.Contains(4) == false;

            ShowTestResult("Add to Binary Search Tree", isSuccess);

            Console.WriteLine();
        }
    }
}
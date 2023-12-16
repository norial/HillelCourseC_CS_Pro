using DataTypeConsoleTest;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;


namespace DataStructuresTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var DataTypesTest = new DataTypesTest();
            DataTypesTest.AddToQueueTest();
            DataTypesTest.AddToStackTest();
            DataTypesTest.AddToSinglyLinkedListTest();
            DataTypesTest.AddToBinarySearchTreeTest();
            DataTypesTest.AddToListTest();
            Console.WriteLine();
            DataTypesTest.AddToObservableListTest();
            Console.ReadLine();
        }
    }
}
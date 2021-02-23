using System;
using System.Collections.Generic;
using ArraysAndCollections.FirstTask;
using ArraysAndCollections.SecondTask;
using ArraysAndCollections.Sorting;

namespace ArraysAndCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            // First task.
            
            var builder = new CollectionBuilder();

            var firstStack = builder.GenerateStack(new Random().Next(8, 13), 9);
            var secondStack = builder.GenerateStack(new Random().Next(8, 13), 9);
            var resultStack = StackComparison.CompareStacks(firstStack, secondStack);
            
            CollectionDisplay.Display("First stack", firstStack);
            CollectionDisplay.Display("Second stack", secondStack);
            CollectionDisplay.Display("Result stack", resultStack);
            Console.WriteLine();

            // Second task.
            
            var queue = new Queue<int>(builder
                .GenerateArrayWithDifferentNumbers(new Random().Next(10, 20), 100));
            
            CollectionDisplay.Display("Queue", queue);
            var sum = SumOfQueueMembers.FindSum(queue);
            Console.WriteLine($"Sum: {sum}");
          
            // Third task.

            var queue1 = new Queue<int>(builder.GenerateArray(new Random().Next(10, 15)));
            ThirdTask.ThirdTask.CountInCircle(queue1);
            Console.WriteLine("\n");
            
            // Sorting.
            
            Console.WriteLine("Quick sort");
            var array = builder.GenerateArray(new Random().Next(15, 20), 33);
            CollectionDisplay.Display("Array",array);
            QuickSort.QSort(array, 0, array.Length - 1);
            CollectionDisplay.Display("Result array",array);

            Console.WriteLine("Merge Sort");
            array = builder.GenerateArray(new Random().Next(15, 20), 33);
            CollectionDisplay.Display("Array",array);
            var resultArray = MergeSort.MSort(array);
            CollectionDisplay.Display("Result array",resultArray);
        }
    }
}
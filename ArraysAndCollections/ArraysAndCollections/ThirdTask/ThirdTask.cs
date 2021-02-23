using System;
using System.Collections.Generic;

namespace ArraysAndCollections.ThirdTask
{
    public class ThirdTask
    {
        private static void InsertAtTheEndOfTheQueue(ref Queue<int> queue)
        {
            queue.Enqueue(queue.Dequeue());
        }

        public static void CountInCircle(Queue<int> queue)
        {
            Console.WriteLine();
            while (queue.Count != 1)
            {
                DisplayQueue(queue);
                InsertAtTheEndOfTheQueue(ref queue);
                queue.Dequeue();
            }
            Console.WriteLine(queue.Peek());
        }

        private static void DisplayQueue(Queue<int> queue)
        {
            foreach (var element in queue.ToArray())
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();
        }
    }
}
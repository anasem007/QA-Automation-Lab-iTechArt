using System;
using System.Collections.Generic;
using System.Linq;

namespace ArraysAndCollections.SecondTask
{
    public static class SumOfQueueMembers
    {
        public static int FindSum(Queue<int> queue)
        {
            var max = queue.Max();
            Console.WriteLine($"Max: {max}");
            var min = queue.Min();
            Console.WriteLine($"Min: {min}");
            var sum = 0;
            
            while (queue.Peek() != max && queue.Peek() != min)
            {
                queue.Dequeue();
            }

            if (queue.Peek() == max)
            {
                FindSum(queue, min, ref sum);
            }
            else if(queue.Peek() == min)
            {
                FindSum(queue, max, ref sum);   
            }

            return sum;
        }

        private static void FindSum(Queue<int> queue, int a, ref int sum)
        {
            while (queue.Peek() != a)
            {
                sum += queue.Dequeue();
            }
            sum += queue.Dequeue();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace ArraysAndCollections
{
    public class CollectionBuilder
    {
        private int GenerateNumber(int limit)
        {
            return new Random().Next(0, limit);
        }

        public Stack<int> GenerateStack(int count, int limit)
        {
            return new Stack<int>(GenerateArray(count, limit));
        }
        
        public Queue<int> GenerateQueue(int count, int limit)
        { 
            return new Queue<int>(GenerateArray(count, limit));
        }
        
        public Queue<int> GenerateQueue(int count)
        { 
            return new Queue<int>(GenerateArray(count));
        }

        public int[] GenerateArray(int count)
        {
            var array = new int[count];
            for (var i = 0; i < count; i++)
            {
                array[i] = i + 1;
            }

            return array;
        }

        public int[] GenerateArray(int count, int limit)
        {
            var array = new int[count];
            for (int i = 0; i < count; i++)
            {
                array[i] = (GenerateNumber(limit));
            }
            
            return array;
        }
        
        public int[] GenerateArrayWithDifferentNumbers(int count, int limit)
        {
            var array = new int[count];
            for (int i = 0; i < count; i++)
            {
                var number = GenerateNumber(limit);
                while (array.Contains(number))
                {
                    number = GenerateNumber(limit);
                }

                array[i] = number;
            }
            return array;
        }
    }
}
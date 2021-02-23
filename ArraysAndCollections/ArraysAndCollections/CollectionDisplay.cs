using System;
using System.Collections.Generic;

namespace ArraysAndCollections
{
    public static class CollectionDisplay
    {
        public static void Display( string name, Stack<int> stack)
        {
            Console.WriteLine("{0}: {1}", name, string.Join(", ", stack));
        }
        
        public static void Display(string name, Queue<int> queue)
        {
            Console.WriteLine("{0}: {1}", name, string.Join(", ", queue));
        }
        
        public static void Display(string name, int[] array)
        {
            Console.WriteLine("{0}: {1}", name, string.Join(", ", array));
        }
    }
}
using System;

namespace InitializingVariablesAndUsingOperators
{
    public class ComparisonOperator
    {
        public static void UseOperatorLessThan(int a, int b) 
            => Console.WriteLine(a < b);
        
        public static void UseOperatorMoreThan(int a, int b) 
            => Console.WriteLine(a > b);
        
        public static void UseOperatorLessThanOrEqual(int a, int b) 
            => Console.WriteLine(a <= b);
        
        public static void UseOperatorMoreThanOrEqual(int a, int b) 
            => Console.WriteLine(a >= b);
    }
}
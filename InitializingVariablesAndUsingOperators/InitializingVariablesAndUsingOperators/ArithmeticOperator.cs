using System;

namespace InitializingVariablesAndUsingOperators
{
    public class ArithmeticOperator
    {
        public static void UseDivisionOperator(float a, float b)
        {
            Console.WriteLine("Деление чисел с плавающей точкой ");
            try
            {
                 Console.WriteLine($"Полученное значение: {a / b}\n");
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        public static void UseDivisionOperator(int a, int b)
        {
            Console.WriteLine("Деление целых чисел ");
            try
            {
                Console.WriteLine($"Полученное значение: {(float) a / b}\n");
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        public static int UseMultiplicationOperator(int a, int b) => a * b;

        public static void UsePostfixIncrementOperator(int i)
        {
            Console.WriteLine($"Начальное значение: {i}");
            Console.WriteLine($"Значение числа при использовании постфиксного оператора приращения: {i++}");
            Console.WriteLine($"Значение числа после использовании постфиксного оператора приращения: {i} \n");
        }

        public static void UsePrefixIncrementOperator(int i) 
        {
            Console.WriteLine($"Начальное значение: {i}");
            Console.WriteLine($"Значение числа при использовании префиксного оператора приращения: {++i}");
            Console.WriteLine($"Значение числа после использовании префиксного оператора приращения: {i} \n");
        }

        public static void UsePostfixDecreaseOperator(int i) 
        {
            Console.WriteLine($"Начальное значение: {i}");
            Console.WriteLine($"Значение числа при использовании постфиксного оператора уменьшения: {i--}");
            Console.WriteLine($"Значение числа после использовании постфиксного оператора уменьшения: {i}\n");
        }

        public static void UsePrefixDecreaseOperator(int i)
        {
            Console.WriteLine($"Начальное значение: {i}");
            Console.WriteLine($"Значение числа при использовании префиксного оператора уменьшения: {--i}");
            Console.WriteLine($"Значение числа после использовании префиксного оператора уменьшения: {i}\n");
        }

        public static void UseUnaryMinusOperator(int a)
        {
            int b = a != 0 ? -a : 0;
            Console.WriteLine($"использование унарного опаретора -: {b}\n");
        }

        public static void UseUnaryPlusOperator(int a) => Console.WriteLine($"использование унарного опаретора +: {+a}\n");
        
        public static void UseAdditionOperator(int a, int b) => Console.WriteLine($"использование опаретора +: {a+b}\n");
        
        public static void UseSubtractionOperator(int a, int b) => Console.WriteLine($"использование опаретора -: {a-b}\n");

        public static void UseIntegerRemainderOperator(int a, int b) 
            => Console.WriteLine($"использование опаретора целочисленного остатка: {a % b}\n");
        
        public static void UseFloatingPointRemainderOperator(float a, float b) 
            =>  Console.WriteLine($"использование опаретора остатка c плавающей точкой: {a % b}\n");
    }
}
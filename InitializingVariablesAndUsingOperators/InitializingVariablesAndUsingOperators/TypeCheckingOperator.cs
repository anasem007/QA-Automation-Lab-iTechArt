using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using Microsoft.VisualBasic.CompilerServices;

namespace InitializingVariablesAndUsingOperators
{
    public class TypeCheckingOperator
    {
        public static void IsExampleOfOperatorIsUsing()
        {
            if ( ( EqualityOperator.IsExampleOfValueTypesEquality(5, 5) ) is true)
            {
                Console.WriteLine("\n При сравнении двух одинаковых целочисленных значений  возвращаеться true");
            }
        }

        public static void IsExampleOfOperatorAsUsing()
        {
            ClassA a = new ClassA();
            ClassB b = new ClassB();
            b = a as ClassB;
            if (b != null)
            {
                Console.WriteLine("a может принимать значения ClassB");
            }
            else
            {
                Console.WriteLine("Видимо что-то пошло не по плану");
            }
        }
        
        public static void IsExampleOfCastExpressionUsing()
        {
            double a = 37.6d;
            Console.WriteLine($" {a} - значение переменной a типа double в значение типа int:  {(int) a} \n");
        }
        
        public class ClassA
        {
            public void PrintA() => Console.WriteLine("classA");
        }
        
        public class ClassB : ClassA
        {
            public void PrintB() => Console.WriteLine("classB");
        }

    }
}
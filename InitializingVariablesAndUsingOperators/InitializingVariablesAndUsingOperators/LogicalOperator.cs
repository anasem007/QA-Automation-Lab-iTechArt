using System;

namespace InitializingVariablesAndUsingOperators
{
     public class LogicalOperator
     {
         public static void UseLogicalNegationOperator(bool a) 
             => Console.WriteLine("\n Использование ! : " + !a);
        
         public static void UseLogicalAndOperator(bool a, bool b) 
             => Console.WriteLine($"\n Использование & : {a & b }");
        
         public static void UseLogicalExclusionOrOperator(bool a, bool b) 
             => Console.WriteLine($"\n Использование ^ : {a ^ b }");
        
         public static void UseLogicalOrOperator(bool a, bool b) 
             => Console.WriteLine($"\n Использование | : {a | b }");
        
         public static void UseConditionalLogicalAndOperator(bool a, bool b) 
             => Console.WriteLine($"\n Использование && : {a && b }");
        
         public static void UseConditionalLogicalOrOperator(bool a, bool b) 
             => Console.WriteLine($"\n Использование || : {a || b }");
         
     }
}
using System;

namespace InitializingVariablesAndUsingOperators
{
    public record PersonRecord(string Name, int Age);

    public class EqualityOperator
    {
        public static bool IsExampleOfValueTypesEquality(int a, int b) => a == b;

        public static void IsExampleOfReferenceTypesEquality()
        {
            var firstClassInstance = new Person("Ana", 375293908309);
            var secondClassInstance = new Person("Ana", 375293908309);
            var classReference = firstClassInstance;
            Console.WriteLine($"Сравнение ссылок на два разных объекта с одинаковыми значениями: {firstClassInstance == secondClassInstance}");
            Console.WriteLine($"Сравнение двух ссылок на один и тот же объект: {firstClassInstance == classReference}");
    }

        public static void IsExampleOfRecordTypesEquality()
        {
            var person1 = new PersonRecord("Ana", 21 );
            var person2 = new PersonRecord("Ana", 21);

            Console.WriteLine("Сравнение двух операндов записи, у которых " +
                              $"соотвествуют записи всех полей  {person1 == person2}");
        }

        public static void IsExampleIfStringEquality(string a, string b)
        {
            Console.WriteLine($"Сравнение двух строк: {a == b}");
        }

        public static void IsExampleDelegateEquality()
        {
            Action handlerFirst = FirstDelegateMethod;
            Action handlerSecond = SecondDelegateMethod;
            Action handlerThird = ThirdDelegateMethod;
            Action handler = FirstDelegateMethod;
            Action a = handlerFirst + handlerSecond;
            Action b = handlerFirst + handlerSecond;
            
            Console.WriteLine("Сравнение двух делегатов, ссылающихся на разные методы, " +
                              $"которые содержат одинаковые записи: {handlerSecond == handlerThird }");
            Console.WriteLine($"Сравнение двух делегатов, ссылающихся на один и тот же метод: {handlerFirst == handler }");
           
            Console.WriteLine("Сравнение двух делегатов, ссылающихся на одинаковый список методов: " + (a == b));
          
            a = handlerSecond + handlerFirst;
            b = handlerFirst + handlerSecond;
            Console.WriteLine("Сравнение двух делегатов, ссылающихся на разный список методов: " + (a == b));
        }

        public static void IsExampleOfInequalityOperatorUsing(int a, int b)
        {
           Console.WriteLine($"Неравенство двух целочисленных значений {a != b}");
        }

        private static void FirstDelegateMethod()
        {
            Console.WriteLine("Evening");
        }
        
        private static void SecondDelegateMethod()
        {
            Console.WriteLine("Morning");
        }
        
        private static void ThirdDelegateMethod()
        {
            Console.WriteLine("Morning");
        }
    
    }
}
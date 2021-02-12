using System;

namespace InitializingVariablesAndUsingOperators
{
    class Program
    {
        static void Main(string[] args)
        {
            // Инициализация переменных всех типов.
           
            bool boolVariable = true;
            byte byteVariable = 17;
            sbyte sbyteVariable = -17;
            char charVariable = 'M';
            decimal decimalVariable = 7.99999999999m;
            double doubleVariable = 47.2;
            float floatVariable = 3.3f;
            int intVariable = 9;
            uint uintVariable = 0b1101;
            long longVariable = 11;
            ulong ulongVariable = 0;
            short shortVariable = -32768;
            object objectVariable = "Hi";
            string stringVariable = "tragedy = tragos + ödö = goats song";
            dynamic dynamicVariable = 4;
            dynamicVariable = "string";
            
            // Использование операторов
            
            ArithmeticOperator.UseDivisionOperator(8, 5);
            ArithmeticOperator.UseDivisionOperator(7.2f, 3.6f);
            ArithmeticOperator.UseMultiplicationOperator(11, 12);
            ArithmeticOperator.UsePostfixIncrementOperator(5);
            ArithmeticOperator.UsePrefixIncrementOperator(5);
            ArithmeticOperator.UsePostfixDecreaseOperator(5);
            ArithmeticOperator.UsePrefixDecreaseOperator(5);
            ArithmeticOperator.UseUnaryMinusOperator(36);
            ArithmeticOperator.UseUnaryPlusOperator(-4);
            ArithmeticOperator.UseAdditionOperator(3, 4);
            ArithmeticOperator.UseSubtractionOperator(-3, 8);
            ArithmeticOperator.UseIntegerRemainderOperator(10, 3);
            ArithmeticOperator.UseFloatingPointRemainderOperator(89.3f, 34.2f);
                
            EqualityOperator.IsExampleOfValueTypesEquality(3, 3);
            EqualityOperator.IsExampleOfReferenceTypesEquality();
            EqualityOperator.IsExampleOfRecordTypesEquality();
            EqualityOperator.IsExampleIfStringEquality("Harry Potter", "Hobbit");
            EqualityOperator.IsExampleDelegateEquality();
            EqualityOperator.IsExampleOfInequalityOperatorUsing(8, 3);
            
            LogicalOperator.UseLogicalNegationOperator(true);
            LogicalOperator.UseLogicalAndOperator(false, true);
            LogicalOperator.UseLogicalExclusionOrOperator(false, true);
            LogicalOperator.UseLogicalOrOperator(false, true);
            LogicalOperator.UseConditionalLogicalAndOperator(false, true);
            LogicalOperator.UseConditionalLogicalOrOperator(false, true);

            TypeCheckingOperator.IsExampleOfOperatorIsUsing();
            TypeCheckingOperator.IsExampleOfOperatorAsUsing();
            TypeCheckingOperator.IsExampleOfCastExpressionUsing();

            BitwiseOperatorAndShiftOperator.UseBitwiseComplementOperator();
            BitwiseOperatorAndShiftOperator.UseLeftShiftOperator(3);
            BitwiseOperatorAndShiftOperator.UseRightShiftOperator(4);
            BitwiseOperatorAndShiftOperator.UseLogicalExclusionOrOperator();
            BitwiseOperatorAndShiftOperator.UseLogicalAndOperator();
            BitwiseOperatorAndShiftOperator.UseLogicalOrOperator();
            
            ComparisonOperator.UseOperatorLessThan(5,6);
            ComparisonOperator.UseOperatorMoreThan(9, 6);
            ComparisonOperator.UseOperatorLessThanOrEqual(5, 5);
            ComparisonOperator.UseOperatorMoreThanOrEqual(0, -4);
        }
    }
    
}
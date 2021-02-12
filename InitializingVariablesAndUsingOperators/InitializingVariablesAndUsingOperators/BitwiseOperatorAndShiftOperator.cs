using System;

namespace InitializingVariablesAndUsingOperators
{
    public class BitwiseOperatorAndShiftOperator
    {
        public static void UseBitwiseComplementOperator()
        {
            uint a = 0b000011110000111100001111;
            Console.WriteLine(Convert.ToString(~a, toBase: 2));
        }

        public static void UseLeftShiftOperator(int count)
        {
            uint a = 0b000011110000111011111100;
            Console.WriteLine(Convert.ToString(a << count, toBase: 2));
        }

        public static void UseRightShiftOperator(int count)
        {
            uint a = 0b000011110000111100001100;
            Console.WriteLine(Convert.ToString(a >> count, toBase: 2));
        }

        public static void UseLogicalAndOperator()
        {
            uint a = 0b11111000;
            uint b = 0b10011101;
            Console.WriteLine(Convert.ToString(a & b, toBase: 2));
        }

        public static void UseLogicalExclusionOrOperator()
        {
            uint a = 0b11111000;
            uint b = 0b10011101;
            Console.WriteLine(Convert.ToString(a ^ b, toBase: 2));
        }

        public static void UseLogicalOrOperator()
        {
            uint a = 0b11111000;
            uint b = 0b10011101;
            Console.WriteLine(Convert.ToString(a | b, toBase: 2));
        }
    }
}
﻿namespace Calculations
{
    public class Calculator
    {
        private int num1, num2;
        public Calculator(int num1, int num2)
        {
            this.num1 = num1;
            this.num2 = num2;

        }

        public int Num1 { get => num1; set => num1 = value; }
        public int Num2 { get => num2; set => num2 = value; }

        public int Add()
        {
            return Num1 + Num2;
        }

        public int Sub()
        {
            return Num1 - Num2;
        }
        public int Mul()
        {
            return Num1 * Num2;
        }
    }
}
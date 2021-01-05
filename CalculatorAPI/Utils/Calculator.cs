using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorAPI
{
    public static class Calculator
    {
        public static double[] GetPercentagesOfTotal(int a, int b)
        {
            if (a < 0 || b < 0)
                throw new ArgumentOutOfRangeException("Negative numbers are invalid");

            int total = a + b;
            double[] percentages;

            if (total == 0)
                percentages = GetZeroPercentageArray();
            else if (a > 0 && b > 0)
                percentages = CalculatePercentage(a, b, total);
            else
                percentages = GetHundredPercentArray(a, b);

            return percentages;
        }

        private static double[] GetZeroPercentageArray()
        {
            return new double[]
            {
                0,
                0
            };
        }

        private static double[] CalculatePercentage(int a, int b, int total)
        {
            return new double[]
            {
                Math.Round(((double)a / total) * 100, 0),
                Math.Round(((double)b / total) * 100, 0)
            };
        }

        private static double[] GetHundredPercentArray(int a, int b)
        {
            double[] percentageArray;
            if (a > 0)
                percentageArray = new double[] { 100, 0 };
            else
                percentageArray = new double[] { 0, 100 };

            return percentageArray;
        }
    }
}

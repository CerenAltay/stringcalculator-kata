using System;
using System.Linq;


namespace StringCalculatorTask
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (String.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            char[] delimiters = new char[] { ',', '\n' };
            int sum = numbers.Split(delimiters).Sum(x => int.Parse(x));

            return sum;
        }
    }
}

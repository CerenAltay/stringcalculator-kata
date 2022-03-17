using System;
using System.Collections.Generic;
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

            List<char> delimiters = new() { ',', '\n' };


            if (numbers.Contains("//"))
            {
                numbers = numbers.Trim('/');
                char newDelimiter = numbers[0];
                delimiters.Add(newDelimiter);
                numbers= numbers.Remove(0, 2);

            }

            char[] delimitersArray = delimiters.ToArray();
            int sum = numbers.Split(delimitersArray).Sum(x => int.Parse(x));

            return sum;

        }


    }
}

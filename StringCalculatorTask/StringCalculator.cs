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

            var numbersInString = RetrieveNumbersFromString(numbers);

            int sum = numbersInString.Select(x => int.Parse(x)).ToList().Sum();

            return sum;
        }

        private string[] RetrieveNumbersFromString(string stringInput)
        {
            List<char> delimiters = new() { ',', '\n' };

            if (stringInput.Contains("//"))
            {
                stringInput = stringInput.Trim('/');
                char customDelimiter = stringInput[0];
                delimiters.Add(customDelimiter);
                stringInput = stringInput.Remove(0, 2);
            }
            char[] delimitersArray = delimiters.ToArray();

            var numbersArray = stringInput.Split(delimitersArray);

            return numbersArray;
        }

    }
}

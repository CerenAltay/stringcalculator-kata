using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorTask
{
    public class StringCalculator
    {
        private const string CustomDelimiterIndicator = "//";
        private const char DefaultDelimiter = ',';
        private const char NewLine = '\n';

        public int Add(string numbers)
        {
            if (String.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            List<char> delimiters = new() { DefaultDelimiter, NewLine };

            if (numbers.Contains(CustomDelimiterIndicator))
            {
                var customDelimiter = RetrieveCustomDelimiter(numbers);
                delimiters.Add(customDelimiter);
                numbers = numbers.Split(CustomDelimiterIndicator)[1].ToString();
            }

            var numbersInString = RetrieveCleanNumbers(numbers, delimiters.ToArray());

            return numbersInString.Sum();
        }
        private static char RetrieveCustomDelimiter(string stringInput)
        {
            var customDelimiter = stringInput.Trim('/').Trim(NewLine)[0];

            return customDelimiter;
        }

        private static List<int> RetrieveCleanNumbers(string stringInput, char[] delimiters)
        {
            var numbersArray = stringInput.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            return numbersArray.Select(x => int.Parse(x)).ToList();
        }

    }
}

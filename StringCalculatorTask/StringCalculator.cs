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

            List<int> numbersInString = RetrieveCleanNumbers(numbers, delimiters.ToArray());

            if (numbersInString.Any(x => x < 0))
            {
                RestrictNegatives(numbersInString);
            }

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

        private static void RestrictNegatives(List<int> numbersList)
        {
            var negativeNumbers = numbersList.Where(x => x < 0).ToList();
            string negativeNumbersString = string.Join(",", negativeNumbers.ToArray());

            throw new Exception($"negatives not allowed {negativeNumbersString}");
        }

    }
}

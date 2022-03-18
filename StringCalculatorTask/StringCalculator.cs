using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorTask
{
    public class StringCalculator
    {
        private const string CustomDelimiterIndicator = "//";
        private const string DefaultDelimiter = ",";
        private const string NewLine = "\n";
        private const int MaxNumber = 1000;

        public int Add(string numbers)
        {
            if (String.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            List<string> delimiters = new() { DefaultDelimiter, NewLine };

            if (numbers.Contains(CustomDelimiterIndicator))
            {
                var customDelimiters = RetrieveCustomDelimiters(numbers);
                delimiters.AddRange(customDelimiters);
                numbers = numbers.Split(CustomDelimiterIndicator)[1].ToString();
            }

            List<int> numbersInString = RetrieveCleanNumbers(numbers, delimiters.ToArray());

            if (numbersInString.Any(x => x < 0))
            {
                RestrictNegatives(numbersInString);
            }

            if (numbersInString.Any(x => x > MaxNumber))
            {
                numbersInString.RemoveAll(x => x > MaxNumber);
            }

            return numbersInString.Sum();
        }

        private static List<string> RetrieveCustomDelimiters(string stringInput)
        {
            List<string> customDelimeters = new();
            string delimiter;
            if (stringInput.Contains('['))
            {
                delimiter = stringInput.Split('[', ']')[1];
            }
            else
            {
                delimiter = stringInput.Trim('/')[0].ToString();
            }
            customDelimeters.Add(delimiter);

            return customDelimeters;
        }

        private static List<int> RetrieveCleanNumbers(string stringInput, string[] delimiters)
        {
            if (stringInput.Contains('['))
            {
                stringInput = stringInput.Split(']')[1];
            }
            var numbersArray = stringInput.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).ToList();

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

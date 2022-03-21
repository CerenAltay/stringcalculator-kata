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

            List<string> delimitersList = new() { DefaultDelimiter, NewLine };

            if (numbers.StartsWith(CustomDelimiterIndicator))
            {
                delimitersList = AddCustomDelimitersToDelimitersList(numbers, delimitersList);
                numbers = GetInputStringAfterIndicators(numbers);
            }

            List<int> numbersInString = RetrieveCleanNumbers(numbers, delimitersList.ToArray());

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

        #region helper methods
        private static List<string> AddCustomDelimitersToDelimitersList(string stringInput, List<string> delimiters)
        {
            string customDelimiter;
            while (stringInput.Contains('['))
            {
                customDelimiter = stringInput.Split('[', ']')[1];
                stringInput = stringInput.Split(new[] { ']' }, 2)[1];
                delimiters.Add(customDelimiter);
            }
            customDelimiter = stringInput.Trim('/')[0].ToString();
            delimiters.Add(customDelimiter);

            return delimiters;
        }

        private static string GetInputStringAfterIndicators(string stringInput)
        {
            stringInput = stringInput.Split(NewLine)[1].ToString();

            return stringInput;
        }

        private static List<int> RetrieveCleanNumbers(string stringInput, string[] delimiters)
        {
            var numbersArray = stringInput.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).ToList();

            return numbersArray.Select(x => int.Parse(x)).ToList();
        }

        private static void RestrictNegatives(List<int> numbersList)
        {
            var negativeNumbers = numbersList.Where(x => x < 0).ToList();
            string negativeNumbersString = string.Join(",", negativeNumbers.ToArray());

            throw new Exception($"negatives not allowed {negativeNumbersString}");
        }
        #endregion
    }
}

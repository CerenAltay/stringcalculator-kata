using System;
using Xunit;

namespace StringCalculatorTask
{
    public class StringCalculatorTests
    {
        private StringCalculator _stringCalculator = new StringCalculator();

        [Fact]
        public void Add_EmptyString_ReturnsZero()
        {
            var result = _stringCalculator.Add("");

            Assert.Equal(0, result);
        }

        [Theory]
        [InlineData("1", 1)]
        [InlineData("2", 2)]
        public void Add_OneNumber_ReturnsThatNumber(string numbers, int expected)
        {
            var result = _stringCalculator.Add(numbers);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("1,2", 3)]
        [InlineData("3,4", 7)]
        public void Add_TwoNumbers_ReturnsSum(string numbers, int expected)
        {
            var result = _stringCalculator.Add(numbers);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("1,2,6", 9)]
        [InlineData("3,4,5,6,8", 26)]
        public void Add_UnknownAmountOfNumbers_ReturnsSum(string numbers, int expected)
        {
            var result = _stringCalculator.Add(numbers);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("1\n2,3", 6)]
        [InlineData("3\n4,5\n7", 19)]
        public void Add_NewLinesBetweenNumbers_ReturnsSum(string numbers, int expected)
        {
            var result = _stringCalculator.Add(numbers);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("//;\n1;2", 3)]
        [InlineData("//*\n1,2*3", 6)]
        public void Add_DifferentDelimiters_ReturnsSum(string numbers, int expected)
        {
            var result = _stringCalculator.Add(numbers);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("1,2,-1", "negatives not allowed -1")]
        [InlineData("1,2,-1,-4,-6", "negatives not allowed -1,-4,-6")]
        public void Add_NegativeNumber_ThrowsExceptionWithMessage(string numbers, string expectedMessage)
        {
            var exception = Assert.Throws<Exception>(() => _stringCalculator.Add(numbers));

            Assert.Equal(expectedMessage, exception.Message);
        }

        [Theory]
        [InlineData("2,1001", 2)]
        [InlineData("//*\n1,2*3,2300", 6)]
        public void Add_NumbersBiggerThan1000_ReturnsBiggerNumbersIgnoredSum(string numbers, int expected)
        {
            var result = _stringCalculator.Add(numbers);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("//[***]\n1***2***3", 6)]
        public void Add_ContainsDelimitersWithAnyLength_ReturnsSum(string numbers, int expected)
        {
            var result = _stringCalculator.Add(numbers);

            Assert.Equal(expected, result);
        }
    }
}

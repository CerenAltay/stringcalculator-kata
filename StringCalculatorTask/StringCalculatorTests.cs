using System;
using Xunit;

namespace StringCalculatorTask
{
    public class StringCalculatorTests
    {
        [Fact]
        public void Add_EmptyString_ReturnsZero()
        {
            var stringCalculator = new StringCalculator();

            var result = stringCalculator.Add("");

            Assert.Equal(0, result);
        }

        [Theory]
        [InlineData("1", 1)]
        [InlineData("2", 2)]
        public void Add_OneNumber_ReturnsThatNumber(string numbers, int expected)
        {
            var stringCalculator = new StringCalculator();

            var result = stringCalculator.Add(numbers);

            Assert.Equal(expected, result);
        }
    }
}

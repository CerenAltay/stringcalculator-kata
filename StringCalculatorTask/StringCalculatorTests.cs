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
    }
}

using System;
using Xunit;

namespace StringCalculator.Tests
{
    public class CalculatorTests
    {
        [Fact]
        public void Add_EmptyString_ShouldReturnZero()
        {
            var calculator = new Calculator();

            var actual = calculator.Add("");
            
            Assert.Equal(0, actual);
        }
        
        [Fact]
        public void Add_OneArgString_ShouldReturnInt()
        {
            var calculator = new Calculator();

            var actual = calculator.Add("5");
            
            Assert.Equal(5, actual);
        }
        
        [Fact]
        public void Add_TwoArgsString_ShouldReturnInt()
        {
            var calculator = new Calculator();

            var actual = calculator.Add("5,7");
            
            Assert.Equal(12, actual);
        }
        
        [Fact]
        public void Add_UnknownAmountNumbers_ShouldReturnInt()
        {
            var calculator = new Calculator();

            var actual = calculator.Add("5,7,3,2,6");
            
            Assert.Equal(23, actual);
        }

        [Fact]
        public void Add_NewLineSeparatorBetweenValues_ShouldInt()
        {
            var calculator = new Calculator();

            var actual = calculator.Add("5\n7,3\n5");
            
            Assert.Equal(20, actual);
        }
        
        [Theory]
        [InlineData("//;\n1;2", 3)]
        [InlineData("//:\n1:2\n3", 6)]
        [InlineData("//@\n1@2\n3@5", 11)]
        public void Add_DifferentDelimiters_ShouldReturnInt(string rawStringValues, int expected)
        {
            var calculator = new Calculator();

            var actual = calculator.Add(rawStringValues);
            
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("1,-2", "Negatives not allowed [-2]")]
        [InlineData("1\n-3", "Negatives not allowed [-3]")]
        [InlineData("//;\n1\n-2;-3", "Negatives not allowed [-2, -3]")]
        public void Add_NegativeValues_ShouldThrowAnException(string rawStringValues, string expectedExceptionMessage)
        {
            var calculator = new Calculator();

            var exception = Assert.Throws<Exception>(() =>
            {
                calculator.Add(rawStringValues);
            });
            
            Assert.Equal(expectedExceptionMessage, exception.Message);
        }
        
        [Fact]
        public void Add_BiggerThan1000_ShouldBeIgnored()
        {
            var calculator = new Calculator();

            var actual = calculator.Add("2,5,1001");
            
            Assert.Equal(7, actual);
        }
        
        [Theory]
        [InlineData("//[***]\n1***2***3", 6)]
        [InlineData("//[abc]\n1abc2\n3", 6)]
        [InlineData("//[a!23bc]\n1a!23bc2\n3", 6)]
        public void Add_AnyLengthDelimiter_ShouldReturnInt(string rawStringValues, int expected)
        {
            var calculator = new Calculator();

            var actual = calculator.Add(rawStringValues);
            Assert.Equal(expected, actual);
        }
        
        [Theory]
        [InlineData("//[*][%]\n1*2%3\n4", 10)]
        [InlineData("//[**][%@;]\n1**2%@;3\n4", 10)]
        public void Add_MultipleDelimiters_ShouldReturnInt(string rawStringValues, int expected)
        {
            var calculator = new Calculator();

            var actual = calculator.Add(rawStringValues);
            Assert.Equal(expected, actual);
        }
        
        [Theory]
        [InlineData("//[x]]\n5x]5", 10)]
        [InlineData("//[*][[[x]]]]]\n1*2[[x]]]]3\n4", 10)]
        public void Add_MultipleDelimitersWithBrackets_ShouldReturnInt(string rawStringValues, int expected)
        {
            var calculator = new Calculator();
            
            var actual = calculator.Add(rawStringValues);
            Assert.Equal(expected, actual);
        }
    }
}
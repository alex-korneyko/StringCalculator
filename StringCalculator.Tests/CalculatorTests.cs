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
        
        [Fact]
        public void Add_DifferentDelimiters_ShouldReturnInt()
        {
            var calculator = new Calculator();

            var actual = calculator.Add("//;\n1;2");
            Assert.Equal(3, actual);

            actual = calculator.Add("//:\n1:2\n3");
            Assert.Equal(6, actual);
            
            actual = calculator.Add("//@\n1@2\n3@5");
            Assert.Equal(11, actual);
        }

        [Fact]
        public void Add_NegativeValues_ShouldThrowAnException()
        {
            var calculator = new Calculator();

            Assert.Throws<Exception>(() =>
            {
                calculator.Add("1,-2");
            });
            
            Assert.Throws<Exception>(() =>
            {
                calculator.Add("1\n-2");
            });
            
            Assert.Throws<Exception>(() =>
            {
                calculator.Add("//;\n1\n-2;3");
            });
        }
        
        [Fact]
        public void Add_BiggerThan1000_ShouldBeIgnored()
        {
            var calculator = new Calculator();

            var actual = calculator.Add("2,5,1001");
            
            Assert.Equal(7, actual);
        }
        
        [Fact]
        public void Add_AnyLengthDelimiter_ShouldReturnInt()
        {
            var calculator = new Calculator();

            var actual = calculator.Add("//[***]\n1***2***3");
            Assert.Equal(6, actual);

            actual = calculator.Add("//[abc]\n1abc2\n3");
            Assert.Equal(6, actual);
            
            actual = calculator.Add("//[a!23bc]\n1a!23bc2\n3");
            Assert.Equal(6, actual);
        }
        
        [Fact]
        public void Add_MultipleDelimiters_ShouldReturnInt()
        {
            var calculator = new Calculator();

            var actual = calculator.Add("//[*][%]\n1*2%3\n4");
            Assert.Equal(10, actual);
            
            actual = calculator.Add("//[**][%@;]\n1**2%@;3\n4");
            Assert.Equal(10, actual);
        }
    }
}
using Xunit;

namespace StringCalculator.Tests
{
    public class CalculatorTests
    {
        [Fact]
        public void Add_EmptyString_ShouldReturnZero()
        {
            ICalculator calculator = new Calculator();

            var actual = calculator.Add("");
            
            Assert.Equal(0, actual);
        }
        
        [Fact]
        public void Add_OneArgString_ShouldReturnInt()
        {
            ICalculator calculator = new Calculator();

            var actual = calculator.Add("5");
            
            Assert.Equal(5, actual);
        }
        
        [Fact]
        public void Add_TwoArgsString_ShouldReturnInt()
        {
            ICalculator calculator = new Calculator();

            var actual = calculator.Add("5,7");
            
            Assert.Equal(12, actual);
        }
        
        [Fact]
        public void AddTwoArgsNegStringTest()
        {
            ICalculator calculator = new Calculator();

            var actual = calculator.Add("5,-7");
            
            Assert.Equal(-2, actual);
        }
    }
}
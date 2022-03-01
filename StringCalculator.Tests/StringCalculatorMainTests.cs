using Xunit;

namespace StringCalculator.Tests
{
    public class StringCalculatorMainTests
    {
        [Fact]
        public void AddEmptyStringTest()
        {
            ICalculator calculator = new Calculator();

            var actual = calculator.Add("");
            
            Assert.Equal(0, actual);
        }
        
        [Fact]
        public void AddOneArgStringTest()
        {
            ICalculator calculator = new Calculator();

            var actual = calculator.Add("5");
            
            Assert.Equal(5, actual);
        }
        
        [Fact]
        public void AddTwoArgsStringTest()
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
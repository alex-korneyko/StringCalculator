using Xunit;

namespace StringCalculator.Tests
{
    public class StringExtensionTests
    {
        [Theory]
        [InlineData("SuperTestString", "Super", "TestString")]
        [InlineData("SuperTestString", "", "SuperTestString")]
        [InlineData("SuperTestString", "AAA", "SuperTestString")]
        public void RemoveIfStartsWith_String_ShouldReturnString(string value, string forRemove, string expected)
        {
            var resultString = value.RemoveIfStartsWith(forRemove);
            
            Assert.Equal(expected, resultString);
        }
        
        [Theory]
        [InlineData("SuperTestString", "String", "SuperTest")]
        [InlineData("SuperTestString", "", "SuperTestString")]
        [InlineData("SuperTestString", "AAA", "SuperTestString")]
        public void RemoveIfEndsWith_String_ShouldReturnString(string value, string forRemove, string expected)
        {
            var resultString = value.RemoveIfEndsWith(forRemove);
            
            Assert.Equal(expected, resultString);
        }
    }
}
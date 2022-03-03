using Moq;
using StringCalculator;
using Xunit;

namespace Presentation.Tests
{
    public class AppTests
    {
        [Fact]
        public void Start_ExecutionAndExit()
        {
            var mock = new Mock<IController<string>>();
            mock.Setup(dataHandler => dataHandler.GetData("Enter comma separated numbers (enter to exit): ")).Returns("5,6");
            var app = new App(new Calculator(), mock.Object);
            
            app.Start();
        }
    }
}
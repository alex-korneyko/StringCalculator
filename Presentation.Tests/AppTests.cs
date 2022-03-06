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
            var controllerMock = new Mock<IController<string>>();

            controllerMock.Setup(controller => controller.GetData("Enter comma separated numbers (enter to exit): "))
                .Returns("5,6");

            controllerMock.SetupSequence(controller => controller.GetData("you can enter other numbers (enter to exit)? "))
                .Returns("7,8")
                .Returns(@"//[x][%]\n7x8%9")
                .Returns("");
            
            var app = new App(new Calculator(), controllerMock.Object);
            app.Start();

            controllerMock.Verify(controller => controller.GetData("Enter comma separated numbers (enter to exit): "), Times.Once);
            controllerMock.Verify(controller => controller.GetData("you can enter other numbers (enter to exit)? "), Times.Exactly(3));
            controllerMock.Verify(controller => controller.ShowData("Result is: 11"));
            controllerMock.Verify(controller => controller.ShowData("Result is: 15"));
            controllerMock.Verify(controller => controller.ShowData("Result is: 24"));
        }
    }
}
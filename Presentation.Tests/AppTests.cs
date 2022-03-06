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

            mock.Setup(controller => controller.GetData("Enter comma separated numbers (enter to exit): "))
                .Returns("5,6");

            mock.SetupSequence(controller => controller.GetData("you can enter other numbers (enter to exit)? "))
                .Returns("7,8")
                .Returns(@"//[x][%]\n7x8%9")
                .Returns("");
            
            var app = new App(new Calculator(), mock.Object);
            app.Start();

            mock.Verify(a => a.GetData("Enter comma separated numbers (enter to exit): "), Times.Once);
            mock.Verify(controller => controller.ShowData("Result is: 11"));
            mock.Verify(a => a.GetData("you can enter other numbers (enter to exit)? "), Times.Exactly(3));
            mock.Verify(controller => controller.ShowData("Result is: 15"));
            mock.Verify(a => a.GetData("you can enter other numbers (enter to exit)? "), Times.Exactly(3));
            mock.Verify(controller => controller.ShowData("Result is: 24"));
            mock.Verify(a => a.GetData("you can enter other numbers (enter to exit)? "), Times.Exactly(3));
        }
    }
}
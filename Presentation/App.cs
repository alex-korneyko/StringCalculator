using StringCalculator;

namespace Presentation
{
    public class App
    {
        private readonly ICalculator _calculator;
        private readonly IController<string> _controller;

        public App(ICalculator calculator, IController<string> controller)
        {
            _calculator = calculator;
            _controller = controller;
        }
        
        public void Start()
        {
            StartDialog();
        }
        
        private void StartDialog()
        {
            var consoleInput = _controller.GetData("Enter comma separated numbers (enter to exit): ");

            while (!string.IsNullOrEmpty(consoleInput))
            {
                var result = _calculator.Add(consoleInput);
                _controller.ShowData($"Result is: {result}");
                
                consoleInput = _controller.GetData("you can enter other numbers (enter to exit)? ");
            }
        }
    }
}
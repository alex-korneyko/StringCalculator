using System;
using StringCalculator;

namespace Presentation
{
    public class App
    {
        private readonly Calculator _calculator;

        public App(Calculator calculator)
        {
            _calculator = calculator;
        }
        
        public void Start()
        {
            ConsoleHandler();
        }
        
        private void ConsoleHandler()
        {
            Console.Write("Enter comma separated numbers (enter to exit): ");
            var consoleInput = Console.ReadLine();

            while (!string.IsNullOrEmpty(consoleInput))
            {
                var result = _calculator.Add(consoleInput);
                Console.WriteLine($"Result is: {result}");
                
                Console.Write("you can enter other numbers (enter to exit)? ");
                consoleInput = Console.ReadLine();
            }
        }
    }
}
using System;

namespace StringCalculator
{
    public class CalculatorApp
    {
        private readonly ICalculator _calculator;

        public CalculatorApp(ICalculator calculator)
        {
            _calculator = calculator;
        }
        
        public void Start()
        {
            for (;;)
            {
                Console.Write("Enter numbers separated by commas (exit for Exit): ");
                var stringNumbers = Console.ReadLine();
                stringNumbers ??= "";
                
                if (stringNumbers.ToLower().Equals("exit")) break;

                Console.WriteLine($"Sum: {_calculator.Add(stringNumbers)}");
            }
        }
    }
}
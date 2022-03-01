using System;

namespace StringCalculator
{
    public class CalculatorApp
    {
        public void Start()
        {
            var calculator = new Calculator();
            
            for (;;)
            {
                Console.Write("Enter numbers separated by commas (exit for Exit): ");
                var stringNumbers = Console.ReadLine();
                stringNumbers ??= "";
                
                if (stringNumbers.ToLower().Equals("exit")) break;

                Console.WriteLine($"Sum: {calculator.Add(stringNumbers)}");
            }
        }
    }
}
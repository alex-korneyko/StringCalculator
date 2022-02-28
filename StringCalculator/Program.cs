using System;

namespace StringCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculatorApp = new CalculatorApp(new Calculator());
            
            calculatorApp.Start();
        }
    }
}
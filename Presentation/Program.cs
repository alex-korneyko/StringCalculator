using StringCalculator;

namespace Presentation
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new App(new Calculator(), new ConsoleController());
            
            app.Start();
        }
    }
}
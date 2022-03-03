using System;

namespace Presentation
{
    public class ConsoleController : IController<string>
    {
        public string GetData(string message)
        {
            Console.Write(message);
            var readLine = Console.ReadLine();

            return readLine;
        }

        public void ShowData(string data)
        {
            Console.WriteLine(data);
        }
    }
}
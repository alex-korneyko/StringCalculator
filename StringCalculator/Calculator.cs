using System.Linq;

namespace StringCalculator
{
    public class Calculator
    {
        public int Add(string values)
        {
            if (values.Equals(""))
                return 0;

            var stringNums = values.Split(',');

            var result = stringNums.ToList().Select(int.Parse).Sum();

            return result;
        }
    }
}
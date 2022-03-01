using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public class Calculator
    {
        public int Add(string values)
        {
            if (values.Equals(""))
                return 0;

            var stringNums = new List<string>();

            values
                .Split(',')
                .ToList().Select(commaSeparated => commaSeparated.Split("\n"))
                .ToList().ForEach(newLineSeparated => stringNums.AddRange(newLineSeparated));

            var result = stringNums.ToList().Select(int.Parse).Sum();

            return result;
        }
    }
}
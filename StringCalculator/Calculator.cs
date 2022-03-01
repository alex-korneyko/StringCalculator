using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public class Calculator
    {
        public int Add(string values)
        {
            var separator = ",";
            
            if (values.Equals(""))
                return 0;

            var stringNums = new List<string>();

            if (values.StartsWith("//"))
            {
                var separatorLine = values.Split("\n")[0];
                if (separatorLine.Length == 3)
                {
                    separator = separatorLine[2..];
                    values = values[4..];
                }
            }

            values
                .Split(separator)
                .ToList().Select(commaSeparated => commaSeparated.Split("\n"))
                .ToList().ForEach(newLineSeparated => stringNums.AddRange(newLineSeparated));

            var result = stringNums.Select(int.Parse).Sum();

            return result;
        }
    }
}
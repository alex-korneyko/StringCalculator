using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringCalculator
{
    public class Calculator
    {
        public int Add(string values)
        {
            var separators = new List<string>{","};

            if (values.Equals(""))
                return 0;

            var stringNums = new List<string>();

            if (values.StartsWith("//"))
            {
                separators.Clear();
                values = values.Replace("//", "");
                var separatorLine = values.Split("\n")[0];
                switch (separatorLine.Length)
                {
                    case 1:
                        separators.Add(separatorLine);
                        values = values[2..];
                        break;
                    case > 1:
                        separatorLine = separatorLine.StartsWith('[')
                            ? separatorLine.Remove(0, 1)
                            : separatorLine;

                        separatorLine = separatorLine.EndsWith(']')
                            ? separatorLine.Remove(separatorLine.Length - 1, 1)
                            : separatorLine;
                        
                        separatorLine.Split("][")
                            .ToList().ForEach(separatorWithBrackets =>
                            {
                                separators.Add(separatorWithBrackets);
                            });
                        
                        values = values.Substring(separatorLine.Length + 3);
                        break;
                }
            }

            values
                .Split(separators.ToArray(), StringSplitOptions.RemoveEmptyEntries)
                .ToList().Select(commaSeparated => commaSeparated.Split("\n"))
                .ToList().ForEach(newLineSeparated => stringNums.AddRange(newLineSeparated));

            var ints = stringNums.Select(int.Parse).ToList();
            var negativeNums = ints.Where(value => value < 0).ToList();
            if (negativeNums.Any())
            {
                var message = new StringBuilder("Negatives not allowed [");
                negativeNums.ToList().ForEach(value => message.Append(value).Append(", "));
                throw new Exception(message.Remove(message.Length - 2, 2).Append(']').ToString());
            }

            var result = ints.Where(value => value <= 1000).Sum();

            return result;
        }
    }
}
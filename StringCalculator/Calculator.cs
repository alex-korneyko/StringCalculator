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
                var separatorLine = values.Split("\n")[0];
                switch (separatorLine.Length)
                {
                    case 3:
                        separators.Add(separatorLine[2..]);
                        values = values[4..];
                        break;
                    case > 3:
                        separatorLine.Split("][")
                            .ToList().ForEach(separatorWithBrackets =>
                            {
                                separatorWithBrackets = separatorWithBrackets.Replace("[", "");
                                separatorWithBrackets = separatorWithBrackets.Replace("]", "");
                                separatorWithBrackets = separatorWithBrackets.Replace("//", "");
                                separators.Add(separatorWithBrackets);
                            });
                        
                        values = values.Substring(separatorLine.Length + 1);
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
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
                switch (separatorLine.Length)
                {
                    case 3:
                        separator = separatorLine[2..];
                        values = values[4..];
                        break;
                    case > 3:
                        separator = separatorLine[3..^1];
                        values = values.Substring(separatorLine.Length + 1);
                        break;
                }
            }

            values
                .Split(separator)
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
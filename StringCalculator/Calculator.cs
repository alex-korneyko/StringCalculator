using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public class Calculator
    {
        public int Add(string values)
        {
            if (values.Equals("")) return 0;

            var delimiters = GetDelimiters(values);

            var integers = GetArguments(values, delimiters);
            
            CheckNegatives(integers);

            var result = integers.Where(value => value <= 1000).Sum();

            return result;
        }

        private void CheckNegatives(IList<int> integers)
        {
            if (integers.FirstOrDefault(value => value < 0) == default) return;
            
            var message = "Negatives not allowed [";

            foreach (var negativeNum in integers.Where(value => value < 0))
            {
                message += negativeNum + ", ";
            }

            throw new Exception(message.RemoveIfEndsWith(", ") + ']');
        }

        private string[] GetDelimiters(string rawInputString)
        {
            if (!rawInputString.StartsWith("//")) return new []{","};
            
            var delimiters = new List<string>();

            rawInputString = rawInputString.Replace("//", "");
            var separatorsLine = rawInputString.Split("\n")[0];
            
            switch (separatorsLine.Length)
            {
                case 1:
                    delimiters.Add(separatorsLine);
                    break;
                case > 1:
                    separatorsLine = separatorsLine.RemoveIfStartsWith("[").RemoveIfEndsWith("]");
                    delimiters.AddRange(separatorsLine.Split("]["));
                    break;
            }

            return delimiters.ToArray();
        }

        private IList<int> GetArguments(string rawInputString, string[] delimiters)
        {
            if (rawInputString.StartsWith("//"))
            {
                rawInputString = rawInputString.Remove(0, rawInputString.IndexOf('\n') + 1);
            }
            
            var stringNumbers = new List<string>();
            
            var separatedByDelimitersAndNewLines = rawInputString
                .Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
                .Select(separatedByDelimiters => separatedByDelimiters.Split("\n"));
                
            foreach (var separatedByNewLines in separatedByDelimitersAndNewLines)
            {
                stringNumbers.AddRange(separatedByNewLines);
            }

            var ints = stringNumbers.Select(int.Parse).ToList();

            return ints;
        }
    }
}
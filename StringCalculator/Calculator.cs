using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringCalculator
{
    public class Calculator : ICalculator
    {
        public int Add(string values)
        {
            if (values.Equals("")) 
                return 0;

            var delimiters = GetDelimiters(values);
            var integers = GetArguments(values, delimiters);
            
            CheckNegatives(integers);

            var result = integers
                .Where(value => value <= 1000)
                .Sum();

            return result;
        }

        private void CheckNegatives(IList<int> integers)
        {
            var anyNegative = integers.FirstOrDefault(value => value < 0);
            
            if (anyNegative == default) 
                return;
            
            var message = new StringBuilder("Negatives not allowed [");

            var negatives = integers.Where(value => value < 0);
            
            message.AppendJoin(", ", negatives).Append(']');

            throw new Exception(message.ToString());
        }

        private IList<string> GetDelimiters(string rawInputString)
        {
            if (!rawInputString.StartsWith("//")) return new List<string>{","};
            
            var delimiters = new List<string>();

            rawInputString = rawInputString.Replace("//", "");
            var separatorsLine = rawInputString.Split(@"\n")[0];
            
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

            return delimiters;
        }

        private IList<int> GetArguments(string rawInputString, IList<string> delimiters)
        {
            if (rawInputString.StartsWith("//"))
            {
                rawInputString = rawInputString.Remove(0, rawInputString.IndexOf(@"\n", StringComparison.InvariantCulture) + @"\n".Length);
            }
            
            var stringNumbers = new List<string>();
            
            var separatedByDelimitersAndNewLines = rawInputString
                .Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(separatedByDelimiters => separatedByDelimiters.Split(@"\n"));
                
            foreach (var separatedByNewLines in separatedByDelimitersAndNewLines)
            {
                stringNumbers.AddRange(separatedByNewLines);
            }

            var integers = stringNumbers
                .Select(int.Parse)
                .ToList();

            return integers;
        }
    }
}
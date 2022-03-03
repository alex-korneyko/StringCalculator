namespace StringCalculator
{
    public static class Extends
    {
        public static string RemoveIfStartsWith(this string inputString, string value)
        {
            if (inputString.StartsWith(value))
            {
                inputString = inputString.Remove(0, value.Length);
            }

            return inputString;
        }

        public static string RemoveIfEndsWith(this string inputString, string value)
        {
            if (inputString.EndsWith(value))
            {
                inputString = inputString.Remove(inputString.Length - value.Length, value.Length);
            }

            return inputString;
        }
    }
}
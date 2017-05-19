using System;

namespace StringCalculator
{
    public class Calculator
    {
        public Int32 Add(String input)
        {
            if (String.IsNullOrWhiteSpace(input))
                return 0;

            return Convert.ToInt32(input);
        }
    }
}

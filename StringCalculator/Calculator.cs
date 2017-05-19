using System;
using System.Linq;

namespace StringCalculator
{
    public class Calculator
    {
        public Int32 Add(String input)
        {
            if (String.IsNullOrWhiteSpace(input))
                return 0;

            var delims = ",\n".ToCharArray();
            var numArray = input.Split(delims);
            
            return numArray.Select(n => Convert.ToInt32(n)).Sum();
        }
    }
}

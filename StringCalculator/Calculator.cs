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

            var delims = ",\n".ToCharArray().ToList();
            if (input.StartsWith("//"))
            {
                delims.Add(input.ToCharArray()[2]);
                input = input.Substring(input.IndexOf('\n') + 1);
            }

            var numArray = input.Split(delims.ToArray());
            
            return numArray.Select(n => Convert.ToInt32(n)).Sum();
        }
    }
}

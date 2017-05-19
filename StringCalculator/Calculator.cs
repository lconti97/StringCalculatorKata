using System;
using System.Linq;

namespace StringCalculator
{
    public class Calculator
    {
        private const Int32 MaxInputValue = 1000;
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

            var nums = input.Split(delims.ToArray()).Select(n => Convert.ToInt32(n)).Where(n => n < MaxInputValue);
            var negatives = nums.Where(n => n < 0);

            if (negatives.Any())
            {
                var errorMessage = String.Join(", ", negatives) + (negatives.Count() == 1 ? " is" : " are")
                    + " not allowed.";
                throw new NegativeNumberException(errorMessage);
            }

            return nums.Sum();
        }
    }
}

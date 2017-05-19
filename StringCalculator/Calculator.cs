using System;
using System.Collections;
using System.Collections.Generic;
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

            String[] numStringArray;

            var startsWithSpecialDelimiter = input.StartsWith("//");

            if (startsWithSpecialDelimiter)
            {
                var specialDelimiterIsLong = input.StartsWith("//[");

                if (specialDelimiterIsLong)
                {
                    var indexOfOpenBracket = 2;
                    var indexOfClosedBracket = input.IndexOf(']');
                    var delims = input.Substring(indexOfOpenBracket + 1, indexOfClosedBracket - indexOfOpenBracket - 1);
                    numStringArray = input.Substring(indexOfClosedBracket + 1)
                        .Split(new[] { delims }, StringSplitOptions.None);
                }
                else
                {
                    var delims = input.Substring(2, 1);
                    numStringArray = input.Substring(4).Split(delims.ToArray());
                }
            }
            else
            {
                var delims = ",\n".ToCharArray().ToList();
                numStringArray = input.Split(delims.ToArray());
            }

            var nums = numStringArray.Select(n => Convert.ToInt32(n)).Where(n => n < MaxInputValue).ToList();
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

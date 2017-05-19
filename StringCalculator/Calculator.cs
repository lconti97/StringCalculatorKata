﻿using System;
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

            var nums = input.Split(delims.ToArray()).Select(n => Convert.ToInt32(n));

            var negatives = nums.Where(n => n < 0);
            if (negatives.Any())
                throw new NegativeNumberException(negatives.First() + " is not allowed.");

            return nums.Sum();
        }
    }
}

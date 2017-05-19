using System;

namespace StringCalculator
{
    public class NegativeNumberException : Exception
    {
        public NegativeNumberException(String message) : base(message)
        {
        }
    }
}

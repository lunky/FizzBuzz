using System;
using System.Collections.Generic;
using System.Linq;

namespace FizzBuzzLib
{
    public class FizzBuzz
    {
        public IEnumerable<string> GetFizzBuzz(int upperBound, List<(int, string)> toFind  = null)
        {

            if (upperBound < 0)
            {
                throw new ArgumentException(message: "upperBound must be a value between 0 and int.MaxValue");
            }
            if (toFind == null)
            {
                for (var i = 1; i <= upperBound; i++)
                {
                    yield return GetFbNumber(i);
                }
            }
            else { 
                for (var i = 1; i <= upperBound; i++)
                {
                    yield return NumberReplacement(i, toFind);
                }

            }
        }

        protected static string GetFbNumber(int inputNumber)
        {

            switch (inputNumber)
            {
                case int _ when (inputNumber % 3 == 0 && inputNumber % 5 == 0):
                    return "Fizz Buzz";
                case int _ when (inputNumber % 3 == 0):
                    return "Fizz";
                case int _ when (inputNumber % 5 == 0):
                    return "Buzz";
                default:
                    return inputNumber.ToString();
            }
        }

        protected static string NumberReplacement(int inputNumber, List<(int, string)> toFind)
        {
            return toFind.Any(t => t.Item1.Equals(inputNumber)) 
                ? toFind.First(t => t.Item1.Equals(inputNumber)).Item2 
                : inputNumber.ToString();
        }
    }
}

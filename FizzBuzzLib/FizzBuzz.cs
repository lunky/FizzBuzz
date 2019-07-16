using System;
using System.Collections.Generic;
using System.Linq;

namespace FizzBuzzLib
{
    public class FizzBuzz
    {
        public IEnumerable<string> GetFizzBuzz(int upperBound)
        { 
            var defaultRules = new List<(int, string)>{
                (3, "Fizz"),
                (5, "Buzz"),
            };
            return GetFizzBuzz(upperBound, defaultRules);
        }

        public IEnumerable<string> GetFizzBuzz(int upperBound, List<(int, string)> intStringTuples)
        {
            var rules = intStringTuples.Select(tuple => ((Func<int, bool>) (g => g % tuple.Item1 == 0), tuple.Item2));
            return GetFizzBuzz(upperBound, rules.ToList());
        }

        public IEnumerable<string> GetFizzBuzz(int upperBound, List<(Func<int, bool>, string)> rules)
        {
            if (upperBound < 0)
            {
                throw new ArgumentException(message: "upperBound must be a value between 0 and int.MaxValue", paramName: nameof(upperBound));
            }

            if (rules == null)
            {
                throw new ArgumentException(message: "rules cannot be null", paramName: nameof(rules));
            }

            for (var i = 1; i <= upperBound; i++)
            {
                yield return GetFbNumber(i, rules);
            }
        }


        protected static string GetFbNumber(int inputNumber, List<(Func<int, bool>, string)> toFind)
        {
           var found = toFind.Where(i => i.Item1(inputNumber)).Select(i=>i.Item2).ToList();
            return found.Any() ? string.Concat(found) : inputNumber.ToString();
        }

    }
}

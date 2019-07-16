using System;
using System.Collections.Generic;
using System.Linq;

namespace FizzBuzzLib
{
    public class FizzBuzz
    {
        private const int DefaultUpperBound = 100;
            private readonly List<(int,string)> _defaultRules = 
                new List<(int, string)>{
                    (3, "Fizz"),
                    (5, "Buzz")
                };

        public IEnumerable<string> GetFizzBuzz()
        {
            return GetFizzBuzz(DefaultUpperBound);
        }

        public IEnumerable<string> GetFizzBuzz(int upperBound)
        {
            return GetFizzBuzz(upperBound, _defaultRules);
        }

        public IEnumerable<string> GetFizzBuzz(int upperBound, List<(int, string)> rules)
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

        protected static string GetFbNumber(int inputNumber, IEnumerable<(int key, string value)> toFind)
        {
            var found = toFind
                .Where(i => inputNumber % i.key == 0)
                .Select(i => i.value).ToList();

            return found.Any() ? string.Concat(found) : inputNumber.ToString();
        }
    }
}

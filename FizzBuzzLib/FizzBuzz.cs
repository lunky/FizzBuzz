using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

namespace FizzBuzzLib
{
    public class FizzBuzz
    {
        public IEnumerable<string> GetFizzBuzz(int upperBound)
        {
            var defaultRules = new List<(Func<int, bool>, string)>{
                (x=> x%3==0 && x%5==0, "Fizz Buzz"),
                (x=> x%3==0, "Fizz"),
                (x=> x%5==0, "Buzz"),
            };
            return GetFizzBuzz(upperBound, defaultRules);
        }
        public IEnumerable<string> GetFizzBuzz(int upperBound, List<(int, string)> intStringTuples)
        {
            var rules = new List<(Func<int, bool>, string)>
            {
                (g => (intStringTuples.Count>1 && intStringTuples.All(intStr => g % intStr.Item1 == 0)), 
                    string.Concat(intStringTuples.Select( val => val.Item2)))
            };
            foreach (var (key, value) in intStringTuples)
            {
                rules.Add((g => g % key == 0, value));
            }

            return GetFizzBuzz(upperBound, rules);
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
            return toFind.FirstOrDefault(i => i.Item1(inputNumber)).Item2 ?? inputNumber.ToString();
        }

    }
}

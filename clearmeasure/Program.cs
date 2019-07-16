using FizzBuzzLib;
using System;
using System.Collections.Generic;

namespace clearmeasure
{
    class Program
    {
        static void Main()
        {
            var fb = new FizzBuzz();
            const int upperBound = 100;
            var fbs = fb.GetFizzBuzz(upperBound);
            foreach (var fizzBuzz in fbs)
            {
                Console.WriteLine(fizzBuzz);
            }
            var fbs2 = fb.GetFizzBuzz(upperBound, new List<(int,string)>{ (3,"fizz"), (5, "buzz")});
            foreach (var fizzBuzz in fbs2)
            {
                Console.WriteLine(fizzBuzz);
            }
        }
    }
}

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
            var fizzBuzzes = fb.GetFizzBuzz(upperBound, new List<(int,string)>{ (3,"fizz"), (5, "buzz"), (30, "foo")});
            foreach (var fizzBuzz in fizzBuzzes)
            {
                Console.WriteLine(fizzBuzz);
            }
        }
    }
}

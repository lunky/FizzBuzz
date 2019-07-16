using FizzBuzzLib;
using System;
using System.Collections.Generic;

namespace FizzBuzzProgram
{
    class Program
    {
        static void Main()
        {
            var fb = new FizzBuzz();
            const int upperBound = 30;

            // original FizzBuzz
            var fizzBuzzes = fb.GetFizzBuzz();
            foreach (var fizzBuzz in fizzBuzzes)
            {
                Console.WriteLine(fizzBuzz);
            }

            // FizzBuzz with bound setting
            Console.WriteLine("----------------");
            fizzBuzzes = fb.GetFizzBuzz(upperBound);
            foreach (var fizzBuzz in fizzBuzzes)
            {
                Console.WriteLine(fizzBuzz);
            }

            // FizzBuzz with bound setting and user defined number/string pairs
            Console.WriteLine("----------------");
            fizzBuzzes = fb.GetFizzBuzz(upperBound, new List<(int,string)>
            {
                (3,  "fizz"),
                (5,  "buzz"),
                (30, "foo")
            });
            foreach (var fizzBuzz in fizzBuzzes)
            {
                Console.WriteLine(fizzBuzz);
            }
        }
    }
}

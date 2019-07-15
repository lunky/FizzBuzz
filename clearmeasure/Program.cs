using System;
using FizzBuzzLib;

namespace clearmeasure
{
    class Program
    {
        static void Main()
        {
            var fb = new FizzBuzz();
            const int upperBound = 100; 
            var fbs = fb.GetFizzBuzz(upperBound);
            foreach (var fizzBuzz in fbs) {
                Console.WriteLine(fizzBuzz);
            }
        }
    }
}

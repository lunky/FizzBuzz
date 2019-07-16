using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FizzBuzz.Tests
{
    public class FizzBuzzLibTests
    {
        private FizzBuzzLib.FizzBuzz _sut;
        const int UpperBound = 100;

        [SetUp]
        public void Setup()
        {
            _sut = new FizzBuzzLib.FizzBuzz();
        }

        [Test]
        public void Invalid_upper_bound()
        {
            const int upperBound = -1;
            Assert.Throws<ArgumentException>(() => _ = _sut.GetFizzBuzz(upperBound).ToList());
        }


        [Test]
        public void Three_is_Fizz()
        {
            var actual = _sut.GetFizzBuzz().ToList();
            const string expected = "Fizz";
            Assert.AreEqual(expected, actual[2]);
        }

        [Test]
        public void Four_is_4()
        {
            var actual = _sut.GetFizzBuzz(UpperBound).ToList();
            const string expected = "4";
            Assert.AreEqual(expected, actual[3]);
        }

        [Test]
        public void Five_is_Buzz()
        {
            var actual = _sut.GetFizzBuzz(UpperBound).ToList();
            var expected = "Buzz";
            Assert.AreEqual(expected, actual[4]);
        }

        [Test]
        public void Fifteen_is_FizzBuzz()
        {
            var actual = _sut.GetFizzBuzz(UpperBound).ToList();
            var expected = "FizzBuzz";
            Assert.AreEqual(expected, actual[14]);
        }

        [Test]
        public void Collection_size_changes()
        {
            var upperBound = 100;
            var actual = _sut.GetFizzBuzz(upperBound).ToList();
            var expected = upperBound;
            Assert.AreEqual(expected, actual.Count);

            upperBound = 234;
            actual = _sut.GetFizzBuzz(upperBound).ToList();
            expected = upperBound;
            Assert.AreEqual(expected, actual.Count);
        }

        [Test]
        public void Null_rules()
        {
            List<(int, string)> rules = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            // QCW: ToList to trigger enumeration
            Assert.Throws<ArgumentException>(() => _ = _sut.GetFizzBuzz(UpperBound, rules).ToList());
        }

        [Test]
        public void Empty_collection_no_changes()
        {
            var actual = _sut.GetFizzBuzz(UpperBound, new List<(int, string)>()).ToList();
            Assert.AreEqual(actual, Enumerable.Range(1,UpperBound).Select(s=>s.ToString()) );
        }

        [Test]
        public void Collection_with_one_finds_numbers()
        {
            var toFind = new List<(int, string)> { (7, "taco") };
            var actual = _sut.GetFizzBuzz(UpperBound, toFind).ToList();
            Assert.AreEqual("taco", actual[6]);
            Assert.AreEqual("taco", actual[13]);
        }

        [Test]
        public void Many_pairs_order_preserved()
        {
            var toFind = new List<(int, string)>
            {
                (60, "Tuna"),
                (7, "Mouse"),
                (3, "Taco"),
                (15, "Airplane"),
                (22, "Banana"),
                (30, "Doctor"),
                (33, "Football"),
            };
            var actual = _sut.GetFizzBuzz(UpperBound, toFind).ToList();
            Assert.AreEqual("TacoAirplane", actual[14]);
            Assert.AreEqual("TacoAirplaneDoctor", actual[29]);
            Assert.AreEqual("TunaTacoAirplaneDoctor", actual[59]);
        }

        [Test]
        public void Number_four_no_change()
        {
            var toFind = new List<(int, string)>
            {
                (3, "Fizz"),
                (5, "Buzz"),
            };
            var actual = _sut.GetFizzBuzz(UpperBound, toFind).ToList();
            Assert.AreEqual("4", actual[3]);
        }
        [Test]
        public void Five_is_buzz_with_rules()
        {
            var toFind = new List<(int, string)>
            {
                (3, "fizz"),
                (5, "buzz"),
                (15, "foo"),
            };
            var actual = _sut.GetFizzBuzz(UpperBound, toFind).ToList();
            Assert.AreEqual("buzz", actual[4]);
        }

        [Test]
        public void Combines_two_numbers()
        {
            const int upperBound = 200;
            var toFind = new List<(int, string)>
            {
                (3, "fizz"),
                (5, "buzz"),
                (30, "foo"),
            };
            var actual = _sut.GetFizzBuzz(upperBound, toFind).ToList();

            Assert.AreEqual("fizzbuzz", actual[14]);
        }

        [Test]
        public void Combines_three_numbers()
        {
            const int upperBound = 200;

            var toFind = new List<(int, string)>
            {
                (3, "fizz"),
                (5, "buzz"),
                (10, "foo"),
            };
            var actual = _sut.GetFizzBuzz(upperBound, toFind).ToList();

            Assert.AreEqual("fizzbuzzfoo", actual[149]);
        }
    }
}
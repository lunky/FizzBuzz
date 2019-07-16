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
        public void Empty_collection_3_is_3()
        {
            var emptyList = new List<(int, string)>();
            var actual = _sut.GetFizzBuzz(UpperBound, emptyList).ToList();
            const string expected = "3";
            Assert.AreEqual(expected, actual[2]);
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
        public void Many_pairs()
        {
            var toFind = new List<(int, string)>
            {
                (7, "mouse"),
                (3, "taco"),
                (15, "airplane"),
                (22, "banana"),
            };
            var actual = _sut.GetFizzBuzz(UpperBound, toFind).ToList();
            Assert.AreEqual("tacoairplane", actual[14]);
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
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace FizzBuzz.Tests
{
    public class FizzBuzzLibTests
    {
        private FizzBuzzLib.FizzBuzz _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new FizzBuzzLib.FizzBuzz();
        }

        [Test]
        public void FizzBuzz_InvalidBoundCase()
        {
            const int upperBound = -1;
            Assert.Throws<ArgumentException>(() => _ = _sut.GetFizzBuzz(upperBound).ToList());
        }


        [Test]
        public void FizzBuzz_ThreeCase()
        {
            const int upperBound = 100;
            var actual = _sut.GetFizzBuzz(upperBound).ToList();
            const string expected = "Fizz";
            Assert.AreEqual(expected, actual[2]);
        }

        [Test]
        public void FizzBuzz_FourCase()
        {
            const int upperBound = 100;
            var actual = _sut.GetFizzBuzz(upperBound).ToList();
            const string expected = "4";
            Assert.AreEqual(expected, actual[3]);
        }

        [Test]
        public void FizzBuzz_FiveCase()
        {
            var upperBound = 100;
            var actual = _sut.GetFizzBuzz(upperBound).ToList();
            var expected = "Buzz";
            Assert.AreEqual(expected, actual[4]);
        }

        [Test]
        public void FizzBuzz_FifteenCase()
        {
            var upperBound = 100;
            var actual = _sut.GetFizzBuzz(upperBound).ToList();
            var expected = "FizzBuzz";
            Assert.AreEqual(expected, actual[14]);
        }

        [Test]
        public void FizzBuzz_CollectionSize()
        {
            var upperBound = 234;
            var actual = _sut.GetFizzBuzz(upperBound).ToList();
            var expected = upperBound;
            Assert.AreEqual(expected, actual.Count);
        }

        [Test]
        public void FizzBuzz_NullRules()
        {
            var upperBound = 100;
            List<(Func<int, bool>, string)> rules = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            // QCW: ToList to trigger enumeration
            Assert.Throws<ArgumentException>(() => _ = _sut.GetFizzBuzz(upperBound,rules).ToList());
        }

        [Test]
        public void FizzBuzz_EmptyCollectionPassed()
        {
            const int upperBound = 100;
            var emptyList = new List<(Func<int, bool>, string)>();
            var actual = _sut.GetFizzBuzz(upperBound, emptyList).ToList();
            const string expected = "3";
            Assert.AreEqual(expected, actual[2]);
        }

        [Test]
        public void FizzBuzz_CollectionWithOneFindsNumber()
        {
            const int upperBound = 100;
            const string expected = "taco";
            var toFind = new List<(Func<int, bool>, string)> { (x => x == 7, expected) };
            var actual = _sut.GetFizzBuzz(upperBound, toFind).ToList();
            Assert.AreEqual(expected, actual[7 - 1]);
        }

        [Test]
        public void FizzBuzz_CollectionWithMultipleExpressionsSetsNumber()
        {
            const int upperBound = 100;
            var toFind = new List<(Func<int, bool>, string)>
            {
                (x=>x==3, "taco"),
                (x=>x==15, "airplane"),
                (x=>x==22, "banana"),
            };
            var actual = _sut.GetFizzBuzz(upperBound, toFind).ToList();
            Assert.AreEqual("airplane", actual[14]);
        }

        [Test]
        public void FizzBuzz_CollectionWithKeyValuePair()
        {
            const int upperBound = 100;
            var toFind = new List<(int, string)>
            {
                (15, "airplane"),
            };
            var actual = _sut.GetFizzBuzz(upperBound, toFind).ToList();
            Assert.AreEqual("airplane", actual[14]);
        }
        [Test]
        public void FizzBuzz_CollectionWithMultipleFindsNumber3()
        {
            const int upperBound = 100;
            const string expected = "fizz";
            const int expectedNumber = 3;
            const string expected2 = "buzz";
            const int expectedNumber2 = 5;
            var toFind = new List<(int, string)>
            {
                (expectedNumber, expected),
                (expectedNumber2, expected2),
            };
            var actual = _sut.GetFizzBuzz(upperBound, toFind).ToList();
            Assert.AreEqual("fizzbuzz", actual[14]);
        }
        [Test]
        public void FizzBuzz_CollectionWithMultipleFindsNumber4()
        {
            const int upperBound = 100;
            const string expected = "fizz";
            const int expectedNumber = 3;
            const string expected2 = "buzz";
            const int expectedNumber2 = 5;
            var toFind = new List<(int, string)>
            {
                (expectedNumber, expected),
                (expectedNumber2, expected2),
            };
            var actual = _sut.GetFizzBuzz(upperBound, toFind).ToList();
            Assert.AreEqual("fizz", actual[2]);
        }
        [Test]
        public void FizzBuzz_CollectionWithMultipleFindsNumber5()
        {
            const int upperBound = 100;

            var toFind = new List<(int, string)>
            {
                (3, "fizz"),
                (5, "buzz"),
                (15, "foo"),
            };
            var actual = _sut.GetFizzBuzz(upperBound, toFind).ToList();

            Assert.AreEqual("buzz", actual[4]);
        }

        [Test]
        public void FizzBuzz_CollectionWithMultipleFindsPartialNumber()
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
        public void FizzBuzz_CollectionWithMultipleFindsNumber6()
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
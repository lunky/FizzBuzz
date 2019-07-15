using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace FizzbuzzTests
{
    public class Tests
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
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // QCW: ToList to trigger enumeration
            Assert.Throws<ArgumentException>(() => _sut.GetFizzBuzz(upperBound).ToList());
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
            var expected = "Fizz Buzz";
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
        public void NumberReplacement_EmptyCollectionPassed()
        {
            const int upperBound = 100;
            var emptyList = new List<(int, string)>();
            var actual = _sut.GetFizzBuzz(upperBound, emptyList).ToList();
            const string expected = "15";
            Assert.AreEqual(expected, actual[14]);
        }

        [Test]
        public void NumberReplacement_CollectionWithOneFindsNumber()
        {
            const int upperBound = 100;
            const string expected = "taco";
            const int expectedNumber = 7;
            var toFind = new List<(int Index, string Name)> { (expectedNumber, expected) };
            var actual = _sut.GetFizzBuzz(upperBound, toFind).ToList();
            Assert.AreEqual(expected, actual[expectedNumber-1]);
        }

        [Test]
        public void NumberReplacement_CollectionWithMultipleFindsNumber()
        {
            const int upperBound = 100;
            const string expected = "airplane";
            const int expectedNumber = 15;
            var toFind = new List<(int Index, string Name)> { (3, "taco"), (expectedNumber, expected), (22, "banana") };
            var actual = _sut.GetFizzBuzz(upperBound, toFind).ToList();
            Assert.AreEqual(expected, actual[expectedNumber-1]);
        }
    }
}
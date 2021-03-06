using System;
using System.Linq;
using NUnit.Framework;
using static OcsicoTraining.Mikhaltsev.Lesson6.FibonacciNumbersGenerator.FibonacciNumbersGenerator;

namespace OcsicoTraining.Mikhaltsev.Lesson6.FibonacciNumbersGenerator.Tests
{
    [TestFixture]
    public class FibonacciNumbersGeneratorTests
    {
        private readonly Random random = new Random();

        [Test]
        public void GenerateNumbers_InputCountOfNumbersIs10_ReturnCollectionWithTenNumbers()
        {
            //arrange
            var expected = 10;

            //act
            var actual = Generate(10).Count();

            //assert
            Assert.AreEqual(expected, actual, "Count of number should be ten");
        }

        [Test]
        public void GenerateNumbers_InputCountOfNumbersIs15_ReturnFifteenthNumberIs377()
        {
            //arrange
            var expected = 377;

            //act
            var actual = Generate(15).Last();

            //assert
            Assert.AreEqual(expected, actual, "Fifteenth number should be 377");
        }

        [Test]
        public void GenerateNumbers_InputNegativeCountOfNumber_ExceptionShould()
        {
            //arrange
            var inputValue = random.Next(int.MinValue, -1);

            //act
            void GetException() => Generate(inputValue).ToList();

            //assert
            Assert.Throws<ArgumentException>(GetException, "Should be ArgumentException");
        }
    }
}

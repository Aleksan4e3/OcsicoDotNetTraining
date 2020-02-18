using System;
using NUnit.Framework;
using static OcsicoTraining.Mikhaltsev.Lesson6.Factorial.FactorialNumber;

namespace OcsicoTraining.Mikhaltsev.Lesson6.Factorial.Tests
{
    [TestFixture]
    public class FactorialNumberTests
    {
        private readonly Random random = new Random();

        [TestCase(5, 120)]
        [TestCase(6, 720)]
        [TestCase(8, 40320)]
        public void ComputeFactorialTest_ShouldReturnCorrectValue(int number, int expectedFactorial)
        {
            //act
            var actual = ComputeFactorial(number);

            //assert
            Assert.AreEqual(expectedFactorial, actual, $"Factorial number {number} should be {expectedFactorial}");
        }

        [Test]
        public void ComputeFactorial_InputNegativeNumber_ExceptionShould()
        {
            //arrange
            var inputValue = random.Next(int.MinValue, -1);

            //act
            void GetException() => ComputeFactorial(inputValue);

            //assert
            Assert.Throws<ArgumentException>(GetException, "Should be ArgumentException");
        }
    }
}

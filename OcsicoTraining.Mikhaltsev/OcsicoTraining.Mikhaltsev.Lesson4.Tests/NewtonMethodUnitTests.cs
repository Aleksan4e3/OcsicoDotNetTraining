using System;
using NUnit.Framework;
using OcsicoTraining.Mikhaltsev.Lesson2.RootPowerN;
using static OcsicoTraining.Mikhaltsev.Lesson2.RootPowerN.NewtonMethod;

namespace OcsicoTraining.Mikhaltsev.Lesson4.Tests
{
    [TestFixture]
    public class NewtonMethodUnitTests
    {
        private readonly Random random = new Random();

        [Test]
        public void PrecisionRootPowerNHigherThenGiven_InputRoot3number28precision001_ReturnTrue()
        {
            //arrange
            var expected = Math.Pow(28, 1d / 3);
            var delta = 0.001;

            //act
            var actual = CalculateRootPowerN(3, 28, 0.001);

            //assert
            Assert.AreEqual(expected, actual, delta, $"Root power 3 of 28 is equals {expected}");
        }

        [Test]
        public void RootPowerN_InputRoot4AndNegativeNumber_ExceptionShould()
        {
            var inputValue = random.Next(int.MinValue, -1);
            _ = Assert.Throws<NumberArgumentException>(() => CalculateRootPowerN(4, inputValue),
                "Should be NumberArgumentException");
        }


        [Test]
        public void RootPowerN_InputRootLessThan1_ExceptionShould()
        {
            var inputValue = random.Next(int.MinValue, 1);
            _ = Assert.Throws<PowerArgumentException>(() => CalculateRootPowerN(inputValue, 10),
                "Should be PowerArgumentException");
        }

        [Test]
        public void RootPowerN_InputNegativePrecision_ExceptionShould()
        {
            var inputValue = random.Next(int.MinValue, -1);
            _ = Assert.Throws<PrecisionArgumentException>(() => CalculateRootPowerN(4, 46, inputValue),
                "Should be PrecisionArgumentException");
        }
    }
}

using System;
using NUnit.Framework;
using static OcsicoTraining.Mikhaltsev.Lesson2.RootPowerN.NewtonMethod;

namespace OcsicoTraining.Mikhaltsev.Lesson4.Tests
{
    [TestFixture]
    public class NewtonMethodUnitTests
    {
        [Test]
        public void PrecisionRootPowerNHigherThenGiven_InputRoot3number28precision001_ReturnTrue()
        {
            var actual = Math.Abs(CalculateRootPowerN(3, 28, 0.001) - Math.Pow(28, 1d / 3)) < 0.001;
            Assert.IsTrue(actual, $"Precision Newton`s method {actual} higher then 0.001");
        }

        [Test]
        public void RootPowerN_InputRoot4NumberMinus30_ExceptionShould() =>
            Assert.Throws<ArgumentException>(() => CalculateRootPowerN(4, -30));

        [Test]
        public void RootPowerN_InputRootMinus3_ExceptionShould() =>
            Assert.Throws<ArgumentException>(() => CalculateRootPowerN(-3, 27));
    }
}

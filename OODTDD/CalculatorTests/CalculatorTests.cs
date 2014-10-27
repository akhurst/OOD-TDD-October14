using System;
using NUnit.Framework;

namespace CalculatorTests
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator calc;
        [SetUp]
        public void SetUp()
        {
            calc = new Calculator();
        }

        [Test]
        public void TestAdd()
        {
            calc = new Calculator();

            var sum = calc.Add(1.2, 3.3);

            Assert.AreEqual(sum, 4.5);

        }

        [Test]
        public void TestMultiply()
        {
            calc = new Calculator();

            var mult = calc.Multiply(4, 5);

            Assert.AreEqual(mult, 20);
        }

        [Test]
        public void TestDivide()
        {
            calc = new Calculator();

            var div = calc.Divide(20, 2);

            Assert.AreEqual(div, 10);
        }

        [Test]
        public void TestDivideByZero()
        {
            Assert.Throws<DivideByZeroException>(() => calc.Divide(4, 0));
        }
    }
}

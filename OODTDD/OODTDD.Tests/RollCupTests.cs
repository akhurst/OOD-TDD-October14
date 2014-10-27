using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace OODTDD.Tests
{
    [TestFixture]
    public class RollCupTests
    {
        private List<int> results;

        [TestFixtureSetUp]
        public virtual void SetUp()
        {
            var cup = new Cup(2);
            results = cup.SetUp1000000Results();
        }


        [Test]
        public void ShouldRollAValidNumber()
        {
            foreach (var result in results)
            {
                Assert.That(result, Is.GreaterThan(1));
                Assert.That(result, Is.LessThan(13));
            }
        }

        [Test]
        public void ShouldProduceAllNumbers()
        {
            for (int i = 2; i <= 12; i++)
            {
                Assert.IsTrue(results.Any(r => r == i), i + " not found");
            }
        }
    }
}

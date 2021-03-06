﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using OODTDD;

namespace OODTDD.Tests
{
    [TestFixture]
    public class RollDieTests
    {
        private List<int> results;

        // These are slow and potentially error prone. We are leaving them here because we have trouble letting go....
        [TestFixtureSetUp]
        public virtual void SetUp()
        {
            var die = RollableFactory.GetSingleDie();
            results = die.SetUp1000000Results();
        }


        [Test]
        public void ShouldRollAValidNumber()
        {
            foreach (var result in results)
            {
                Assert.That(result, Is.GreaterThan(0));
                Assert.That(result, Is.LessThan(7));
            }
        }

        [Test]
        public void ShouldProduceAllNumbers()
        {
            for (int i = 1; i <= 6; i++)
            {
                Assert.IsTrue(results.Any(r => r == i), i + " not found");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace OODTDD.Tests
{
    [TestFixture]
    public class CupBehaviorTests
    {
        private IRandomizer randomizer;
        private Cup cup;

        [SetUp]
        public virtual void SetUp()
        {
            randomizer = Substitute.For<IRandomizer>();
            randomizer.GetRandomNumber(1, 6).Returns(6);
            cup = new Cup(2, randomizer);
        }

        [Test]
        public void ShouldProduceTheCorrectNumberOfDieRolls()
        {
            cup.Roll();
            randomizer.Received(2).GetRandomNumber(1,6);
        }

        [Test]
        public void ShouldProduceTheCorrectRollValue()
        {
            cup.Roll();
            cup.LastValue.Should().Be(12);
        }
    }
}

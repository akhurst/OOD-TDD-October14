using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace OODTDD.Tests
{
    public class DieBehaviorTests
    {
        [Test]
        public void ShouldRetainItsState()
        {
            var die = new Die();

            var rollResult = die.Roll();

            var faceValue = die.LastValue;

            Assert.That(rollResult, Is.EqualTo(faceValue));
        }
    }
}

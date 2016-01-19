using System;
using NUnit.Framework;

namespace EmptyProject.Tests
{
    [TestFixture(TestOf = typeof(Ability))]
    public class AbilityTests
    {
        [Test]
        public void AbilitiesAreImplicitlyAnInteger()
        {
            Ability awesomeness = 20;
            Assert.That(awesomeness.Score, Is.EqualTo(20));
        }

        [TestCase(0)]
        [TestCase(21)]
        [TestCase(Int32.MaxValue)]
        [TestCase(Int32.MinValue)]
        public void IfNotInRangeExceptionIsThrown(int outOfRangeValue)
        {
            TestDelegate testCase = () => { Ability willThrow = outOfRangeValue; };
            Assert.That(testCase, Throws.Exception.InstanceOf<ArgumentOutOfRangeException>());
        }

        [TestCase(1, -5)]
        [TestCase(2, -4)]
        [TestCase(3, -4)]
        [TestCase(4, -3)]
        [TestCase(5, -3)]
        [TestCase(6, -2)]
        [TestCase(7, -2)]
        [TestCase(8, -1)]
        [TestCase(9, -1)]
        [TestCase(10, 0)]
        [TestCase(11, 0)]
        [TestCase(12, 1)]
        [TestCase(13, 1)]
        [TestCase(14, 2)]
        [TestCase(15, 2)]
        [TestCase(16, 3)]
        [TestCase(17, 3)]
        [TestCase(18, 4)]
        [TestCase(19, 4)]
        [TestCase(20, 5)]
        public void AbilitiesHaveModifier(int score, int expectedModifier)
        {
            Ability awesomeness = score;
            Assert.That(awesomeness.Modifier, Is.EqualTo(expectedModifier));
        }
    }
}
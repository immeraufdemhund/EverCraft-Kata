using NUnit.Framework;

namespace EmptyProject.Tests
{
    [TestFixture(TestOf = (typeof(Ability)))]
    public class AbilityTests
    {
        [Test]
        public void AbilityIsImplicitySetFromInteger()
        {
            Ability a = 10;
            Assert.That(a.Score, Is.EqualTo(10));
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
        public void AbilityModifierIsBasedOffOfScore(int score, int expectedHp)
        {
            Ability ability = score;

            Assert.That(ability.Modifier, Is.EqualTo(expectedHp));
        }
    }
}
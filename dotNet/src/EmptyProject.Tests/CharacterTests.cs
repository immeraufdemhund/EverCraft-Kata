using NUnit.Framework;

namespace EmptyProject.Tests
{
    [TestFixture(TestOf = typeof(Character))]
    public class CharacterTests
    {
        private Character _hero;
        private Character _enemy;

        [SetUp]
        public void Setup()
        {
            _hero = new Character();
            _enemy = new Character();
        }

        [Test]
        public void RollMustMeetOrBeatOpponentsArmorClassToHit()
        {
            var hit = _hero.Attack(_enemy, _enemy.ArmorClass - 1);
            Assert.That(hit, Is.EqualTo(false));

            hit = _hero.Attack(_enemy, _enemy.ArmorClass);
            Assert.That(hit, Is.EqualTo(true));

            hit = _hero.Attack(_enemy, _enemy.ArmorClass + 1);
            Assert.That(hit, Is.EqualTo(true));
        }

        [Test]
        public void WhenAttackIsSuccessfulOtherCharacterTakesOnePointOfDamage()
        {
            var currentHitPoints = _enemy.HitPoints;

            var hit = _hero.Attack(_enemy, _enemy.ArmorClass);

            Assert.That(_enemy.HitPoints, Is.EqualTo(currentHitPoints - 1));
        }

        [Test]
        public void WhenAttackIsCriticalHitOtherCharacterDakesDoubleDamage()
        {
            var currentHitPoints = _enemy.HitPoints;

            var hit = _hero.Attack(_enemy, 20);

            Assert.That(_enemy.HitPoints, Is.EqualTo(currentHitPoints - 2));
        }

        [Test]
        public void WhenHitPointsAreZeroOrLessCharacterIsDead()
        {
            while (_enemy.HitPoints > 0)
                _hero.Attack(_enemy, _enemy.ArmorClass);

            Assert.That(_enemy.HitPoints, Is.EqualTo(0));
            Assert.That(_enemy.IsDead);

            _hero.Attack(_enemy, _enemy.ArmorClass);
            Assert.That(_enemy.HitPoints, Is.EqualTo(-1));
            Assert.That(_enemy.IsDead);
        }
    }
}
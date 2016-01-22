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

        [Test]
        public void WhenASuccessfulAttackOccursTheCharacterGains10Xp()
        {
            Assert.That(_hero.ExperiencePoints, Is.EqualTo(0));
            Assert.That(_hero.Attack(_enemy, _enemy.ArmorClass - 1), Is.False);

            Assert.That(_hero.ExperiencePoints, Is.EqualTo(0));
            Assert.That(_hero.Attack(_enemy, _enemy.ArmorClass), Is.True);

            Assert.That(_hero.ExperiencePoints, Is.EqualTo(10));
        }

        [Test]
        public void CharacterDefaultLevelIsOne()
        {
            Assert.That(_hero.Level, Is.EqualTo(1));
        }

        [Test]
        public void WhenCharacterExperianceGains1000XpCharacterGainsLevel()
        {
            LevelHeroUpTo(2);

            Assert.That(_hero.ExperiencePoints, Is.GreaterThanOrEqualTo(1000));
            Assert.That(_hero.Level, Is.EqualTo(2));

            LevelHeroUpTo(3);

            Assert.That(_hero.ExperiencePoints, Is.GreaterThanOrEqualTo(2000));
            Assert.That(_hero.Level, Is.EqualTo(3));
        }

        private void LevelHeroUpTo(int desiredLevel)
        {
            var deadHorse = new Character();
            while (_hero.ExperiencePoints < (desiredLevel - 1) * 1000)
                _hero.Attack(deadHorse, deadHorse.ArmorClass);
        }

        [Test]
        public void WhenCharacterLevelsUpStatsIncrease()
        {
            _hero.SetConstitution(14);
            var currentHp = _hero.HitPoints;

            var deadHorse = new Character();
            while (_hero.ExperiencePoints < 1000)
                _hero.Attack(deadHorse, deadHorse.ArmorClass);

            Assert.That(_hero.HitPoints, Is.EqualTo(currentHp + 5 + _hero.Constitution.Modifier));
        }

        [Test]
        public void OneIsAddedToAttackRollForEveryEvenLevelAcheived()
        {
            LevelHeroUpTo(2);

            Assert.That(_hero.Strength.Modifier, Is.EqualTo(0));
            Assert.That(_hero.Attack(_enemy, _enemy.ArmorClass - 1), Is.True);
        }
    }
}
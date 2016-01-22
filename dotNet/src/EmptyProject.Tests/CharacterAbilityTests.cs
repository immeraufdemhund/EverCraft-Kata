using NUnit.Framework;

namespace EmptyProject.Tests
{
    [TestFixture(TestOf = typeof(Character))]
    public class CharacterAbilityTests
    {
        private Character npc;
        private Character enemy;

        [SetUp]
        public void Setup()
        {
            npc = new Character();

            enemy = new Character();
        }

        [Test]
        public void AddStrengthModifierToAttackRollAndDamageDealt()
        {
            npc.SetStrength(12);
            var modifier = npc.Strength.Modifier;
            var hitPoints = enemy.HitPoints;
            var expectedDamage = (1) + modifier;

            var success = npc.Attack(enemy, enemy.ArmorClass - modifier);

            Assert.That(success, Is.True);
            Assert.That(enemy.HitPoints, Is.EqualTo(hitPoints - expectedDamage));
        }

        [Test]
        public void DoubleStrengthModifierOnCriticalHit()
        {
            npc.SetStrength(12);
            var modifier = npc.Strength.Modifier * 2;
            var hitPoints = enemy.HitPoints;
            var expectedDamage = (1 * 2) + modifier;

            var success = npc.Attack(enemy, 20);

            Assert.That(success, Is.True);
            Assert.That(enemy.HitPoints, Is.EqualTo(hitPoints - expectedDamage));
        }

        [Test]
        public void ArmorClassIncludesDexterityModifier()
        {
            var beforeArmorClass = npc.ArmorClass;
            npc.SetDexterity(12);

            Assert.That(npc.Dexterity.Modifier, Is.GreaterThan(0));
            Assert.That(npc.ArmorClass, Is.EqualTo(beforeArmorClass + npc.Dexterity.Modifier));
        }

        [Test]
        public void HitPointsIncludesConstitutionModifier()
        {
            var beforeHitPoints = npc.HitPoints;
            npc.SetConstitution(12);

            Assert.That(npc.Constitution.Modifier, Is.GreaterThan(0));
            Assert.That(npc.HitPoints, Is.EqualTo(beforeHitPoints + npc.Constitution.Modifier));
        }
    }
}
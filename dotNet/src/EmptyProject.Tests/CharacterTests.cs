using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EmptyProject;
using NUnit.Framework;

namespace EmptyProject.Tests
{
    [TestFixture(TestOf = (typeof(Character)))]
    public class CharacterTests
    {
        private Character npc;
        private Character enemy;

        [SetUp]
        public void setup()
        {
            npc = new Character();
            enemy = new Character();
        }

        [TestCase(10, 4)]
        [TestCase(9, 5)]
        [TestCase(20, 3)]
        public void CharacterCanBeDamaged(int hitRoll, int expectedHp)
        {
            npc.Attack(enemy, hitRoll);

            Assert.That(enemy.HitPoints, Is.EqualTo(expectedHp));
        }

        [Test]
        public void CharacterCanDie()
        {
            while (enemy.HitPoints > 0)
                npc.Attack(enemy, 10);

            Assert.That(enemy.IsDead);
        }

        [Test]
        public void StrengthModifierGetsAddedToAttackRollAndDamageDealt()
        {
            npc.Abilities.Strength = 12;
            var hitPoints = enemy.HitPoints;

            var success = npc.Attack(enemy, enemy.ArmorClass - npc.Abilities.Strength.Modifier);

            Assert.That(success, Is.True);
            Assert.That(enemy.HitPoints, Is.EqualTo(hitPoints - 1 - npc.Abilities.Strength.Modifier));
        }

        [Test]
        public void DoubleStrengthModifierOnCriticalHits()
        {
            npc.Abilities.Strength = 12;
            var hitPoints = enemy.HitPoints;
            var modifier = npc.Abilities.Strength.Modifier;

            var success = npc.Attack(enemy, 20);

            Assert.That(success, Is.True);
            Assert.That(enemy.HitPoints, Is.EqualTo(hitPoints - (1 * 2) - (modifier * 2)));
        }
    }
}
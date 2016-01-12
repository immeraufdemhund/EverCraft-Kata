using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EmptyProject;
using NUnit.Framework;

namespace EmptyProject.Tests
{
    [TestFixture]
    public class CharacterTests
    {
        [TestCase(10, 4)]
        [TestCase(9, 5)]
        [TestCase(20, 3)]
        public void CharacterCanBeDamaged(int hitRoll, int expectedHp)
        {
            var enemy = new Character();

            enemy.AcceptAttack(hitRoll);

            Assert.That(enemy.HitPoints, Is.EqualTo(expectedHp));
        }

        [Test]
        public void CharacterCanDie()
        {
            var enemy = new Character();

            enemy.AcceptAttack(20);//3
            enemy.AcceptAttack(20);//1
            enemy.AcceptAttack(10);//0

            Assert.That(enemy.IsDead);
        }
    }
}
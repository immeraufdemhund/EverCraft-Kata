using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmptyProject
{
    public class Character
    {
        public string Name { get; set; }
        public Alignment Alignment { get; set; }
        public int ArmorClass { get; private set; }
        public int HitPoints { get; private set; }
        public bool IsDead { get { return HitPoints <= 0; } }
        public Ability Strength, Dexterity, Constitution, Wisdom, Intelligence, Charisma;

        public Character()
        {
            ArmorClass = 10;
            HitPoints = 5;
            //Strength= Dexterity= Constitution= Wisdom= Intelligence= Charisma = 10;
        }

        public bool Attack(Character enemy, int hitRoll)
        {
            var damage = 1;
            var isCritHit = hitRoll == 20;
            var isHit = hitRoll >= enemy.ArmorClass;

            if (!isHit) return false;

            if (isCritHit)
                damage *= 2;

            enemy.TakeDamage(damage);

            return isHit;
        }

        private void TakeDamage(int damage)
        {
            HitPoints -= damage;
        }
    }
}
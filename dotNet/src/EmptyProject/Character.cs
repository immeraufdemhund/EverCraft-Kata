using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmptyProject
{
    public class Character
    {
        public string Name { get; set; }

        public Alignment CharacterAlignment { get; set; }

        public int ArmorClass { get { return 10; } }
        public int HitPoints { get; private set; }

        public bool IsDead { get { return HitPoints <= 0; } }

        public AbilityScores Abilities { get; private set; }

        public Character()
        {
            HitPoints = 5;
            Abilities = new AbilityScores();
        }

        public bool Attack(Character enemy, int hitRoll)
        {
            var damage = 1;
            var isCritHit = hitRoll == 20;
            var modifier = Abilities.Strength.Modifier;
            hitRoll += modifier;
            var isHit = hitRoll >= ArmorClass;
            if (isHit)
                damage += modifier;

            if (isCritHit)
                damage = damage * 2;

            if (isHit)
                enemy.TakeDamage(damage);

            return isHit;
        }

        private void TakeDamage(int damage)
        {
            HitPoints -= damage;
        }
    }
}
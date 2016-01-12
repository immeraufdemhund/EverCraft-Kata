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

        public void AcceptAttack(int hitRoll)
        {
            var damage = 0;
            if (hitRoll >= ArmorClass)
                damage++;
            if (hitRoll == 20)
                damage = damage * 2;

            HitPoints -= damage;
        }
    }
}
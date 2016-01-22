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
        public int ExperiencePoints { get; private set; }
        public int Level { get; private set; }
        public Ability Strength { get; private set; }
        public Ability Dexterity { get; private set; }
        public Ability Constitution { get; private set; }
        public Ability Wisdom { get; private set; }
        public Ability Intelligence { get; private set; }
        public Ability Charisma { get; private set; }

        public Character()
        {
            Strength = Dexterity = Constitution = Wisdom = Intelligence = Charisma = 10;
            HitPoints = 5;
            ArmorClass = 10;
            Level = 1;
        }

        public void SetStrength(int newScore)
        {
            Strength = newScore;
        }

        public void SetDexterity(int newScore)
        {
            Dexterity = newScore;
            ArmorClass = 10 + Dexterity.Modifier;
        }

        public void SetConstitution(int newScore)
        {
            Constitution = newScore;
            HitPoints = 5 + Constitution.Modifier;
        }

        public void SetWisdom(int newScore)
        {
            Wisdom = newScore;
        }

        public void SetIntelligence(int newScore)
        {
            Intelligence = newScore;
        }

        public void SetCharisma(int newScore)
        {
            Charisma = newScore;
        }

        public bool Attack(Character enemy, int hitRoll)
        {
            hitRoll = AdjustHitRollForLevel(hitRoll);

            var damage = 1 + Strength.Modifier;
            var isCritHit = hitRoll == 20;
            var isHit = hitRoll + Strength.Modifier >= enemy.ArmorClass;

            if (!isHit) return false;

            if (isCritHit)
                damage *= 2;

            enemy.TakeDamage(damage);
            ExperiencePoints += 10;

            TryLevelUp();

            return isHit;
        }

        private int AdjustHitRollForLevel(int hitRoll)
        {
            for (int i = 1; i <= Level; i++)
            {
                if (i % 2 == 0)
                    hitRoll += 1;
            }

            return hitRoll;
        }

        private void TryLevelUp()
        {
            if ((Level * 1000) <= ExperiencePoints)
                LevelUp();
        }

        private void LevelUp()
        {
            Level++;
            HitPoints += 5 + Constitution.Modifier;
        }

        private void TakeDamage(int damage)
        {
            HitPoints -= damage;
        }
    }
}
namespace EmptyProject
{
    public class AbilityScores
    {
        public Ability Strength { get; set; }
        public Ability Dexterity { get; set; }
        public Ability Constitution { get; set; }
        public Ability Wisdom { get; set; }
        public Ability Intelligence { get; set; }
        public Ability Charisma { get; set; }

        public AbilityScores()
        {
            Strength = Dexterity = Constitution = Wisdom = Intelligence = Charisma = 10;
        }
    }
}
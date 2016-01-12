namespace EmptyProject
{
    public class AbilityScores
    {
        public int Strength { get; private set; }
        public int Dexterity { get; private set; }
        public int Constitution { get; private set; }
        public int Wisdom { get; private set; }
        public int Intelligence { get; private set; }
        public int Charisma { get; private set; }

        private Ability strength, dexerity, constitution, wisdom, intelligence, charsima;

        public AbilityScores()
        {
            Strength = Dexterity = Constitution = Wisdom = Intelligence = Charisma = 10;
        }
    }
}
namespace EmptyProject
{
    public class Ability
    {
        public int Score { get; private set; }
        public int Modifier { get; private set; }

        private Ability(int score)
        {
            Score = score;
            Modifier = (int)(System.Math.Floor((score - 10) / 2.0));
        }

        public static implicit operator Ability(int score)
        {
            if (score < 1 || score > 20) throw new System.ArgumentOutOfRangeException("value", score, "All Abilities must be between range of 1 and 20 inclusive");
            return new Ability(score);
        }
    }
}
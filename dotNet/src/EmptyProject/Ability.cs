namespace EmptyProject
{
    public class Ability
    {
        public int Score { get; private set; }
        public int Modifier { get; private set; }

        private Ability(int score)
        {
            Score = score;
            Modifier = (int)System.Math.Floor((score - 10) / 2.0);
        }

        public static implicit operator Ability(int score)
        {
            return new Ability(score);
        }
    }
}
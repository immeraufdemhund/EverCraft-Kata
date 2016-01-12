namespace EmptyProject
{
    public class Ability
    {
        public int Score { get; private set; }
        public int Modifier { get; private set; }

        public Ability()
        {
            SetScore(10);
        }

        public void SetScore(int score)
        {
            Score = score;

            switch (Score)
            {
                case 1: Modifier = -5; break;
                case 2: Modifier = -4; break;
                case 3: Modifier = -4; break;
                case 4: Modifier = -3; break;
                case 5: Modifier = -3; break;
                case 6: Modifier = -2; break;
                case 7: Modifier = -2; break;
                case 8: Modifier = -1; break;
                case 9: Modifier = -1; break;
                case 10: Modifier = 0; break;
                case 11: Modifier = 0; break;
                case 12: Modifier = 1; break;
                case 13: Modifier = 1; break;
                case 14: Modifier = 2; break;
                case 15: Modifier = 2; break;
                case 16: Modifier = 3; break;
                case 17: Modifier = 3; break;
                case 18: Modifier = 4; break;
                case 19: Modifier = 4; break;
                case 20: Modifier = 5; break;
            }
        }
    }
}
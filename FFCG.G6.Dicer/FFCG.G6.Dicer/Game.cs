namespace FFCG.G6.Dicer
{
    public class Game
    {
        private readonly IDice _dice;

        public int LatestRoll { get; private set; }
        public bool IsPlaying { get; private set; }
        public int Score { get; private set; }

        public Game(IDice dice)
        {
            _dice = dice;
        }

        public void Start()
        {
            LatestRoll = _dice.Roll();
            IsPlaying = true;
        }

        public void GuessHigher()
        {
            var newRoll = _dice.Roll();

            if (newRoll > LatestRoll)
            {
                Score++;
            }
            else if (newRoll < LatestRoll)
            {
                IsPlaying = false;
            }

            LatestRoll = newRoll;
        }

        public void GuessLower()
        {
            var newRoll = _dice.Roll();

            if (newRoll < LatestRoll)
            {
                Score++;
            }
            else if (newRoll > LatestRoll)
            {
                IsPlaying = false;
            }

            LatestRoll = newRoll;
        }
    }
}
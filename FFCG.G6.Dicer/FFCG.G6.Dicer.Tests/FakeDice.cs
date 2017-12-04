namespace FFCG.G6.Dicer.Tests
{
    public class FakeDice : IDice
    {
        private readonly int[] _rolls;
        private int _currentRollIndex;

        public FakeDice(params int[] rolls)
        {
            _rolls = rolls;
        }

        public int Roll()
        {
            var roll = _rolls[_currentRollIndex];
            _currentRollIndex++;
            return roll;
        }
    }
}
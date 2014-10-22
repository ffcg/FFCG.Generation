namespace FFCG.Bingo
{
    public class Square
    {
        public bool Checked { get; private set; }
        public int Number { get; private set; }

        public Square(int number)
        {
            Checked = false;
            Number = number;
        }

        public void Check()
        {
            Checked = true;
        }

        public override string ToString()
        {
            if (Checked)
                return "X";

            return Number.ToString();
        }
    }
}
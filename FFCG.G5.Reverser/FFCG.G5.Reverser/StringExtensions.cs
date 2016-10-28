namespace FFCG.G5.Reverser
{
    public static class StringExtensions
    {
        //https://msdn.microsoft.com/en-us//library/bb383977.aspx
        public static string ReverseSentence(this string sentence)
        {
            var reverser = new Reverser();
            return reverser.Reverse(sentence);
        }
    }
}
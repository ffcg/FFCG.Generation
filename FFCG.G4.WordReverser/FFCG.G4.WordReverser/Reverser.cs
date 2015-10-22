using System.Linq;

namespace FFCG.G4.WordReverser
{
    public class Reverser
    {
        public string ReverseSentence(string sentence)
        {
            return sentence;
        }

        private static string AddSpaceAfterCurrentWord(string reversedSentence)
        {
            reversedSentence += " ";
            return reversedSentence;
        }

        private static string RemoveLastAddedSpace(string reversedSentence)
        {
            return reversedSentence.TrimEnd(' ');
        }

        private static string[] WordsInSentence(string sentence)
        {
            return sentence.Split(' ');
        }
    }
}
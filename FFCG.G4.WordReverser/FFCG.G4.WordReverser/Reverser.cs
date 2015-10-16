using System.Linq;

namespace FFCG.G4.WordReverser
{
    public class Reverser
    {
        public string ReverseSentence(string sentence)
        {
            var reversedSentence = string.Empty;

            foreach (var word in WordsInSentence(sentence))
            {
                foreach (var letter in word.Reverse())
                {
                    reversedSentence += letter.ToString();
                }

                reversedSentence = AddSpaceAfterCurrentWord(reversedSentence);
            }

            return RemoveLastAddedSpace(reversedSentence);
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
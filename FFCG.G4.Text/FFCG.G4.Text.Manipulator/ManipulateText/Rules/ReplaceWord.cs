using System.Collections.Generic;
using System.Linq;

namespace FFCG.G4.Text.Manipulator.ManipulateText.Rules
{
    public class ReplaceWord : IManipulateTextRule
    {
        private readonly Dictionary<string, string> _wordsToReplace;

        public ReplaceWord(Dictionary<string, string> wordsToReplace)
        {
            _wordsToReplace = wordsToReplace;
        }

        public string Manipulate(string text)
        {
            return _wordsToReplace.Aggregate(text, (current, word) => current.Replace(word.Key, word.Value));
        }
    }
}
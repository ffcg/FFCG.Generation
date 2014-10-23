using System.Collections.Generic;
using System.Linq;

namespace FFCG.Reverser
{
    public class WordReverser
    {
        private readonly string[] _specialCharacters = {".", ",", "!", "?"};

        public string Reverse(string text)
        {
            string paddedText = Prepare(text);
            var allWords = paddedText.Split(' ').ToList();
            int totaltNumberOfWords = allWords.Count();

            var specials = ExtractSpecialCharacters(allWords).ToList();
            var onlyWords = RemoveSpecialCharacters(allWords).Reverse().ToList();

            var result = new List<string>();

            for (int index = 0; index < totaltNumberOfWords; index++)
            {
                string word = "";
                if (onlyWords.Count() > index)
                    word = onlyWords[index];

                var specialCharacter = specials.FirstOrDefault(x => x.Index == index);
                if(specialCharacter != null)
                    result.Add(specialCharacter.Character);

                result.Add(word);
            }

            var joinedString = string.Join(" ", result).Trim();

            return Rebuild(joinedString);
        }

        private string Rebuild(string text)
        {
            foreach (var specialCharacter in _specialCharacters)
            {
                text = text.Replace(" " + specialCharacter, specialCharacter);
            }

            return text;
        }

        private IEnumerable<string> RemoveSpecialCharacters(List<string> allWords)
        {
            allWords.RemoveAll(x => _specialCharacters.Contains(x));

            return allWords;
        }

        private IEnumerable<SpecialCharacter> ExtractSpecialCharacters(List<string> allWords)
        {
            for (int index = 0; index < allWords.Count; index++)
            {
                var word = allWords[index];
                if(_specialCharacters.Contains(word))
                    yield return new SpecialCharacter(index, word);
            }
        }

        private string Prepare(string text)
        {
            foreach (var specialCharacter in _specialCharacters)
            {
                text = text.Replace(specialCharacter, " " + specialCharacter);
            }

            return text;
        }
    }

    public class SpecialCharacter
    {
        public int Index { get; private set; }
        public string Character { get; private set; }

        public SpecialCharacter(int index, string character)
        {
            Index = index;
            Character = character;
        }
    }
}

using System.Linq;
using System.Text;

namespace FFCG.G5.Reverser
{
    public class Reverser
    {
        public string Reverse(string sentence)
        {
            //StringBuilder https://msdn.microsoft.com/en-us/library/2839d5h5(v=vs.110).aspx
            var result = new StringBuilder();
            foreach (var word in sentence.Split())
            {
                var reversedWord = word.ToLower().Reverse().ToArray();

                //LINQ https://msdn.microsoft.com/en-us/library/bb397933.aspx
                var indexOfUppercaseChars = word.Where(char.IsUpper).Select(x => word.IndexOf(x)).ToList();

                //List<T>.ForEach Method https://msdn.microsoft.com/en-us/library/bwabdf9z(v=vs.110).aspx
                indexOfUppercaseChars.ForEach(x => reversedWord[x] = char.ToUpper(reversedWord[x]));

                result.Append($"{string.Join(string.Empty, reversedWord)} ");
            }

            return result.ToString().TrimEnd();
        }
    }
}
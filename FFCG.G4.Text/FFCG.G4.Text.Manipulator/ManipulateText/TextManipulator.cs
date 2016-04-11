using System.Collections.Generic;
using System.Linq;

namespace FFCG.G4.Text.Manipulator.ManipulateText
{
    public static class TextManipulator
    {
        public static string Manipulate(this string text, List<IManipulateTextRule> rules)
        {
            foreach (var rule in rules)
                text = rule.Manipulate(text);

            return text;
        }
    }
}
using System;
using System.Collections.Generic;
using FFCG.G4.Text.Manipulator.ManipulateText;
using FFCG.G4.Text.Manipulator.ManipulateText.Rules;
using FFCG.G4.Text.Manipulator.ReadText;
using FFCG.G4.Text.Manipulator.WriteText;

namespace FFCG.G4.Text.App
{
    class Program
    {
        static void Main(string[] args)
        {
            IReadText readText = new ReadFromString();
            IWriteText writeTextToString = new TextToStringWriter();

            var text = readText.Read().Manipulate(GetManipulatorRules());
            Console.Write(writeTextToString.Write(text));

            Console.ReadLine();
        }

        private static List<IManipulateTextRule> GetManipulatorRules()
        {
            return new List<IManipulateTextRule> { new ReplaceWord(GetWordsToReplace()) };
        }

        private static Dictionary<string, string> GetWordsToReplace()
        {
            return new Dictionary<string, string>
            {
                {"Företaget", "Forefront"},
                {"applikationerna", "systemen"},
                {"annorlunda", "tvärtom"},
                {"bra", "flexibla"},
                {"offshore", "Frontshore"},
                {"China", "Kina"}
            };
        }
    }
}

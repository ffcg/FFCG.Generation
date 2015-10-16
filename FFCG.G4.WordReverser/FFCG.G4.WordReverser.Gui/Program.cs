using System;

namespace FFCG.G4.WordReverser.Gui
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter sentence: ");
            var sentence = Console.ReadLine();

            var reverser = new Reverser();
            var reversedSentence = reverser.ReverseSentence(sentence);
            Console.WriteLine(reversedSentence);
        }
    }
}

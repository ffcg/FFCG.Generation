using NUnit.Framework;

namespace FFCG.Reverser.Tests
{
    [TestFixture]
    public class WordReverserTests
    {
        [Test]
        public void Reverse_WithOneWord_ReturnsThatWord()
        {
            ArrangeActAssert("hello", "hello");
        }

        [Test]
        public void Reverse_WithTwoWords_ReturnsWordsInReversedOrder()
        {
            ArrangeActAssert("hello world", "world hello");
        }

        [TestCase("hello glorious world", "world glorious hello")]
        [TestCase("hello glorious world ohoy", "ohoy world glorious hello")]
        public void Reverse_WithUnkownAmountOfWords_ReturnsWordsInReversedOrder(string given, string expected)
        {
            ArrangeActAssert(given, expected);
        }

        [TestCase("hello world!", "world hello!")]
        [TestCase("how are you?", "you are how?")]
        [TestCase("hello, world", "world, hello")]
        public void Reverse_WithSpecialCharacters_ReturnsWordsInReversedOrderWithSpecialCharactersInPlace(string given, string expected)
        {
            ArrangeActAssert(given, expected);
        }

        private static void ArrangeActAssert(string given, string expected)
        {
            var wordReverser = new WordReverser();
            string result = wordReverser.Reverse(given);
            Assert.AreEqual(expected, result);
        }
    }
}
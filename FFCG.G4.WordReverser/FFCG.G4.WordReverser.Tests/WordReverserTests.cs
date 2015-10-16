using NUnit.Framework;

namespace FFCG.G4.WordReverser.Tests
{
    [TestFixture]
    public class WordReverserTests
    {
        private Reverser _reverser;

        [SetUp]
        public void SetUp()
        {
            _reverser = new Reverser();
        }

        [Test]
        public void Should_be_able_to_reverse_sentence_with_one_word()
        {
            var result = _reverser.ReverseSentence("hello");

            Assert.AreEqual(result, "olleh");
        }

        [Test]
        public void Should_be_able_to_reverse_sentence_with_multiple_words()
        {
            var result = _reverser.ReverseSentence("Hello world");

            Assert.AreEqual("olleH dlrow", result);
        }
    }
}

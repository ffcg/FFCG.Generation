using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FFCG.G5.Reverser.Tests
{
    [TestClass]
    public class ReverserTests
    {
        private Reverser _reverser;

        [TestInitialize]
        public void SetUp()
        {
            _reverser = new Reverser();
        }

        [TestMethod]
        public void Should_reverse_one_word()
        {
            string result = _reverser.Reverse("hello");
            Assert.AreEqual("olleh", result);
        }

        [TestMethod]
        public void Should_reverse_words_in_sentence_and_keep_them_in_place()
        {
            string result = _reverser.Reverse("hello world");
            Assert.AreEqual("olleh dlrow", result);
        }

        [TestMethod]
        public void Should_keep_uppercase_positions()
        {
            string result = _reverser.Reverse("For the Win");
            Assert.AreEqual("Rof eht Niw", result);
        }
    }
}

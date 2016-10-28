using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FFCG.G5.Reverser.Tests
{
    [TestClass]
    public class StringExtensionsTests
    {
        [TestMethod]
        public void Should_be_able_to_reverse_a_sentence()
        {
            Assert.AreEqual("For the Win", "Rof eht Niw".ReverseSentence());
        }
    }
}
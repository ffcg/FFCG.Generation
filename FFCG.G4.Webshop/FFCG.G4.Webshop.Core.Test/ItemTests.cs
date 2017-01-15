using NUnit.Framework;

namespace FFCG.G4.Webshop.Core.Test
{
    [TestFixture]
    public class ItemTests
    {
        [Test]
        public void Should_Be_Created_With_Generated_Id()
        {
            Assert.That(!string.IsNullOrEmpty(new Item().Id));
        }
    }
}

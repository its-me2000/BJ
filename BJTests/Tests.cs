using Microsoft.VisualStudio.TestTools.UnitTesting;
using BJ;

namespace BJTests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void TestCard()
        {
            Card card = new Card(CardSuit.HEARTS, CardValue.ACE);
            Assert.AreEqual("HA", card.ToString(),"Bad card constructed.");
        }
    }
}

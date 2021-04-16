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
            Card card1 = new Card(0, 0);
            Assert.ThrowsException<System.Collections.Generic.KeyNotFoundException>(() => card1.ToString());
        }

        [TestMethod]
        public void TestBJHand()
        {
            Hand hand = new BJHand();
            Card card = new Card(CardSuit.DIAMONDS, CardValue.FIVE);
            hand.TakeCard(card);
            card = new Card(CardSuit.SPADES, CardValue.KING);
            hand.TakeCard(card);
            card = new Card(CardSuit.CLUBS, CardValue.TEN);
            hand.TakeCard(card);
            Assert.AreEqual(25u, hand.GetHandValue(), "Wrong hand value calculation.");
            Assert.ThrowsException<System.NotImplementedException>(() => _ = hand.ThrowCard(0));
            hand.ResetHand();
            Assert.AreEqual(0u, hand.GetHandValue(), "Wrong hand value calculation after reset");
        }
    }
}

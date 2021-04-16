using Microsoft.VisualStudio.TestTools.UnitTesting;
using BJ;
using System.Collections.Generic;

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

        [TestMethod]
        public void TestDealerPlayerStrategy()
        {
            Player p1 = new BJPlayer("Player1", new BJThresholdPlayerStrategy());
            Player p2 = new BJPlayer("Player2", new BJThresholdPlayerStrategy());
            Player p3 = new BJPlayer("Player3", new BJThresholdPlayerStrategy());

            List<Player> list = new List<Player>();
            list.Add(p1);
            list.Add(p2);

            Table table = new BJTable(list, p3);

            PlayerStrategy strategy = new BJDealerPlayerStrategy();

            Assert.AreEqual(true, strategy.IsWaitingForCard(p1, table), "Bad dealer strategy when 0.");

            p1.TakeCard(new Card(CardSuit.CLUBS, CardValue.ACE));

            Assert.AreEqual(false, strategy.IsWaitingForCard(p1, table), "Bad dealer strategy when 11.");

            p1.TakeCard(new Card(CardSuit.CLUBS, CardValue.ACE));

            Assert.AreEqual(false, strategy.IsWaitingForCard(p1, table), "Bad dealer strategy when 22");
        }
    }
}

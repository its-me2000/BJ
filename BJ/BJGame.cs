using System.Collections.Generic;

namespace BJ
{
    public class BJGame : Game
    {
        private readonly Table table;
        private CardDeck deck;
        private readonly Rules rules;

        public BJGame(Table _table, CardDeck _deck, Rules _rules)
        {
            table = _table;
            deck = _deck;
            rules = _rules;
        }

        public List<Player> GetWinners()
        {
            return rules.GetWinners(table, deck);
        }

        public Table GetTable()
        {
            return table;
        }

        public CardDeck GetDeck()
        {
            return deck;
        }

        public void TakeNewDeck(CardDeck _deck)
        {
            deck = _deck;
        }
    }
}

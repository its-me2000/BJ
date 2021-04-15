using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BJ
{
    public class NavCardDeck : CardDeck
    {
        private readonly Queue<Card> deck = new Queue<Card>();
        private const int CARDS_IN_DECK = 52;
        private const string navDeckUrl = "http://nav-deckofcards.herokuapp.com/shuffle";
        static private readonly HttpClient client = new HttpClient();
        private static readonly Dictionary<string, CardValue> StringToCardValue = new Dictionary<string, CardValue>()
        {
            { "2", CardValue.TWO }, { "3", CardValue.THREE }, { "4", CardValue.FOUR  }, { "5", CardValue.FIVE },
            { "6", CardValue.SIX }, { "7", CardValue.SEVEN }, { "8", CardValue.EIGHT }, { "9", CardValue.NINE },
            { "10", CardValue.TEN}, { "J", CardValue.JACK  }, { "Q", CardValue.QUEEN }, { "K", CardValue.KING },
            { "A", CardValue.ACE }
        };
        private static readonly Dictionary<string, CardSuit> StringToCardSuit = new Dictionary<string, CardSuit>()
        {
            { "CLUBS",    CardSuit.CLUBS    },
            { "DIAMONDS", CardSuit.DIAMONDS },
            { "HEARTS",   CardSuit.HEARTS   },
            { "SPADES",   CardSuit.SPADES   }
        };

        private class JsonObject
        {
            public string suit { get; set; }
            public string value { get; set; }
            public JsonObject() { }
            public override string ToString()
            {
                return suit + value;
            }
        }

        
        public NavCardDeck()
        {
            GetNewDeck();

        }

        private string GetJsonString(string url)
        {
            try
            {
                return client.GetStringAsync(url).Result;
            }
            catch (Exception e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                Console.ReadKey(true);
                throw e;
            }
        }
        private List<JsonObject> DeserializeJsonObjectList(string jsonString)
        {
            try
            {
                return JsonSerializer.Deserialize<List<JsonObject>>(jsonString);
            }
            catch (Exception e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                Console.ReadKey(true);
                throw e;
            }
        }
        private void JsonObjectListToQueue(List<JsonObject> jsonList)
        {
            try
            {
                Queue<Card> queue = new Queue<Card>();
                jsonList.ForEach((obj)=>
                    deck.Enqueue(new Card(StringToCardSuit[obj.suit], StringToCardValue[obj.value]))
                );
            }
            catch (Exception e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);

                throw e;
            }
        }

        private void GetNewDeck()
        {
            try
            {
                JsonObjectListToQueue(DeserializeJsonObjectList(GetJsonString(navDeckUrl)));
                if (deck.Count != CARDS_IN_DECK)
                {
                    throw new Exception("Bad Deck.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                Console.ReadKey(true);
                throw e;
            }
        }

        public Card GetCard()
        {
            if (deck.Count == 0)
            {
                GetNewDeck();
            }
            return deck.Dequeue();

        }

        public override string ToString()
        {
            string returnString = "";

            foreach (Card card in deck)
            {
                returnString += (" " + card.ToString());
            }

            return returnString;
        }

    }
}

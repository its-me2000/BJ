using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BJ
{
    public class NavCardDeck : CardDeck
    {
        private readonly Queue<Card> deck;
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
            try
            {
                deck = JsonObjectListToQueue(DeserializeJsonObjectList(GetJsonString(navDeckUrl)));
                if(deck.Count != CARDS_IN_DECK)
                {
                    throw new Exception("Bad Deck.");
                }
            }
            catch( Exception e )
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("NavCardDeck. Message :{0} ", e.Message);
                Console.ReadKey(true);
                throw e;
            }

        }

        private static string GetJsonString(string url)
        {
            try
            {
                return client.GetStringAsync(url).Result;
            }
            catch (Exception e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("GetJsonString. Message :{0} ", e.Message);
                Console.ReadKey(true);
                throw e;
            }
        }
        private static List<JsonObject> DeserializeJsonObjectList(string jsonString)
        {
            try
            {
                return JsonSerializer.Deserialize<List<JsonObject>>(jsonString);
            }
            catch (Exception e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("DeserializeJsonObject. Message :{0} ", e.Message);
                Console.ReadKey(true);
                throw e;
            }
        }
        private static Queue<Card> JsonObjectListToQueue(List<JsonObject> jsonList)
        {
            try
            {
                Queue<Card> queue = new Queue<Card>();
                jsonList.ForEach((obj)=>
                    queue.Enqueue(new Card(StringToCardSuit[obj.suit], StringToCardValue[obj.value]))
                );
                return queue;
            }
            catch (Exception e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("JsonObjectListToQueue. Message :{0} ", e.Message);
                Console.ReadKey(true);
                throw e;
            }
        }

        public Card GetCard()
        {
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

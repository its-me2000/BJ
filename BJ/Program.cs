using System;

namespace BJ
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine(new Card(CardSuit.HEARTS, CardValue.ACE).ToString());
            Console.ReadKey(true);
        }
    }

}

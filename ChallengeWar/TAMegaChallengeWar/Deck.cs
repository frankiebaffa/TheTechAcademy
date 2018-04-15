using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TAMegaChallengeWar
{
    public class Deck
    {
        public List<Card> Cards { get; set; }

        //  constructor
        public Deck()
        {
            this.Cards = new List<Card>() { };
        }

        //  create an array of possible numbers
        List<int> numbers = new List<int> { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };

        //  Create the entire deck of cards using numbers list
        public void genDeck()
        {
            //  for ever number in numbers list, add a card with each suit
            foreach (int number in numbers)
            {
                Cards.Add(new Card(number, "Spades"));
                Cards.Add(new Card(number, "Hearts"));
                Cards.Add(new Card(number, "Clubs"));
                Cards.Add(new Card(number, "Diamonds"));
            }
        }

    }
}
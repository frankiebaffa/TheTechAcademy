using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TAMegaChallengeWar
{
    public class Card
    {
        public int Number { get; set; }
        public string Suit { get; set; }

        public Card()
        {
            this.Number = 0;
            this.Suit = "undefined";
        }

        public Card(int number, string suit)
        {
            this.Number = number;
            this.Suit = suit;
        }
    }
}
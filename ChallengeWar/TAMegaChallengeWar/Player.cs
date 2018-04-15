using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TAMegaChallengeWar
{
    public class Player
    {
        public string Name { get; set; }
        public List<Card> Hand { get; set; }
        public War War { get; set; }

        //  constructor
        public Player()
        {
            this.Name = "";
            this.Hand = new List<Card> { };
            this.War = new War(this);
        }
    }
}
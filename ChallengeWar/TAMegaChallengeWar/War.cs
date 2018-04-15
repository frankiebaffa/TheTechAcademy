using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TAMegaChallengeWar
{
    public class War
    {
        public int WarCard { get; set; }
        public List<Card> WarStack { get; set; }
        public Player Player { get; set; }

        public War(Player player)
        {
            this.WarCard = 0;
            this.WarStack = new List<Card>();
            this.Player = player;
        }

        public void genStack()
        {
            WarStack.AddRange(Player.Hand.GetRange(0, 3));
            WarCard = WarStack.First().Number;
            Player.Hand.RemoveRange(0, 3);
        }

        public void nukeStack()
        {
            WarStack = new List<Card>();
        }
        
    }
}
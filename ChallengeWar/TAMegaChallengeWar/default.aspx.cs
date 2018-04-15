using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TAMegaChallengeWar
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //  create first player
            Player player1 = new Player();
            player1.Name = "Player 1";

            //  create second player
            Player player2 = new Player();
            player2.Name = "Player 2";

            //  create deck
            Deck deck = new Deck();

            //  create random variable
            Random random = new Random();

            //  create game
            Game game = new Game(player1, player2, deck, random);

            //  create string results
            string dealResult = "";
            string result = "";

            //  deal cards and print to resultLabel
            result += game.init(player1, player2, random, deck, dealResult);

            //  set down player 1 top card and player 2 top card
            for (int i = 0; i < 100; i++)
            {
                string roundResult = "";
                roundResult += game.playRound(player1, player2);
                result += "<br/><br/>" + roundResult;
            }

            resultLabel.Text = result;

        }



        /*============================================
         *      TESTING METHODS,
         *          NOT NEEDED IN ACTUAL PROGRAM
         *==========================================*/
        private void handPrint(Player player1, Player player2)
        {
            foreach (Card card in player1.Hand)
            {
                resultLabel.Text += String.Format(
                    "Player 1 was dealt the {0} of {1}<br/>",
                    card.Number.ToString(), card.Suit);
            }
        }

        private void cardPrint(Deck deck)
        {
            foreach (Card card in deck.Cards)
            {
                if (card.Number == 11)
                {
                    resultLabel.Text += String.Format(
                        "<br/>Jack of {0}",
                        card.Suit);
                }
                else if (card.Number == 12)
                {
                    resultLabel.Text += String.Format(
                        "<br/>Queen of {0}",
                        card.Suit);
                }
                else if (card.Number == 13)
                {
                    resultLabel.Text += String.Format(
                        "<br/>King of {0}",
                        card.Suit);
                }
                else if (card.Number == 14)
                {
                    resultLabel.Text += String.Format(
                        "<br/>Ace of {0}",
                        card.Suit);
                }
                else
                {
                    resultLabel.Text += String.Format(
                        "<br/>{0} of {1}",
                        card.Number.ToString(), card.Suit);
                }
            }
        }
    }
}
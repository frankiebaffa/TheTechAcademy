using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TAMegaChallengeWar
{
    public class Game
    {
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public Deck deck { get; set; }
        private Random _random;

        //  constructor
        public Game(Player player1, Player player2, Deck deck, Random random)
        {
            this.Player1 = player1;
            this.Player2 = player2;
            this.deck = deck;
            this._random = random;
        }

        //  create deck then deal cards
        public string init(Player player1, Player player2, Random random, Deck deck, String dealResult)
        {
            deck.genDeck();

            dealResult = deal(player1, player2, random, deck, dealResult);

            return dealResult;
        }

        //  deal cards
        public string deal(Player player1, Player player2, Random random, Deck deck, String dealResult)
        {
            foreach (Card card in deck.Cards.ToList())
            {
                if (deck.Cards.Count > 0)
                {
                    //  deal to player 1
                    int _random = random.Next(0, deck.Cards.Count - 1); //  get random number between 0 and the remaining indices of deck
                    Card deal = deck.Cards.ToList().ElementAt(_random); //  get card from deck at element of random number
                    dealResult += dealPlayer(deal, deck, player1);

                    //  deal to player 2
                    _random = random.Next(0, deck.Cards.Count - 1); //  get random number between 0 and the remaining indices of deck
                    deal = deck.Cards.ElementAt(_random);   //  get card from deck at element of random number
                    dealResult += dealPlayer(deal, deck, player2);
                }
                else break;
            }
            return dealResult;
        }

        //  deal card to player and return string based on the card and which player to whom it was dealt
        public string dealPlayer(Card deal, Deck deck, Player player)
        {
            player.Hand.Add(deal);
            deck.Cards.Remove(deal);
            string dealResult = dealPrint(player, deal);
            return dealResult;
        }

        //  print to which player the card was dealt as well as which card
        public string dealPrint(Player player, Card deal)
        {
            string result = String.Format(
                "<br/>{0} was dealt the {1}",
                player.Name, ifPrint(deal));
            return result;
        }

        //  each player sets down a card
        public string playRound(Player player1, Player player2)
        {
            string result = "";
            Card player1Card = new Card();
            Card player2Card = new Card();
            player1Card = playCard(player1, player1Card);
            player2Card = playCard(player2, player2Card);
            result = printCards(player1, player1Card, player2, player2Card);
            result += checkRound(player1, player2, player1Card, player2Card);
            return result;
        }

        //  place card
        public Card playCard(Player player, Card playerCard)
        {
            playerCard = player.Hand.First();
            player.Hand.RemoveAt(0);
            return playerCard;
        }

        //  check number of each player's card and pick higher card; if equal, war
        public string checkRound(Player player1, Player player2, Card player1Card, Card player2Card)
        {
            string result = "";
            if (player1Card.Number > player2Card.Number)
            {
                result = winRound(player1, player1Card, player2Card);
                return result;
            }
            else if (player2Card.Number > player1Card.Number)
            {
                result = winRound(player2, player1Card, player2Card);
                return result;
            }
            else
            {
                result = initWar(player1, player2, player1Card, player2Card);
                return result;
            }
        }

        // put cards at bottom of winner's deck
        public string winRound(Player player, Card player1Card, Card player2Card)
        {
            string result = "";
            player.Hand.Add(player1Card);
            player.Hand.Add(player2Card);
            result = printWin(player);
            return result;
        }

        public string printCards(Player player1, Card player1Card, Player player2, Card player2Card)
        {
            string result = "";
            result = String.Format(
                "{0} played the {1}<br/>" +
                "{2} played the {3}<br/>",
                player1.Name, ifPrint(player1Card),
                player2.Name, ifPrint(player2Card));
            return result;
        }

        //  print label for round
        public string printWin(Player player)
        {
            string result = "";
            result = String.Format("{0} won the round!<br/>", player.Name);
            return result;
        }

        public string initWar(Player player1, Player player2, Card player1Card, Card player2Card)
        {
            string result = "";
            player1.War.genStack();
            player2.War.genStack();
            result = playWar(player1, player2, player1Card, player2Card);
            player1.War.nukeStack();
            player2.War.nukeStack();
            return result;
        }

        public string playWar(Player player1, Player player2, Card player1Card, Card player2Card)
        {
            string result = "";
            int warRounds = 1;
            List<Card> winStack = new List<Card>();
            winStack = genWinStack(player1, player2, winStack, player1Card, player2Card);

            if (player1.War.WarCard > player2.War.WarCard)
            {
                player1.Hand.AddRange(winStack);
                result = winWar(player1, warRounds, winStack);
                return result;
            }
            else if (player2.War.WarCard > player1.War.WarCard)
            {
                player2.Hand.AddRange(winStack);
                result = winWar(player2, warRounds, winStack);
                return result;
            }
            else
            {
                warRounds++;
                playWar(player1, player2, player1Card, player2Card);
                return result;
            }
        }

        public string winWar(Player player, int warRounds, List<Card> winStack)
        {
            string result = "";

            result = String.Format(
                "<br/>========================="+
                "<br/>===={0} ROUNDS OF WAR===="+
                "<br/>========================="+
                "<br/><br/>{1} won the war and took:"+
                "<br/>{2}",
                warRounds, player.Name, warPrint(winStack));

            return result;
        }

        public string warPrint(List<Card> winStack)
        {
            string result = "";

            foreach (Card card in winStack)
            {
                result += ifPrint(card) + "<br/>";
            }
            return result;
        }

        public List<Card> genWinStack(Player player1, Player player2, List<Card> winStack, Card player1Card, Card player2Card)
        {
            winStack = player1.War.WarStack;
            winStack.AddRange(player2.War.WarStack);
            winStack.Add(player1Card);
            winStack.Add(player2Card);
            return winStack;
        }

        public string ifPrint(Card card)
        {
            string result = "";

            if (card.Number <= 10)
            {
                result += String.Format(
                    "{0} of {1}",
                    card.Number, card.Suit);
            }
            else if (card.Number == 11)
            {
                result += String.Format(
                    "Jack of {0}",
                    card.Suit);
            }
            else if (card.Number == 12)
            {
                result += String.Format(
                    "Queen of {0}",
                    card.Suit);
            }
            else if (card.Number == 13)
            {
                result += String.Format(
                    "King of {0}",
                    card.Suit);
            }
            else if (card.Number == 14)
            {
                result += String.Format(
                    "Ace of {0}",
                    card.Suit);
            }
            else
            {
                result += String.Format(
                    "<br/>{0} of {1}",
                    card.Number.ToString(), card.Suit);
            }

            return result;
        }
    }
}
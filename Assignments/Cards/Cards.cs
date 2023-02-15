// Cards
using System;
using System.Linq;
using System.Security.Cryptography;

// Alias
using con = System.Console;

namespace DeckOfCards
{
    class DeckOfCards
    {
        static void Main(string[] args)
        {
            con
                .WriteLine(@"  ____              _     
 / ___|__ _ _ __ __| |___ 
| |   / _` | '__/ _` / __|
| |__| (_| | | | (_| \__ \
 \____\__,_|_|  \__,_|___/
 
");

            CardDeck myDeck = new CardDeck();

            /* DEMO CODE
             *
             * Just for fun
             */
            int handSize = 5;
            Card[] player1 = new Card[handSize];
            Card[] player2 = new Card[handSize];

            con.WriteLine("The cards will now be delt.\n");
            for (int i = 0; i < player1.Length; i++)
            {
                player1[i] = myDeck.dealCard();
            }
            for (int i = 0; i < player2.Length; i++)
            {
                player2[i] = myDeck.dealCard();
            }

            con.WriteLine("Player 1's hand:");
            for (int i = 0; i < player1.Length; i++)
            {
                con.WriteLine(player1[i]);
            }
            con.WriteLine("\nPlayer 2's hand:");
            for (int i = 0; i < player2.Length; i++)
            {
                con.WriteLine(player2[i]);
            }

            con.WriteLine("Who had a better hand?");
        }
    }

    class CardDeck
    {
        /*
         A complete deck of cards.
         */
        private static int cardLen = 52;

        private Card[] deck = new Card[cardLen];

        public CardDeck(bool shuffled = true)
        {
            string[] faces =
            {
                "Joker",
                "Ace",
                "Two",
                "Three",
                "Four",
                "Five",
                "Six",
                "Seven",
                "Eight",
                "Nine",
                "Ten",
                "Jack",
                "Queen",
                "King"
            };
            string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };

            // Iter all cards
            for (var suit = 0; suit < suits.Length; suit++)
            {
                for (var face = 1; face < faces.Length; face++)
                {
                    deck[(suit * (cardLen / 4)) + face - 1] =
                        new Card(suits[suit], faces[face]);
                }
            }

            // Shuffle the deck
            if (shuffled)
            {
                this.shuffle();
            }
        }

        private void shuffle()
        {
            Random random = new Random();
            deck = deck.OrderBy(x => random.Next()).ToArray();
        }

        public Card dealCard()
        {
            var topCard = deck[0]; // Draw the topcard
            Array.Copy(deck, 1, deck, 0, deck.Length - 1); // Shift everything down
            deck[deck.Length - 1] = topCard; // Replace the top card on the end

            return topCard;
        }

        public override string ToString()
        {
            string _r = "";
            for (var idx = 0; idx < cardLen; idx++)
            {
                _r += $"{deck[idx].ToString()}\n";
            }
            return _r;
        }
    }

    class Card
    {
        private string Face { get; }

        private string Suit { get; }

        public override string ToString()
        {
            return $"{Suit} of {Face}";
        }

        // Constructor
        public Card(string _Face, string _Suit)
        {
            Face = _Face;
            Suit = _Suit;
        }
    }
}

using System;
using System.Collections.Generic;

namespace EorzeaGamingCommission
{
    public class Deck
    {
        private List<Card> deck;
        private Random random;

        public Deck()
        {
            deck = new List<Card>();
            string[] suits = { "Hearts", "Diamonds", "Spades", "Clubs" };
            string[] ranks = {"2","3","4","5","6","7","8","9","10","Jack","Queen","King","Ace"};
            foreach (string suit in suits)
            {
                foreach (string rank in ranks)
                {
                    deck.Add(new Card(suit, rank));
                }
            }
            random = new Random();
        }

        public void Shuffle()
        {
            int n = deck.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                Card card = deck[k];
                deck[k] = deck[n];
                deck[n] = card;
            }
        }

        public Card Deal()
        {
            Card card = deck[deck.Count - 1];
            deck.RemoveAt(deck.Count - 1);
            return card;
        }
    }
}

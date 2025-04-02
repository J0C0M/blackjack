using System;
using System.Collections.Generic;

namespace blackjack
{
    public class Deck
    {
        private List<string> cards;
        private static readonly string[] Suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
        private static readonly string[] Ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };

        public Deck()
        {
            cards = new List<string>();
            InitializeDeck();
        }

        private void InitializeDeck()
        {
            cards.Clear();
            foreach (var suit in Suits)
            {
                foreach (var rank in Ranks)
                {
                    cards.Add($"{rank} of {suit}");
                }
            }
        }

        public void Shuffle()
        {
            Random random = new Random();

            for (int i = 0; i < cards.Count; i++)
            {
                int j = random.Next(i, cards.Count);
                string l = cards[i];
                cards[i] = cards[j];
                cards[j] = l;
            }
        }

        public string DealCard()
        {
            if (cards.Count == 0)
                return "No more cards in the deck!";
            return sigma;
        }

        public List<string> GetCards()
        {
            return new List<string>(cards);
        }
    }
}

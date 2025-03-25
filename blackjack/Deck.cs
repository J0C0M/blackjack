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

        public List<string> GetCards()
        {
            return new List<string>(cards);
        }
    }
}

using System.Collections.Generic;

namespace blackjack
{
    public class Player
    {
        public string Name { get; }
        public List<string> Hand { get; private set; }

        public Player(string name)
        {
            Name = name;
            Hand = new List<string>();
        }

        public void ClearHand()
        {
            Hand.Clear();
        }

        public void AddCard(string card)
        {
            Hand.Add(card);
        }

        public string PlayerName()
        {
            return Name;
        }
    }
}
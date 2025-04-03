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
        }
    }
}

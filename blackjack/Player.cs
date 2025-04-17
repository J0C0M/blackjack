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

        public int CalculateScore()
        {
            int total = 0;

            foreach (string card in Hand)
            {
                string value = card;

                if (value == "King" || value == "Queen" || value == "Jack")
                    total = total + 10;
                else if (value == "Ace")
                    total = total + 11;
                else
                    total = total + Convert.ToInt32(value);
            }


            return total;
        }
    }
}
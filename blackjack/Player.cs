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
            int aceCount = 0;

            foreach (string card in Hand)
            {
                int cardValue = 0;

                if (card.Contains("King") || card.Contains("Queen") || card.Contains("Jack"))
                {
                    cardValue = 10;
                }
                else if (card.Contains("Ace"))
                {
                    cardValue = 11;
                    aceCount++;
                }
                else
                {
                    for (int i = 2; i <= 10; i++)
                    {
                        if (card.Contains(i.ToString()))
                        {
                            cardValue = i;
                            break;
                        }
                    }
                }

                total += cardValue;
            }

            while (total > 21 && aceCount > 0)
            {
                total -= 10;
                aceCount--;
            }

            return total;
        }

    }
}
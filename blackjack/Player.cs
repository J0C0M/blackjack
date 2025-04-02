using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack
{
    class Player
    {
        public string Name {get;}
        public List<string> Hand {get; private set;}

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

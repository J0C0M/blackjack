namespace blackjack
{
    public partial class Form1 : Form
    {
        private Deck deck;
        private List<Player> players;

        public Form1()
        {
            InitializeComponent();
            deck = new Deck();
            InitializePlayers();
            DisplayPlayers();
        }

        private void InitializePlayers()
        {
            players = new List<Player>
            {
                new Player("Player 1"),
                new Player("Player 2"),
                new Player("Dealer")
            };
        }

        private void btnShuffleClick(object sender, EventArgs e)
        {
            deck.Shuffle();
            deckList.Items.Clear();
            foreach (var card in deck.GetCards())
            {
                deckList.Items.Add(card);
            }

            foreach (var player in players)
            {
                player.ClearHand();
            }

            DisplayPlayers();
            btnShuffle.Enabled = false;
        }

        private void btnDealClick(object sender, EventArgs e)
        {
            foreach (var player in players)
            {
                string card = deck.DealCard();

                if (card == "No more cards in deck")
                {
                    MessageBox.Show("No more cards deck");
                    return;
                }

                player.AddCard(card);

                int score = player.CalculateScore();
                if (score >= 21)
                {
                    MessageBox.Show($"{player.PlayerName()} has {score} points!");
                    DisplayPlayers();
                    return;
                }
            }

            deckList.Items.Clear();
            foreach (var card in deck.GetCards())
            {
                deckList.Items.Add(card);
            }

            DisplayPlayers();
        }

        private void DisplayPlayers()
        {
            playersList.Items.Clear();
            foreach (var player in players)
            {
                string playerInfo = player.PlayerName();

                if (player.Hand.Count > 0)
                {
                    playerInfo += ": ";
                    foreach (var card in player.Hand)
                    {
                        playerInfo += card + ", ";
                    }
                    if (player.Hand.Count > 0)
                    {
                        playerInfo = playerInfo.Substring(0, playerInfo.Length - 2);
                    }
                }

                playersList.Items.Add(playerInfo);
            }
        }
    }
}
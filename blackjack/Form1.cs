namespace blackjack
{
    public partial class Form1 : Form
    {
        private Deck deck;
        private List<Player> players;
        private bool gameEnded = false;

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
            deck = new Deck();  // Create a new deck to ensure we have all cards
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
            btnDeal.Enabled = true;
            gameEnded = false;
        }

        private void btnDealClick(object sender, EventArgs e)
        {
            if (gameEnded)
            {
                MessageBox.Show("Game has ended. Please shuffle to start a new game.");
                return;
            }

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
                if (score == 21)
                {
                    someoneHas21 = true;
                    EndGame(player);
                    return;
                }
                else if (score > 21)
                {
                    MessageBox.Show($"{player.PlayerName()} busted with {score} points!");
                    EndGame(null);  // Nobody wins when a player busts
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

        private void EndGame(Player winner)
        {
            gameEnded = true;
            btnDeal.Enabled = false;
            btnShuffle.Enabled = true;
            
            if (winner != null)
            {
                MessageBox.Show($"Game over! {winner.PlayerName()} wins!");
            }
            else
            {
                MessageBox.Show("Game over! Nobody wins this round.");
            }
        }

        private void DisplayPlayers()
        {
            playersList.Items.Clear();
            foreach (var player in players)
            {
                string playerInfo = player.PlayerName();
                
                if (player.Hand.Count > 0)
                {
                    int score = player.CalculateScore();
                    playerInfo += $" (Score: {score}): ";
                    
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
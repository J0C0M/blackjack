namespace blackjack
{
    public partial class Form1 : Form
    {
        private Deck deck;
        private List<Player> players;
        private bool gameEnded = false;
        private int currentPlayerIndex = 0;

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
                new Player("You"),
                new Player("Player 1"),
                new Player("Player 2"),
                new Player("Dealer")
            };
        }

        private void btnShuffleClick(object sender, EventArgs e)
        {
            deck = new Deck();
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

            for (int i = 0; i < 2; i++)
            {
                foreach (var player in players)
                {
                    string card = deck.DealCard();
                    if (card == "No more cards in the deck!")
                    {
                        MessageBox.Show("Not enough cards in the deck!");
                        return;
                    }
                    player.AddCard(card);
                }
            }

            deckList.Items.Clear();
            foreach (var card in deck.GetCards())
            {
                deckList.Items.Add(card);
            }

            DisplayPlayers();
            CheckForBlackjack();

            if (!gameEnded)
            {
                btnDeal.Enabled = true;
                // Start with the first player
                currentPlayerIndex = 0;
                UpdatePlayerTurnMessage();
            }
        }

        private void CheckForBlackjack()
        {
            foreach (var player in players)
            {
                if (player.Hand.Count == 2 && player.CalculateScore() == 21)
                {
                    MessageBox.Show($"{player.PlayerName()} has blackjack (21 points)! Game over!");
                    EndGame(player);
                    return;
                }
            }
        }

        private void UpdatePlayerTurnMessage()
        {
            if (currentPlayerIndex < players.Count)
            {
                this.Text = $"Blackjack - {players[currentPlayerIndex].PlayerName()}'s Turn";
            }
        }

        private void btnDealClick(object sender, EventArgs e)
        {
            if (gameEnded)
            {
                MessageBox.Show("Game has ended. Please shuffle to start a new game.");
                return;
            }

            if (currentPlayerIndex >= players.Count)
            {
                DetermineWinner();
                return;
            }

            Player currentPlayer = players[currentPlayerIndex];
            
            string card = deck.DealCard();
            if (card == "No more cards in deck")
            {
                MessageBox.Show("No more cards in deck");
                return;
            }

            currentPlayer.AddCard(card);
            int score = currentPlayer.CalculateScore();

            deckList.Items.Clear();
            foreach (var remainingCard in deck.GetCards())
            {
                deckList.Items.Add(remainingCard);
            }
            DisplayPlayers();

            if (score > 21)
            {
                MessageBox.Show($"{currentPlayer.PlayerName()} busts with {score}!");
                MoveToNextPlayer();
            }
            else if (score == 21)
            {
                MessageBox.Show($"{currentPlayer.PlayerName()} has 21!");
                MoveToNextPlayer();
            }
            
            if (currentPlayerIndex == players.Count - 1 && score < 17)
            {
                btnDealClick(sender, e);
            }
        }

        private void MoveToNextPlayer()
        {
            currentPlayerIndex++;
            
            if (currentPlayerIndex >= players.Count)
            {
                DetermineWinner();
                return;
            }
            
            UpdatePlayerTurnMessage();
            
            if (currentPlayerIndex == players.Count - 1)
            {
                PlayDealerTurn();
            }
        }

        private void PlayDealerTurn()
        {
            Player dealer = players[players.Count - 1];
            
            while (dealer.CalculateScore() < 17)
            {
                string card = deck.DealCard();
                if (card == "No more cards in the deck!")
                {
                    MessageBox.Show("No more cards in deck");
                    break;
                }
                
                dealer.AddCard(card);
                deckList.Items.Clear();
                foreach (var remainingCard in deck.GetCards())
                {
                    deckList.Items.Add(remainingCard);
                }
                DisplayPlayers();
                
                if (dealer.CalculateScore() > 21)
                {
                    MessageBox.Show($"{dealer.PlayerName()} busts with {dealer.CalculateScore()}!");
                    break;
                }
            }
            DetermineWinner();
        }

        private void DetermineWinner()
        {
            int dealerScore = players[players.Count - 1].CalculateScore();
            bool dealerBusted = dealerScore > 21;
            
            List<Player> winners = new List<Player>();
            int highestScore = 0;
            
            foreach (var player in players)
            {
                int playerScore = player.CalculateScore();
                
                if (playerScore > 21)
                    continue;
                    
                if (dealerBusted)
                {
                    if (playerScore > highestScore)
                    {
                        winners.Clear();
                        winners.Add(player);
                        highestScore = playerScore;
                    }
                    else if (playerScore == highestScore)
                    {
                        winners.Add(player);
                    }
                }
                else if (playerScore > dealerScore)
                {
                    if (playerScore > highestScore)
                    {
                        winners.Clear();
                        winners.Add(player);
                        highestScore = playerScore;
                    }
                    else if (playerScore == highestScore)
                    {
                        winners.Add(player);
                    }
                }
            }
            
            if (winners.Count == 0 && !dealerBusted)
            {
                winners.Add(players[players.Count - 1]);
            }
            
            if (winners.Count > 0)
            {
                string winnerNames = string.Join(", ", winners.Select(w => w.PlayerName()));
                EndGame(winners[0], $"Game over! Winner(s): {winnerNames}");
            }
            else
            {
                EndGame(null, "Game over! Everyone busted!");
            }
        }

        private void EndGame(Player winner, string message = null)
        {
            gameEnded = true;
            btnDeal.Enabled = false;
            btnShuffle.Enabled = true;
            this.Text = "Blackjack";

            if (message != null)
            {
                MessageBox.Show(message);
            }
            else if (winner != null)
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

                // Highlight current player
                if (players.IndexOf(player) == currentPlayerIndex && !gameEnded)
                {
                    playerInfo = "➤ " + playerInfo;
                }

                playersList.Items.Add(playerInfo);
            }
        }
    }
}
namespace blackjack
{
    public partial class Form1 : Form
    {
        // Game components
        private Deck deck;
        private List<Player> players;
        private bool gameEnded = false;
        private int currentPlayerIndex = 0;

        /// Constructor for the Form1 class. Initializes the form components,
        /// creates a new deck, and sets up the initial players.
        public Form1()
        {
            InitializeComponent();
            deck = new Deck();
            InitializePlayers();
            DisplayPlayers();
            btnPass.Enabled = false;
        }

        /// Creates the player objects for the game: the human player, 
        /// two AI players, and the dealer.
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

        /// Handles the click event for the Shuffle button.
        /// Creates a new deck, shuffles it, deals initial cards to players,
        /// updates the ui, and checks for any immediate blackjacks.
        private void btnShuffleClick(object sender, EventArgs e)
        {
            // Shuffle a new deck
            deck = new Deck();
            deck.Shuffle();
            deckList.Items.Clear();
            foreach (var card in deck.GetCards())
            {
                deckList.Items.Add(card);
            }

            // Clear all players hands from previous game
            foreach (var player in players)
            {
                player.ClearHand();
            }

            // Give two initial cards to each player
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

            // Update the UI with the current state of the deck
            deckList.Items.Clear();
            foreach (var card in deck.GetCards())
            {
                deckList.Items.Add(card);
            }

            // Update the player information display
            DisplayPlayers();

            // Check if anyone got a won with their initial two cards
            CheckForBlackjack();

            // If no one has won, enable play and set to first player's turn
            if (!gameEnded)
            {
                btnDeal.Enabled = true;
                // Start with the first player
                currentPlayerIndex = 0;
                UpdatePlayerTurnMessage();

                // Enable or disable pass button based on which player turn it is
                UpdatePassButtonState();
            }
        }

        /// Updates the state of the Pass button based on whose turn it is.
        /// Enabled when its the players turn
        private void UpdatePassButtonState()
        {
            // Only enable Pass button when it's the human players turn
            btnPass.Enabled = currentPlayerIndex == 0 && !gameEnded;
        }

        /// Checks if any player has 21 points with their initial two cards.
        /// If a player has blackjack, the game ends immediately with that player as winner.
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

        /// Updates the form title to show whose turn it is currently.
        private void UpdatePlayerTurnMessage()
        {
            if (currentPlayerIndex < players.Count)
            {
                this.Text = $"Blackjack - {players[currentPlayerIndex].PlayerName()}'s Turn";
            }
        }

        /// Handles the click event for the Deal button.
        /// Deals a card to the current player, updates the UI, and checks
        /// for win/bust conditions before moving to the next player if needed.
        private void btnDealClick(object sender, EventArgs e)
        {
            // prevent play if the game has already ended
            if (gameEnded)
            {
                MessageBox.Show("Game has ended. Please shuffle to start a new game.");
                return;
            }

            // Check if all players have finished their turn
            if (currentPlayerIndex >= players.Count)
            {
                DetermineWinner();
                return;
            }

            Player currentPlayer = players[currentPlayerIndex];

            // Deal a card to the current player
            string card = deck.DealCard();
            if (card == "No more cards in deck")
            {
                MessageBox.Show("No more cards in deck");
                return;
            }

            currentPlayer.AddCard(card);
            int score = currentPlayer.CalculateScore();

            // Update the ui with the current state
            deckList.Items.Clear();
            foreach (var remainingCard in deck.GetCards())
            {
                deckList.Items.Add(remainingCard);
            }
            DisplayPlayers();

            // Check if the player goes over 21
            if (score > 21)
            {
                MessageBox.Show($"{currentPlayer.PlayerName()} busts with {score}!");
                MoveToNextPlayer();
            }
            // Check if the player gets 21
            else if (score == 21)
            {
                MessageBox.Show($"{currentPlayer.PlayerName()} has 21!");
                MoveToNextPlayer();
            }

            // Dealer must continue drawing cards until reaching at least 17
            if (currentPlayerIndex == players.Count - 1 && score < 17)
            {
                btnDealClick(sender, e);
            }
        }

        /// handles the click event for the pass button
        /// allows the human player to end their turn without drawing another card
        private void btnPassClick(object sender, EventArgs e)
        {
            // Only allow passing if it's the human player's turn and the game hasn't ended
            if (currentPlayerIndex == 0 && !gameEnded)
            {
                Player currentPlayer = players[currentPlayerIndex];
                int score = currentPlayer.CalculateScore();

                // Check if player has at least 17 points before allowing them to pass
                if (score < 17)
                {
                    MessageBox.Show("You must have at least 17 points to pass. Draw another card.");
                    return;
                }

                MessageBox.Show($"You pass with {score} points.");
                MoveToNextPlayer();
            }
        }

        /// Advances to the next player's turn after the current player is done.
        /// If all players are done, it will determine the winner.
        /// If the next player is the dealer, it will play the dealer's turn automatically.
        private void MoveToNextPlayer()
        {
            currentPlayerIndex++;

            // If all players have had their turn, decide the winner
            if (currentPlayerIndex >= players.Count)
            {
                DetermineWinner();
                return;
            }

            UpdatePlayerTurnMessage();

            // Update the Pass button state (only enabled for human player)
            UpdatePassButtonState();

            // If the next player is the dealer, play the dealer's turn automatically
            if (currentPlayerIndex == players.Count - 1)
            {
                PlayDealerTurn();
            }
            // For ai players, automatically play their turn
            else if (currentPlayerIndex > 0 && currentPlayerIndex < players.Count - 1)
            {
                PlayAITurn();
            }
        }

        /// Handles the AI player's turn automatically.
        /// ai will draw cards until reaching at least 17 points.
        private void PlayAITurn()
        {
            Player aiPlayer = players[currentPlayerIndex];

            // AI logic. Keeps drawing until reach at least 17 points
            while (aiPlayer.CalculateScore() < 17)
            {
                string card = deck.DealCard();
                if (card == "No more cards in the deck!")
                {
                    MessageBox.Show("No more cards in deck");
                    break;
                }

                aiPlayer.AddCard(card);
                deckList.Items.Clear();
                foreach (var remainingCard in deck.GetCards())
                {
                    deckList.Items.Add(remainingCard);
                }
                DisplayPlayers();

                // Check if AI busts
                if (aiPlayer.CalculateScore() > 21)
                {
                    MessageBox.Show($"{aiPlayer.PlayerName()} busts with {aiPlayer.CalculateScore()}!");
                    break;
                }

                // Add a small delay to make the AI moves more visible
                Application.DoEvents();
                System.Threading.Thread.Sleep(500);
            }

            int finalScore = aiPlayer.CalculateScore();
            if (finalScore <= 21)
            {
                MessageBox.Show($"{aiPlayer.PlayerName()} stands with {finalScore}.");
            }

            MoveToNextPlayer();
        }

        /// Handles the dealer's turn automatically according to blackjack rules.
        /// The dealer must draw cards until reaching a score of at least 17.
        private void PlayDealerTurn()
        {
            Player dealer = players[players.Count - 1];

            // Dealer must continue drawing cards until reaching at least 17
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

                // Add a small delay to make the dealer moves more visible
                Application.DoEvents();
                System.Threading.Thread.Sleep(500);

                // Check if dealer busts
                if (dealer.CalculateScore() > 21)
                {
                    MessageBox.Show($"{dealer.PlayerName()} busts with {dealer.CalculateScore()}!");
                    break;
                }
            }

            int finalScore = dealer.CalculateScore();
            if (finalScore <= 21)
            {
                MessageBox.Show($"{dealer.PlayerName()} stands with {finalScore}.");
            }

            DetermineWinner();
        }

        /// Compares all players' scores to determine the winner(s) of the game.
        /// The player with the highest score under 21 wins, minimum score of 17 required.
        private void DetermineWinner()
        {
            // Make a list to store our possible winners
            List<Player> possibleWinners = new List<Player>();

            // Check each player to see if they qualify
            foreach (Player player in players)
            {
                int score = player.CalculateScore();

                // Player qualifies if score is between 17 and 21
                if (score >= 17 && score <= 21)
                {
                    possibleWinners.Add(player);
                }
            }

            // If no one qualifies, game ends with no winner
            if (possibleWinners.Count == 0)
            {
                EndGame(null, "Game over! No winners - everyone either busted or scored below 17.");
                return;
            }

            // Find the highest score
            int highestScore = 0;
            foreach (Player player in possibleWinners)
            {
                int score = player.CalculateScore();
                if (score > highestScore)
                {
                    highestScore = score;
                }
            }

            // Find who has the highest score
            List<Player> winners = new List<Player>();
            foreach (Player player in possibleWinners)
            {
                if (player.CalculateScore() == highestScore)
                {
                    winners.Add(player);
                }
            }

            // Announce the winners
            if (winners.Count == 1)
            {
                EndGame(winners[0], $"Game over! {winners[0].PlayerName()} wins with {highestScore} points!");
            }
            else if (winners.Count > 1)
            {
                // Create a string with all winner names
                string winnerNames = "";
                for (int i = 0; i < winners.Count; i++)
                {
                    winnerNames += winners[i].PlayerName();
                    if (i < winners.Count - 1)
                    {
                        winnerNames += ", ";
                    }
                }
                EndGame(winners[0], $"Game over! It's a tie! Winners: {winnerNames} with {highestScore} points!");
            }
        }

        /// Ends game, disables the Deal button, and displays the result
        private void EndGame(Player winner, string message = null)
        {
            gameEnded = true;
            btnDeal.Enabled = false;
            btnPass.Enabled = false;
            btnShuffle.Enabled = true;
            this.Text = "Blackjack";

            // Display message based on game ending
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

        /// Updates the ui to display all players, their cards, and their scores.
        /// Also highlights the current player's turn.
        private void DisplayPlayers()
        {
            playersList.Items.Clear();
            foreach (var player in players)
            {
                string playerInfo = player.PlayerName();

                // add score and cards information if player has cards
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
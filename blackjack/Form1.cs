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
            }

            DisplayPlayers();
        }

        private void DisplayPlayers()
        {
            playersList.Items.Clear();
            foreach (var player in players)
            {
                playersList.Items.Add(player.PlayerName());
            }
        }
    }
}
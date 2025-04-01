namespace blackjack
{
    public partial class Form1 : Form
    {
        private Deck deck;

        public Form1()
        {
            InitializeComponent();
            deck = new Deck();
        }

        private void btnShuffleClick(object sender, EventArgs e)
        {
            deck.Shuffle();
            deckList.Items.Clear();
            foreach (var card in deck.GetCards())
            {
                deckList.Items.Add(card);
            }
        }

        private void deckList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}


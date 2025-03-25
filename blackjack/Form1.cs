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
    }
}


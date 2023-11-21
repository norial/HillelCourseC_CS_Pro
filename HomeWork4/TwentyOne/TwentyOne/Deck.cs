
namespace TwentyOne
{
    struct Card
    {
        public string Suit;
        public string Rank;
        public int Value;
    }
    internal class Deck
    {

        private List<Card> cards;
        private List<Card> draft;
        public Deck()
        {
            CreateDeck();
            ShuffleDeck();
            draft = new List<Card>();
        }
        private void CreateDeck()
        {
            cards = new List<Card>();

            string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
            string[] ranks = { "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };

            foreach (var suit in suits)
            {
                foreach (var rank in ranks)
                {
                    int value = rank switch
                    {
                        "Jack" => 2,
                        "Queen" => 3,
                        "King" => 4,
                        "Ace" => 11,
                        _ => int.Parse(rank)
                    };
                    cards.Add(new Card { Suit = suit, Rank = rank, Value = value });
                }
            }
        }
        public void ShuffleDeck()
        {
            Random random = new Random();
            cards = cards.OrderBy(card => random.Next()).ToList();
        }
        public void PrintDeck()
        {
            foreach (var card in cards)
            {
                Console.WriteLine($"{card.Rank} of {card.Suit}");
            }
        }
        public Card DrawCard()
        {
            Card card = cards[0];
            cards.RemoveAt(0);
            return card;
        }
    }
}

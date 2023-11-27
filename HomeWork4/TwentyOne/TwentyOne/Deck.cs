
namespace TwentyOne
{
    public class Deck
    {

        private List<Card> cards;
        public Deck()
        {
            CreateDeck();
            ShuffleDeck();
        }

        private void CreateDeck()
        {
            cards = new List<Card>();

            Suits[] suits = (Suits[])Enum.GetValues(typeof(Suits));
            Ranks[] ranks = (Ranks[])Enum.GetValues(typeof(Ranks));

            foreach (var suit in suits)
            {
                foreach (var rank in ranks)
                {
                    int value = rank switch
                    {
                        Ranks.Jack => 2,
                        Ranks.Queen => 3,
                        Ranks.King => 4,
                        Ranks.Ace => 11,
                        _ => (int)rank
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyOne
{
    public class Player
    {
        public List<Card> Hand { get; private set; }
        public int Score { get; private set; }

        public Player()
        {
            Hand = new List<Card>();
            Score = 0;
        }

        public void AddCard(Card card)
        {
            Hand.Add(card);
            Score += card.Value;
        }

        public void ClearHand()
        {
            Hand.Clear();
            Score = 0;
        }
    }
}

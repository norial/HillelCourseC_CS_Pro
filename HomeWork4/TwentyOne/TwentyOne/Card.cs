using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyOne
{
    public struct Card
    {
        public Suits Suit { get; set; }

        public Ranks Rank { get; set; }

        public int Value { get; set; }
    }
    public enum Suits
    {
        Hearts,
        Diamonds,
        Clubs,
        Spades
    }

    public enum Ranks
    {
        Two = 2, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace
    }
}

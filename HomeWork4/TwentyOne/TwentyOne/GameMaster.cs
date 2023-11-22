using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyOne
{
    public class Game
    {
        private Deck deck;
        private Player player;
        private Player computer;

        public Player Player => player;
        public Player Computer => computer;
        public Deck Deck => deck;

        public Game()
        {
            deck = new Deck();
            player = new Player();
            computer = new Player();
        }

        public void StartGame()
        {
            for (int i = 0; i < 2; i++)
            {
                player.AddCard(deck.DrawCard());
                computer.AddCard(deck.DrawCard());
            }

            DisplayHands();
        }

        public void DisplayHands()
        {
            Console.WriteLine("Player 1:");
            DisplayHand(player);

            Console.WriteLine("Player 2 (computer):");
            DisplayHand(computer);
        }

        private void DisplayHand(Player player)
        {
            foreach (var card in player.Hand)
            {
                Console.WriteLine($"{card.Rank} of {card.Suit}: ({card.Value})");
            }

            Console.WriteLine($"Score: {player.Score}");
            Console.WriteLine();
        }
    }
}


namespace TwentyOne
{
    class Program
    {
        static void Main(string[] args)
        {
            int gamesPlayed = 0;
            int playerScore = 0;
            int computerScore = 0;

            while (true)
            {
                Console.Clear();
                Game game = new Game();
                game.StartGame();
                gamesPlayed++;

                while (true)
                {
                    Console.WriteLine("Would you like to take another card? (y/n)");
                    string decision = Console.ReadLine();

                    if (decision.ToLower() == "y")
                    {
                        Console.Clear();
                        game.Player.AddCard(game.Deck.DrawCard());
                        game.DisplayHands();

                        if (game.Player.Score == 21 || (game.Player.Score == 2 && game.Player.Hand.Count == 2))
                        {
                            Console.WriteLine("Player 1 wins!");
                            playerScore++;
                            break;
                        }

                        if (game.Player.Score > 21)
                        {
                            Console.WriteLine("Too many! Player 2 (computer) wins.");
                            computerScore++;
                            break;
                        }
                    }
                    else
                    {
                        while (game.Computer.Score < 17)
                        {
                            Console.Clear();
                            game.Computer.AddCard(game.Deck.DrawCard());
                            game.DisplayHands();
                            Thread.Sleep(1000);
                        }

                        if (game.Computer.Score > 21)
                        {
                            Console.WriteLine("Too many! Player 1 wins.");
                            playerScore++;
                        }
                        else if (game.Computer.Score > game.Player.Score)
                        {
                            Console.WriteLine("Player 2 (computer) has won.");
                            computerScore++;
                        }
                        else if (game.Computer.Score < game.Player.Score)
                        {
                            Console.WriteLine("Player 1 wins.");
                            playerScore++;
                        }
                        else
                        {
                            Console.WriteLine("A draw!");
                        }

                        break;
                    }
                }

                Console.WriteLine($"Statistics after {gamesPlayed} games:");
                Console.WriteLine($"Player 1: {playerScore} wins");
                Console.WriteLine($"Player 2 (computer): {computerScore} wins");

                Console.WriteLine("Would you like to play again? (y/n)");
                string playAgain = Console.ReadLine();
                if (playAgain.ToLower() != "y")
                {
                    Console.WriteLine("The game is over. Thank you for playing!");
                    break;
                }
            }
        }
    }
}
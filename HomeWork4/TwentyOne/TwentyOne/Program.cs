
namespace TwentyOne
{
    class Program
    {
        static void Main(string[] args)
        {
            int playerScore = 0;
            int computerScore = 0;
            int gamesPlayed = 0;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Player 1 - you, Player 2 - the computer");
                Deck deck = new Deck();
                Card playerCard1 = deck.DrawCard();
                Card computerCard1 = deck.DrawCard();
                Card playerCard2 = deck.DrawCard();
                Card computerCard2 = deck.DrawCard();

                int playerHand = playerCard1.Value + playerCard2.Value;
                int computerHand = computerCard1.Value + computerCard2.Value;
                int numberOfAces = 0;
                for (int i = 0; i < 2; i++)
                {

                    if (playerCard1.Rank == "Ace" || playerCard2.Rank == "Ace")
                    {
                        numberOfAces++;
                    }


                    if (computerCard1.Rank == "Ace" || computerCard2.Rank == "Ace")
                    {
                        numberOfAces++;
                    }
                }

                Console.WriteLine($"Player 1: {playerCard1.Rank} with {playerCard1.Suit}, {playerCard2.Rank} with {playerCard2.Suit} ({playerHand} points)");
                Console.WriteLine($"Player 2 (computer): {computerCard1.Rank} of {computerCard1.Suit}, {computerCard2.Rank} of {computerCard2.Suit} ({computerHand} points)");

                while (true)
                {
                    if (numberOfAces >= 2 && (playerHand == 22 || computerHand == 22))
                    {
                        if (playerHand == 22)
                        {
                            Console.WriteLine("Player 1 wins with two aces!");
                            playerScore++;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Player 2 (computer) wins with two aces!");
                            computerScore++;
                            break;
                        }
                    }
                    Console.WriteLine("Would you like to take another card? (y/n)");
                    string decision = Console.ReadLine();

                    if (decision.ToLower() == "y")
                    {
                        Card playerCard = deck.DrawCard();
                        playerHand += playerCard.Value;
                        Console.WriteLine($"Player 1: {playerCard.Rank} of {playerCard.Suit} ({playerHand} points)");

                        if (playerHand > 21)
                        {
                            Console.WriteLine("Too much! Player 2 (computer) has won.");
                            computerScore++;
                            break;
                        }
                    }
                    else
                    {
                        while (computerHand < 17)
                        {
                            Card computerCard = deck.DrawCard();
                            computerHand += computerCard.Value;
                            Console.WriteLine($"Player 2 (computer): {computerCard.Rank} of {computerCard.Suit} ({computerHand} points)");
                        }

                        if (computerHand > 21)
                        {
                            Console.WriteLine("Too much! Player 1 wins.");
                            playerScore++;
                        }
                        else if (computerHand > playerHand)
                        {
                            Console.WriteLine("Player 2 (computer) wins.");
                            computerScore++;
                        }
                        else if (computerHand < playerHand)
                        {
                            Console.WriteLine("Player 1 has won.");
                            playerScore++;
                        }
                        else
                        {
                            Console.WriteLine("A draw!");
                        }

                        break;
                    }
                }

                gamesPlayed++;

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
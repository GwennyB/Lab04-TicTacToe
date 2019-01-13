using System;
using Lab04_TicTacToe.Classes;

namespace Lab04_TicTacToe
{
    public class Program
    {
        static void Main(string[] args)
        {
            // set up player 1
            Player p1 = new Player();
            // get/validate name
            try
            {

                do
                {
                    Console.Clear();
                    Console.WriteLine("Player 1: What is your name?");
                    p1.Name = Console.ReadLine();
                } while (p1.Name == "");
            }
            catch (Exception)
            {
                throw;
            }
            p1.Marker = "X";
            // Player 1 plays first
            p1.IsTurn = true;

            // set up player 2
            Player p2 = new Player();
            // get/validate name
            try
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("Player 2: What is your name?");
                    p2.Name = Console.ReadLine();
                } while (p2.Name == "");
            }
            catch (Exception)
            {
                throw;
            }
            p2.Marker = "O";

            // player instructions and start
            Console.Clear();
            Console.WriteLine($"\nWelcome, {p1.Name} and {p2.Name}!\n");
            Console.WriteLine($"{p1.Name}, you'll play {p1.Marker}'s.");
            Console.WriteLine($"{p2.Name}, you'll play {p2.Marker}'s.\n\n");

            Console.WriteLine("Press ENTER when you're ready to start.");
            Console.ReadLine();

            // launch game, and keep playing new games until players choose to exit
            bool keepPlaying = true;
            while(keepPlaying)
            {
                Game game = new Game(p1, p2);
                Player winner = game.Play();

                // game results
                Console.WriteLine($"{winner.Name} wins! Would you like to play another round?");
                Console.WriteLine("(Enter 'y' to play again, or press ENTER to quit.)");
                // choose whether to exit or play again
                try
                {
                    string playAgain = Console.ReadLine();
                    if(playAgain.ToLower() != "y")
                    {
                        keepPlaying = false;
                    }
                }
                catch
                {
                    throw;
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Lab04_TicTacToe.Classes
{
    public class Board
    {
		/// <summary>
		/// Tic Tac Toe Gameboard states
		/// </summary>
		public string[,] GameBoard = new string[,]
		{
			{"1", "2", "3"},
			{"4", "5", "6"},
			{"7", "8", "9"},
		};

        /// <summary>
        /// Displays the game board in its current state of play
        /// </summary>
		public void DisplayBoard()
		{
            Console.WriteLine("\n Let's Play Tic-Tac-Toe!\n");
            //TODO: Output the board to the console
            for (int i = 0; i < 3; i++)
            {
                Console.Write("     ");
                for (int k = 0; k < 3; k++)
                {
                    Console.Write($" [ {GameBoard[i, k]} ] ");
                }
                Console.Write("\n");
            }
            Console.WriteLine("\n\n");
		}
	}
}

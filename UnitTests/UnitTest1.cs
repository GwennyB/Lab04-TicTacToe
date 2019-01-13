using System;
using Xunit;
using Lab04_TicTacToe.Classes;

namespace UnitTests
{
    public class UnitTest1
    {
        /// <summary>
        /// Validates that all winning combinations return 'true'
        /// </summary>
        /// <param name="value"> array containing numbers of winning positions </param>
        [Theory]
        [InlineData(new[] { 4, 5, 6 })]
        [InlineData(new[] { 7, 8, 9 })]
        [InlineData(new[] { 1, 4, 7 })]
        [InlineData(new[] { 2, 5, 8 })]
        [InlineData(new[] { 3, 6, 9 })]
        [InlineData(new[] { 1, 5, 9 })]
        [InlineData(new[] { 3, 5, 7 })]
        public void CheckForWinner_ReturnsTrue(int[] value)
        {
            Player testPlayer1 = new Player();
            Player testPlayer2 = new Player();
            Game testGame = new Game(testPlayer1, testPlayer2);
            Board testBoard = new Board();

            foreach (int spentPosition in value)
            {
                Position pos = Player.PositionForNumber(spentPosition);
                testBoard.GameBoard[pos.Row, pos.Column] = "X";
            }
            Assert.True(testGame.CheckForWinner(testBoard));
        }

        /// <summary>
        /// Validates that unplayed (ie - not winning) board returns 'false'
        /// </summary>
        [Fact]
        public void CheckForWinner_ReturnsFalse()
        {
            Player testPlayer1 = new Player();
            Player testPlayer2 = new Player();
            Game testGame = new Game(testPlayer1, testPlayer2);
            Board testBoard = new Board();

            Assert.False(testGame.CheckForWinner(testBoard));
        }

        /// <summary>
        /// Validates that player2 IsTurn switches from 'false' to 'true'
        /// </summary>
        [Fact]
        public void SwitchPlayer_PlayerOneIsTurnTrueAfterSwitch()
        {
            Player testPlayer1 = new Player();
            Player testPlayer2 = new Player();
            Game testGame = new Game(testPlayer1, testPlayer2);

            testPlayer1.IsTurn = true;
            testPlayer2.IsTurn = false;

            testGame.SwitchPlayer();

            Assert.True(testPlayer2.IsTurn);
        }

        /// <summary>
        /// Validates that player1 IsTurn switches from 'true' to 'false'
        /// </summary>
        [Fact]
        public void SwitchPlayer_PlayerOneIsTurnFalseAfterSwitch()
        {
            Player testPlayer1 = new Player();
            Player testPlayer2 = new Player();
            Game testGame = new Game(testPlayer1, testPlayer2);

            testPlayer1.IsTurn = true;
            testPlayer2.IsTurn = false;

            testGame.SwitchPlayer();

            Assert.False(testPlayer1.IsTurn);
        }

    }


}
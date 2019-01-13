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

        /// <summary>
        /// Validates that all valid number selections return the correct coordinates
        /// </summary>
        /// <param name="entered"> test inputs - all valid input strings </param>
        /// <param name="returned"> test inputs - correct coordinates for each valid input string </param>
        [Theory]
        [InlineData( "1", new[] { 0, 0 } )]
        [InlineData( "2", new[] { 0, 1 } )]
        [InlineData( "3", new[] { 0, 2 } )]
        [InlineData( "4", new[] { 1, 0 } )]
        [InlineData( "5", new[] { 1, 1 } )]
        [InlineData( "6", new[] { 1, 2 } )]
        [InlineData( "7", new[] { 2, 0 } )]
        [InlineData( "8", new[] { 2, 1 } )]
        [InlineData( "9", new[] { 2, 2 } )]
        public void PositionForNumber_ReturnsCorrectCoordinates(string entered, int[] returned )
        {
            Position coordinates = new Position(returned[0],returned[1]);
            Player testPlayer = new Player();
            Position response = Player.PositionForNumber(Convert.ToInt32(entered));
            Assert.Equal(coordinates.Row, response.Row);
            Assert.Equal(coordinates.Column, response.Column);
        }

        /// <summary>
        /// Validates that invalid number selections return null
        /// </summary>
        /// <param name="entered"> test data: selected 0 (out of range) and 55 (multiple digits, but each digit is in range) to test </param>
        [Theory]
        [InlineData(0)]
        [InlineData(55)]
        public void PositionForNumber_ReturnsNullForInvalidInputs(int entered)
        {
            Player testPlayer = new Player();
            Assert.Null(Player.PositionForNumber(entered));
        }
    }


}
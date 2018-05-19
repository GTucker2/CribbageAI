namespace Cribbage
{
    using System;

    /// <summary>
    /// This class defines the CribbageBoard object, a representation of a physical cribbage board.
    /// We may use object functions to move pegs accross the board and to check for game-win status.
    /// </summary>
    public class CribbageBoard
    {
        // Constants for defining board size.
        private const int START_ROW = 0;
        private const int TOTAL_ROWS = 121;

        // Constants for defining board constraints.
        private const int MAX_PLAYERS = 3;
        private const int DEFAULT_PLAYERS = 2;
        // The default winner is typically '0', for none.
        private const int DEFAULT_WINNER = 0;

        // Constants for defining movements. 
        private const byte ADVANCE_PN = 0b00000001;
        private const byte CLEAR_ROW = 0b00000000;

        // The rows of the cribbage board.
        private byte [] rows;

        // The current locations of the players.
        private int [] playerLocs;

        // The player who has won the board.
        private int winningPlayer; 

        /// <summary>
        /// Creates a CribbageBoard object; a representation of a physical cribbage board.
        /// </summary>
        /// <param name="numPlayers">
        /// The number of players playing with this board.
        /// </param>
        public CribbageBoard(int numPlayers)
        {
            // Check for invalid parameters.
            if (numPlayers > MAX_PLAYERS)
            {
                Console.WriteLine("Too many players. Defaulting to " + DEFAULT_PLAYERS + ".");
                numPlayers = DEFAULT_PLAYERS;
            }

            // Initialize the board's winner (default is typically '0', for none).
            winningPlayer = DEFAULT_WINNER;

            // Create the empty rows and the table of player locations.
            rows = new byte [TOTAL_ROWS];
            playerLocs = new int [numPlayers];

            /* The start row has all playing peg-holes filled.
               Initialise all board rows as empty except for 
               the starting row. All players are initialized 
               to being at the start row.
            */
            rows[START_ROW] = ADVANCE_PN;
            for (int playerNum = 0; playerNum < numPlayers; playerNum++)
                rows[START_ROW] &= (ADVANCE_PN << 1);
            for (int row = START_ROW; row <= TOTAL_ROWS; row++)
                rows[row] = CLEAR_ROW;
            for (int playerNum = 0; playerNum < numPlayers; playerNum++)
                playerLocs[playerNum] = START_ROW;
        }

        /// <summary>
        /// Moves a peg from one row on the board to another, or generates an error message.
        /// </summary>
        /// <param name="playerNum">
        /// The number of specific player whose peg is being moved.
        /// </param>
        /// <param name="rowNum">
        /// The number of the row which the player is attempting to move to.
        /// </param>
        /// <returns> 
        /// <c>true</c> if the specified move was made; otherwise, <c>false</c>.
        /// </returns>
        public bool MovePeg(int playerNum, int rowNum)
        {
            // Move the specified player to the specified row, or return false.
            // If the final row is reached, specify the player as the winning player.
            switch(playerLocs[playerNum])
            {
                case int loc when loc > rowNum:
                    Console.WriteLine("Can't move player to an earlier row. No movement made.");
                    break;
                case int loc when loc == rowNum:
                    Console.WriteLine("Can't move player to the same row. No movement made.");
                    break;
                default:
                    playerLocs[playerNum] = rowNum;
                    if (rowNum == TOTAL_ROWS) winningPlayer = playerNum;
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Checks if the board has been won.
        /// </summary>
        /// <returns>
        /// The player who has won the board, or '0' if this has not yet happened.
        /// </returns>
        public int CheckWin() => winningPlayer;
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetris
{
    /// <summary>
    /// Represents a single game board
    /// </summary>
    public class GameBoard
    {
        public const int Width = 9;
        public const int Height = 19;
        /// <summary>
        /// Checks if X/Y values passed in are valid.
        /// </summary>
        /// <param name="x">X cord to check</param>
        /// <param name="y">Y cord to check</param>
        /// <exception cref="ArgumentException">If either X/Y are invalid</exception>
        private static void CheckCords(int x, int y)
        {
            if (x < 0 || x >= Width)
            {
                throw new ArgumentException($"X outside valid range. Expected [0..{Width}), found {x}");
            }

            if (y < 0 || y >= Height)
            {
                throw new ArgumentException($"Y outside valid range. Expected [0..{Height}), found {y}");
            }
        }
        
        private Color[] board = new Color[Width*Height];
        /// <summary>
        /// Get a color at the specified position
        /// </summary>
        /// <param name="x">The X position</param>
        /// <param name="y">The Y position</param>
        /// <returns>The color at the specified position</returns>
        /// <exception cref="ArgumentException">X/Y value outside board</exception>

        public Color Get(int x, int y)
        {
            CheckCords(x, y);
            int index = y * Width + x;
            
            return board[index];
        }
        /// <summary>
        /// Set a value on the game board
        /// </summary>
        /// <param name="x">X position to set</param>
        /// <param name="y">Y position to set</param>
        /// <param name="value">Value to set</param>
        /// <exception cref="ArgumentException">X/Y value outside board</exception>

        public void Set(int x, int y, Color value)
        {
            CheckCords(x, y);
            int index = y * Width + x;
            
            board[index] = value;
        }
        /// <summary>
        /// Clear rows, moving rows above them down.
        /// </summary>
        /// <param name="rows">Amount of rows to clear</param>
        /// <param name="bottom">Bottommost row</param>

        public void ClearLines(int rows, int bottom)
        {
            // TODO: please test
            // 0 1 2
            // 3 4 5
            // 6 7 8
            for (int row = bottom; row < bottom + rows; row++)
            {
                Buffer.BlockCopy(board, 0, board, row*Width, row*Width); // Copy rows down (might not work yet, untested)
                Array.Clear(board, 0, Width); // clear top row
            }
            
        }
    }
}

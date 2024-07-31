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
        /// Clear a single row, moving rows above it down
        /// </summary>
        /// <param name="row">Row to clear</param>

        public void ClearLine(int row)
        {
            Buffer.BlockCopy(board, 0, board, Width, row*Width);
            Array.Clear(board, 0, Width); // clear top row
        }
        /// <summary>
        /// Clear rowCount rows starting from the bottom row
        /// </summary>
        /// <param name="bottom">Bottom row of the clear</param>
        /// <param name="rowCount">Rows to clear</param>
        public void ClearLines(int bottom, int rowCount)
        {
            while (rowCount > 0)
            {
                ClearLine(bottom);
                rowCount--;
            }
        }
        
        /// <summary>
        /// Returns a single row of the board as a span
        /// </summary>
        /// <param name="row">Row to return</param>
        /// <returns>The specified row as a span</returns>
        public Span<Color> GetRow(int row)
        {
            CheckCords(0, row);
            return board.AsSpan(row * Width, Width);
        }
    }
}

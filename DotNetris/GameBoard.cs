using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetris
{
    
    internal class GameBoard
    {
        public const int Width = 9;
        public const int Height = 19;

        private int[] board = new int[Width*Height];
        /// <summary>
        /// Get a color at the specified position
        /// </summary>
        /// <param name="x">The X position</param>
        /// <param name="y">The Y position</param>
        /// <returns>The color at the specified position</returns>
        /// <exception cref="IndexOutOfRangeException">X/Y value outside board</exception>

        public int Get(int x, int y)
        {
            int index = y * Width + x;
            if (index > board.Length || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            return board[index];
        }
        /// <summary>
        /// Set a value on the game board
        /// </summary>
        /// <param name="x">X position to set</param>
        /// <param name="y">Y position to set</param>
        /// <param name="value">Value to set</param>
        /// <exception cref="IndexOutOfRangeException">X/Y value outside board</exception>

        public void Set(int x, int y, int value)
        {
            int index = y * Width + x;
            if (index > board.Length || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            board[index] = value;
        }

        public void ClearLines(int rows, int bottom)
        {
            // 0 1 2
            // 3 4 5
            // 6 7 8
            for (int row = bottom; row < bottom + rows; row++)
            {
                Buffer.BlockCopy(board, 0, board, row*Width, row*Width);
                Array.Clear(board, 0, Width);
            }
            
        }
    }
}

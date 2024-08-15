using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DotNetris
{
    public partial class GameBoardRender : Control
    {
        public Game game;

        public const int TileSize = 32; // in pixels
        
        public override Size GetPreferredSize(Size proposedSize)
        {
            return new Size(
                GameBoard.Width * GameBoardRender.TileSize,
                GameBoard.Height * GameBoardRender.TileSize
            );
        }

        public GameBoardRender()
        {
            game = new Game();
            InitializeComponent();
            Height = GameBoard.Height * GameBoardRender.TileSize;
            Width = GameBoard.Width * GameBoardRender.TileSize;

            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            // draw map
            
            // background

            pe.Graphics.FillRectangle(new SolidBrush(System.Drawing.Color.Black), 0, 0, GameBoard.Width * GameBoardRender.TileSize, GameBoard.Height * GameBoardRender.TileSize);
            
            //var pen = new Pen(System.Drawing.Color.Black);
            int index = 0;
            foreach (var color in game.Board.GetBoard())
            {
                if (color == Color.Empty)
                {
                    index++;
                    continue;
                }
                var x = index % GameBoard.Width;
                var y = index / GameBoard.Width;
                var real_x = x * TileSize;
                var real_y = y * TileSize;
                var toDraw = color.ToDrawable();
                var pen = new SolidBrush(toDraw); // maybe optimize here
                pe.Graphics.FillRectangle(pen, real_x, real_y, TileSize, TileSize);
                index++;
            }

            // draw current piece
            var pieceDraw = new SolidBrush(game.CurrentPiece.Color.ToDrawable());
            for (int pieceIndex = 0; pieceIndex < 9; pieceIndex++)
            {
                var x = pieceIndex % 3 + (game.PiecePosition.Item1);
                var y = pieceIndex / 3 + (game.PiecePosition.Item2);
                var real_x = x * TileSize;
                var real_y = y * TileSize;
                if (game.CurrentPiece.Data[pieceIndex])
                {
                    pe.Graphics.FillRectangle(pieceDraw, real_x, real_y, TileSize, TileSize);
                }

            }

        }
    }
}

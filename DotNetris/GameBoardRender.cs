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
            var rects = new Dictionary<Color, List<Rectangle>>();
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

                if (!rects.ContainsKey(color))
                {
                    rects.Add(color, new List<Rectangle>());
                }
                rects[color].Add(new Rectangle(real_x, real_y, TileSize, TileSize));
                index++;
            }

            // draw current piece
            // make sure our rects dict has the piece color
            if (!rects.ContainsKey(game.CurrentPiece.Color))
            {
                rects.Add(game.CurrentPiece.Color, new List<Rectangle>(9));
            }
            for (int pieceIndex = 0; pieceIndex < 9; pieceIndex++)
            {
                var x = pieceIndex % 3 + (game.PiecePosition.Item1);
                var y = pieceIndex / 3 + (game.PiecePosition.Item2);
                var real_x = x * TileSize;
                var real_y = y * TileSize;
                if (game.CurrentPiece.Data[pieceIndex])
                {
                    rects[game.CurrentPiece.Color].Add(new Rectangle(real_x, real_y, TileSize, TileSize));
                }
            }

            foreach (var colorRects in rects)
            {
                var brush = new SolidBrush(colorRects.Key.ToDrawable());
                pe.Graphics.FillRectangles(brush, colorRects.Value.ToArray());
            }

        }
    }
}

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

        private Color[] lastFrame = Enumerable.Repeat(Color.Void, GameBoard.Width * GameBoard.Height).ToArray();

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

            Color[] drawTarget = Enumerable.Repeat(Color.Empty, GameBoard.Width * GameBoard.Height).ToArray();

            //pe.Graphics.FillRectangle(new SolidBrush(System.Drawing.Color.Black), 0, 0, GameBoard.Width * GameBoardRender.TileSize, GameBoard.Height * GameBoardRender.TileSize);
            
            //var pen = new Pen(System.Drawing.Color.Black);
            game.Board.GetBoard().CopyTo(drawTarget); // draw the board

            // copy the piece on
            for (int pieceIndex = 0; pieceIndex < 9; pieceIndex++)
            {
                var x = pieceIndex % 3 + (game.PiecePosition.Item1);
                var y = pieceIndex / 3 + (game.PiecePosition.Item2);
                var index = x + (y * GameBoard.Width);
                if (game.CurrentPiece.Data[pieceIndex])
                {
                    // write the piece
                    drawTarget[index] = game.CurrentPiece.Color;
                } 
            }

            // diff the drawTarget with the last board
            var diff = new Dictionary<Color, List<Rectangle>>();

            for (int index = 0; index < drawTarget.Length; index++)
            {
                if (drawTarget[index] != lastFrame[index])
                {
                    if (!diff.ContainsKey(drawTarget[index]))
                    {
                        diff.Add(drawTarget[index], new List<Rectangle>());
                    }
                    var x = index % GameBoard.Width;
                    var y = index / GameBoard.Width;
                    var real_x = x * TileSize;
                    var real_y = y * TileSize;
                    // put it in the diff
                    diff[drawTarget[index]].Add(new Rectangle(real_x, real_y, TileSize, TileSize));
                }
            }
            // draw the diff
            Console.Out.WriteLine("hello");
            foreach (var toDraw in diff)
            {

                var fill = new SolidBrush(toDraw.Key.ToDrawable());
                pe.Graphics.FillRectangles(fill, toDraw.Value.ToArray());
            }
        }
    }
}

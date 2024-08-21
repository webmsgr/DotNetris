using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetris
{
    public partial class PieceRender : Control
    {
        private Piece _piece = new Piece(new[] { false, false, false, false, false, false, false, false, false },
            Color.Empty);

        public Piece CurrentPiece
        {
            get => _piece;
            set
            {
                _piece = value;
                Invalidate();
            }
        }
        public PieceRender(Piece piece)
        {
            InitializeComponent();
            CurrentPiece = piece;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var background = new SolidBrush(Color.Empty.ToDrawable());
            var foreground = new SolidBrush(CurrentPiece.Color.ToDrawable());
            for (int index = 0; index < 9; index++)
            {
                int x = index % 3;
                int y = index / 3;
                int real_x = x * GameBoardRender.TileSize;
                int real_y = y * GameBoardRender.TileSize;
                if (CurrentPiece.Data[index])
                {
                    e.Graphics.FillRectangle(foreground, new Rectangle(real_x, real_y, GameBoardRender.TileSize, GameBoardRender.TileSize));
                }
                else
                {
                    e.Graphics.FillRectangle(background, new Rectangle(real_x, real_y, GameBoardRender.TileSize, GameBoardRender.TileSize));
                }
            }
        }
    }
}

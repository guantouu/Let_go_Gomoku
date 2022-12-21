using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Gomoku
{
    class WhitePiece : Piece
    {
        public WhitePiece(int x, int y) : base(x, y)
        {
            this.pieceLocation = new Point(x, y);
            this.Image = Properties.Resources.white;
        }
        public override PieceType GetPieceType()
        {
            return PieceType.WHITE;
        }
        public override Point GetPoint()
        {
            Point p = new Point(this.pieceLocation.X, this.pieceLocation.Y);
            return p;
        }
    }
}

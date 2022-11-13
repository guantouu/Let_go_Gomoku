using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku
{
    class BlackPiece : Piece
    {
        public BlackPiece(int x, int y): base(x,y)
        {
            this.pieceLocation = new Point(x, y);
            this.Image = Properties.Resources.black;
        }
        public override PieceType GetPieceType()
        {
            return PieceType.BLACK;
        }

        public override Point GetPoint()
        {
            Point p = new Point(this.pieceLocation.X, this.pieceLocation.Y);
            return p;
        }
    }
}

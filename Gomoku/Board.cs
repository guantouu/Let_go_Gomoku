using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Gomoku
{
    class Board
    {
        public static readonly int NODE_COUNT = 15;
        private static readonly Point NO_MATCH_NODE = new Point(-1, -1);

        private static readonly int OFFSET = 65;
        private static readonly int NODE_RADIUS = 10;
        private static readonly int NODE_DISTANCE = 60;

        private Piece[,] pieces = new Piece[NODE_COUNT, NODE_COUNT];

        private Point lastPlacedNode = NO_MATCH_NODE;
        public Point LastPlaceNode { get { return lastPlacedNode; } }

        public PieceType GetPieceType(int nodeIdX, int nodeIdY)
        {
            if (pieces[nodeIdX, nodeIdY] == null)
                return PieceType.NONE;
            return pieces[nodeIdX, nodeIdY].GetPieceType();
        }
        public bool CanBePlaced(int x, int y)
        {
            Point nodeId = findTheClosetNode(x, y);

            if (nodeId == NO_MATCH_NODE)
                return false;
            if (pieces[nodeId.X, nodeId.Y] != null)
                return false;
            return true;
        }   

        public Piece PlaceAPiece(int x ,int y, PieceType type)
        {
            Point nodeId = findTheClosetNode(x, y);

            if (nodeId == NO_MATCH_NODE)
                return null;
            if (pieces[nodeId.X, nodeId.Y] != null)
                return null;

            Point formPos = convertToFormPosition(nodeId);


            if (type == PieceType.BLACK)
                pieces[nodeId.X, nodeId.Y] = new BlackPiece(formPos.X, formPos.Y);
            else
                pieces[nodeId.X, nodeId.Y] = new WhitePiece(formPos.X, formPos.Y);

            lastPlacedNode = nodeId;
            return pieces[nodeId.X, nodeId.Y];
        }

        public void RemoveAPiece(Piece removePiece)
        {
            int x = removePiece.GetPoint().X;
            int y = removePiece.GetPoint().Y;
            Point nodeId = findTheClosetNode(x, y);
            pieces[nodeId.X, nodeId.Y] = null;
        }

        private Point convertToFormPosition(Point nodeId)
        {
            Point formPosition = new Point();
            formPosition.X = nodeId.X * NODE_DISTANCE + OFFSET;
            formPosition.Y = nodeId.Y * NODE_DISTANCE + OFFSET;
            return formPosition;
        }


        private Point findTheClosetNode(int x,int y)
        {
            int nodeIdX = findTheClosetNode(x);
            if (nodeIdX == -1 || nodeIdX >= NODE_COUNT)
                return NO_MATCH_NODE;
            int nodeIdY = findTheClosetNode(y);
            if (nodeIdY == -1 || nodeIdX >= NODE_COUNT)
                return NO_MATCH_NODE;
            return new Point(nodeIdX, nodeIdY);
        }

        private int findTheClosetNode(int pos)
        {
            if (pos < OFFSET - NODE_RADIUS)
                return -1;

            pos -= OFFSET;
            int quotient = pos / NODE_DISTANCE;
            int remainder = pos % NODE_DISTANCE;

            if (remainder <= NODE_RADIUS)
                return quotient;
            else if (remainder >= NODE_DISTANCE - NODE_RADIUS)
                return quotient + 1;
            else
                return -1;
        }
    }
}

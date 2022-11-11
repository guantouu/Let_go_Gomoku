﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku
{
    class Game
    {
        private Board board = new Board();
        private PieceType currentPlayer = PieceType.BLACK;

        private PieceType winner = PieceType.NONE;
        public PieceType Winner { get { return winner; } }
        public bool CanBePlaced(int x, int y)
        {
            return board.CanBePlaced(x, y);
        }

        public Piece PlaceAPiece(int x, int y)
        {
            Piece piece = board.PlaceAPiece(x, y, currentPlayer);
            if (piece != null)
            {
                CheckWinner();
                if (currentPlayer == PieceType.BLACK)
                    currentPlayer = PieceType.WHITE;
                else
                    currentPlayer = PieceType.BLACK;
                return piece;
            }

            return null;
        }

        private void CheckWinner()
        {
            int centerX = board.LastPlaceNode.X;
            int centerY = board.LastPlaceNode.Y;

            for (int xDir = -1; xDir <= 1; xDir++)
            {
                for (int yDir = -1; yDir <= 1; yDir++)
                {
                    if (xDir == 0 && yDir == 0)
                        continue;

                    int count = 1;
                    while (count < 5)
                    {
                        int targetX = centerX + count * xDir;
                        int targetY = centerY + count * yDir;

                        if (targetX < 0 || targetX >= Board.NODE_COUNT ||
                            targetY < 0 || targetY >= Board.NODE_COUNT ||
                            board.GetPieceType(targetX, targetY) != currentPlayer)
                            break;
                        count++;
                    }

                    if (count == 5)
                        winner = currentPlayer;

                    int count2 = 0;
                    while (count2 < 5)
                    {
                        int targetX = centerX - count2 * xDir;
                        int targetY = centerY - count2 * yDir;

                        if (targetX < 0 || targetX >= Board.NODE_COUNT ||
                        targetY < 0 || targetY >= Board.NODE_COUNT ||
                        board.GetPieceType(targetX, targetY) != currentPlayer)
                        {
                            break;
                        }
                        count2++;
                    }
                    if (count + count2 > 5)
                        winner = currentPlayer;
                }



            }

        }
    }
}

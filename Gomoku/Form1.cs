﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gomoku
{
    public partial class Form1 : Form
    {
        private Game game = new Game();
        public Form1()
        {
            InitializeComponent();
            Height = Properties.Resources.board.Height;
            Width = Properties.Resources.board.Height;
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Piece piece = game.PlaceAPiece(e.X, e.Y);
            if (piece != null)
            {
                this.Controls.Add(piece);

                if(game.Winner == PieceType.BLACK)
                {
                    MessageBox.Show("黑棋獲勝");
                }
                else if (game.Winner == PieceType.WHITE)
                {
                    MessageBox.Show("白棋獲勝");
                }
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (game.CanBePlaced(e.X, e.Y))
                this.Cursor = Cursors.Hand;
            else
                this.Cursor = Cursors.Default;
        }

        
    }
}

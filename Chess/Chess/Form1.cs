using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public partial class Form1 : Form
    {        
        string[,] chessboard_location = new string[8, 8];
        PreviousClickGetterSetter prevclick = new PreviousClickGetterSetter();
        PictureBox prev = new PictureBox();
        PictureBox next = new PictureBox();

        public void Place_White()
        {
            chessboard_location[0, 0] = "rook_white";   picBox00.Image = Chess.Properties.Resources.rook_white;
            chessboard_location[7, 0] = "rook_white";   picBox70.Image = Chess.Properties.Resources.rook_white;

            chessboard_location[1, 0] = "knight_white"; picBox10.Image = Chess.Properties.Resources.knight_white;
            chessboard_location[6, 0] = "knight_white"; picBox60.Image = Chess.Properties.Resources.knight_white;

            chessboard_location[2, 0] = "bishop_white"; picBox20.Image = Chess.Properties.Resources.bishop_white;
            chessboard_location[5, 0] = "bishop_white"; picBox50.Image = Chess.Properties.Resources.bishop_white;

            chessboard_location[3, 0] = "queen_white";  picBox30.Image = Chess.Properties.Resources.queen_white;
            chessboard_location[4, 0] = "king_white";   picBox40.Image = Chess.Properties.Resources.king_white;

            for (int i = 0; i < 8; i++)
                chessboard_location[i, 1] = "pawn_white";

            picBox01.Image = Chess.Properties.Resources.pawn_white;
            picBox11.Image = Chess.Properties.Resources.pawn_white;
            picBox21.Image = Chess.Properties.Resources.pawn_white;
            picBox31.Image = Chess.Properties.Resources.pawn_white;
            picBox41.Image = Chess.Properties.Resources.pawn_white;
            picBox51.Image = Chess.Properties.Resources.pawn_white;
            picBox61.Image = Chess.Properties.Resources.pawn_white;
            picBox71.Image = Chess.Properties.Resources.pawn_white;
        }
        public void Place_Black()
        {
            chessboard_location[0, 7] = "rook_black";   picBox07.Image = Chess.Properties.Resources.rook_black;
            chessboard_location[7, 7] = "rook_black";   picBox77.Image = Chess.Properties.Resources.rook_black;

            chessboard_location[1, 7] = "knight_black"; picBox17.Image = Chess.Properties.Resources.knight_black;
            chessboard_location[6, 7] = "knight_black"; picBox67.Image = Chess.Properties.Resources.knight_black;

            chessboard_location[2, 7] = "bishop_black"; picBox27.Image = Chess.Properties.Resources.bishop_black;
            chessboard_location[5, 7] = "bishop_black"; picBox57.Image = Chess.Properties.Resources.bishop_black;

            chessboard_location[3, 7] = "queen_black";  picBox37.Image = Chess.Properties.Resources.queen_black;
            chessboard_location[4, 7] = "king_black";   picBox47.Image = Chess.Properties.Resources.king_black;

            for (int i = 0; i < 8; i++)
                chessboard_location[i, 6] = "pawn_black";

            picBox06.Image = Chess.Properties.Resources.pawn_black;
            picBox16.Image = Chess.Properties.Resources.pawn_black;
            picBox26.Image = Chess.Properties.Resources.pawn_black;
            picBox36.Image = Chess.Properties.Resources.pawn_black;
            picBox46.Image = Chess.Properties.Resources.pawn_black;
            picBox56.Image = Chess.Properties.Resources.pawn_black;
            picBox66.Image = Chess.Properties.Resources.pawn_black;
            picBox76.Image = Chess.Properties.Resources.pawn_black;

        }

        public Form1()
        {
            InitializeComponent();
            Place_White();
            Place_Black();
            prevclick.ArraySetter(chessboard_location);
        }
        int i = 0;
        private void OnClick(object sender, EventArgs e)
        {
            PictureBox p = sender as PictureBox;
            //MessageBox.Show(p.Name);
            prevclick.MainFunction(p);
            if(prevclick.getTurn() % 2 == 1)
            {
                label3.Text = "Turn : White";
                pictureBox1.BackColor = Color.White;
            }
            else
            {
                label3.Text = "Turn : Black";
                pictureBox1.BackColor = Color.Black;
            }
            label4.Text ="Turn : " + prevclick.getTurn();
            if (i % 2 == 0)
            {
                label2.Text = "To :";
                label1.Text = "From :\n" + 
                    Convert.ToChar(int.Parse(p.Name.Substring(6, 1)) + 65) +    //Letter, x axis
                    (int.Parse(p.Name.Substring(7, 1)) + 1);                    //Number, y axis

                i++;
            }
            else
            {
                label2.Text = "To :\n" +
                    Convert.ToChar(int.Parse(p.Name.Substring(6, 1)) + 65) +    //Letter, x axis
                    (int.Parse(p.Name.Substring(7, 1)) + 1);                    //Number, y axis

                prev = prevclick.GetPreviousClick();
                next = prevclick.GetNextClick();                
                i++;
                //MessageBox.Show(prev.Name + next.Name);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
//picBox00.Image = Chess.Properties.Resources.rook_white;
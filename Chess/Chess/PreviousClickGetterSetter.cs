using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    class PreviousClickGetterSetter
    {
        private PictureBox prev = new PictureBox(); //prev.name == picBox**
        private PictureBox next = new PictureBox();
        private bool previous_flag = true;
        string[,] chessboard_location;
        int x, y;
        
        public PictureBox GetPreviousClick()
        {
            return prev;
        }

        public void SetPreviousClick(PictureBox p)
        {
            this.prev = p;
        }

        public PictureBox GetNextClick()
        {
            return next;
        }

        public void SetNextClick(PictureBox p)
        {
            this.next = p;
        }

        public void MainFunction(PictureBox p)
        {
            if(previous_flag == true)//Sets previous/first click.
            {
                this.prev = p;
                previous_flag = false;
            }
            else//Sets the next/second click, and then updates the images, apply deciding rules here.SEPERATE MAINFUNCTION INTO TWO
            {
                this.next = p;
                previous_flag = true;
                if (DecideFunction())
                {                    
                    next.Image = prev.Image;
                    prev.Image = null;
                    //MessageBox.Show("Legal");
                    UpdateChessBoard(); //Updates string based chessboard. ***FINALLY***
                }                    
                else
                    MessageBox.Show("Error, rule violation");                
                //MessageBox.Show(chessboard_location[0, 0]);
                //MessageBox.Show(chessboard_location[int.Parse(prev.Name.Substring(6, 1)), int.Parse(prev.Name.Substring(7, 1))]);                                
            }            

        }

        public bool DecideFunction()
        {
            return FriendlyFree() && FromIsNotNull() && MovementSetDecider() && ObstacleCheckerDecider() && PlayerTurnDecider() && TargetIsNotKing();
        }

        public void ArraySetter(string[,] arr)
        {
            chessboard_location = arr;
        }

        public bool FriendlyFree()
        {            
            string from_piece, to_piece;
            from_piece = PicBox_To_ChessLocation(prev);
            to_piece = PicBox_To_ChessLocation(next);
            if (to_piece == null)
                return true;
            else if (from_piece != null && to_piece != null)
            {
                if (from_piece.Contains("white") && to_piece.Contains("white"))
                {
                    return false;
                }
                else if (from_piece.Contains("black") && to_piece.Contains("black"))
                {
                    return false;
                }
                else
                    return true;
            }
            else
                return true;            
            //MessageBox.Show(from_piece + to_piece);
        }        

        public bool FromIsNotNull()
        {
            string from_piece = PicBox_To_ChessLocation(prev);
            if (from_piece == null)
                return false;
            else
                return true;
        }

        public string PicBox_To_ChessLocation(PictureBox p)// send either prev or next, returns chesspiece string
        {
            x = Convert.ToInt32(p.Name.Substring(6, 1));
            y = Convert.ToInt32(p.Name.Substring(7, 1));
            return chessboard_location[x, y];
        }

        public bool MovementSetDecider()
        {            
            string from_piece = PicBox_To_ChessLocation(prev);           
            PieceMovementSet pMS = new PieceMovementSet();
            pMS.Setter(from_piece, prev.Name.Substring(6, 2), next.Name.Substring(6, 2));
            return pMS.Decider();

        }

        public bool ObstacleCheckerDecider()
        {
            ObstacleChecker oC = new ObstacleChecker();
            oC.SetVariables(chessboard_location, prev, next);
            return oC.Decider();
        }
        int turn = 1;
        public bool PlayerTurnDecider()
        {               
            string piece = PicBox_To_ChessLocation(prev);            
            if ((turn % 2 == 1) && piece.Contains("white"))
            {
                turn++;
                return true;
            }                
            else if ((turn % 2 == 0) && piece.Contains("black"))
            {
                turn++;
                return true;
            }                
            else
                return false;
        }
        public int getTurn()
        {
            return turn;
        }
        public void UpdateChessBoard()
        {
            int x1, x2, y1, y2;
            x1 = Convert.ToInt32(prev.Name.Substring(6, 1));
            y1 = Convert.ToInt32(prev.Name.Substring(7, 1));
            x2 = Convert.ToInt32(next.Name.Substring(6, 1));
            y2 = Convert.ToInt32(next.Name.Substring(7, 1));
            chessboard_location[x2, y2] = chessboard_location[x1, y1];
            chessboard_location[x1, y1] = null;
        }   //Updates string-based chessboard
        public bool TargetIsNotKing()
        {
            if (PicBox_To_ChessLocation(next) == null)
                return true;
            else
            {
                if (PicBox_To_ChessLocation(next).Contains("king"))
                {
                    MessageBox.Show("You can't capture(eat :P) the king");
                    return false;
                }
                else
                    return true;
            }
        }
    }
}

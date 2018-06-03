using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class PieceMovementSet
    {
        string piece, start, end;
        int x1, y1, x2, y2, verticalNumber, horizontalNumber;

        public void Setter(string piece, string start, string end)
        {
            this.start = start;
            this.end = end;
            this.piece = piece;
            this.x1 = int.Parse(start.Substring(0, 1));
            this.y1 = int.Parse(start.Substring(1, 1));
            this.x2 = int.Parse(end.Substring(0, 1));
            this.y2 = int.Parse(end.Substring(1, 1));
            this.verticalNumber = Math.Abs(y2 - y1);
            this.horizontalNumber = Math.Abs(x2 - x1);
        }

        public bool Decider()
        {
            bool flag;
            if (piece.Contains("bishop"))
                flag = BishopCheck();
            else if (piece.Contains("king"))
                flag = KingCheck();
            else if (piece.Contains("knight"))
                flag = KnightCheck();
            else if (piece.Contains("pawn"))
                flag = PawnCheck();
            else if (piece.Contains("queen"))
                flag = QueenCheck();
            else if (piece.Contains("rook"))
                flag = RookCheck();
            else
                flag = false;
            return flag;
            /*if (flag)
                System.Windows.Forms.MessageBox.Show("Legal");
            else
                System.Windows.Forms.MessageBox.Show("Illegal");*/
        }
        public bool BishopCheck()
        {                        
            return (verticalNumber == horizontalNumber);
        }
        public bool KingCheck()
        {
            return ((verticalNumber <= 1) && (horizontalNumber <= 1) && (verticalNumber + horizontalNumber != 0));
        }

        public bool KnightCheck()
        {
            return (((verticalNumber == 2) && (horizontalNumber == 1)) || ((verticalNumber == 1) && (horizontalNumber == 2)));
        }

        public bool PawnCheck()
        {
            bool returnflag;
            int yDif = y2 - y1;
            int xDif = x2 - x1;
            if (piece.Contains("white"))
                returnflag = ((y1 == 1 && (yDif == 1 || yDif == 2)) || (yDif == 1) || (yDif == 1 && xDif == -1) || (yDif == 1 && xDif == 1));
            else
                returnflag = ((y1 == 6 && (yDif == -1 || yDif == -2)) || (yDif == -1) || (yDif == -1 && xDif == -1) || (yDif == -1 && xDif == 1));
            return returnflag;
            /*((verticalNumber + horizontalNumber == 2) ||
                ((verticalNumber == 1) && (horizontalNumber == 0)));*/
        }

        public bool QueenCheck()
        {
            return (RookCheck() || BishopCheck());
        }

        public bool RookCheck()
        {
            return (((verticalNumber > 0) && (verticalNumber <= 7) && horizontalNumber == 0) ||
                ((horizontalNumber > 0) && (horizontalNumber <= 7) && verticalNumber == 0));
        }

    }
}

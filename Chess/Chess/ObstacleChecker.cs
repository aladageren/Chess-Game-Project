using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Chess
{
    class ObstacleChecker
    {
        PictureBox prev = new PictureBox();
        PictureBox next = new PictureBox();
        string[,] chessboard_location = new string[8, 8];        
        int xPrev, xNext, yPrev, yNext, xDifference, yDifference;

        public void SetVariables(string[,] arr, PictureBox prev, PictureBox next)
        {
            this.chessboard_location = arr;
            this.prev = prev;
            this.next = next;
            xPrev = int.Parse(prev.Name.Substring(6, 1));
            yPrev = int.Parse(prev.Name.Substring(7, 1));
            xNext = int.Parse(next.Name.Substring(6, 1));
            yNext = int.Parse(next.Name.Substring(7, 1));
            xDifference = xNext - xPrev;
            yDifference = yNext - yPrev;
        }
        public bool Decider()
        {
            bool diagonal = Math.Abs(xDifference) == Math.Abs(yDifference);
            bool movingHorizontal = (xDifference != 0) && (yDifference == 0);
            bool movingVertical = (xDifference == 0) && (yDifference != 0);
            if (!(diagonal || movingHorizontal || movingVertical))
                return true;
            int startX, endX, startY, endY, dx, dy;
            startX = xPrev;
            endX = xNext;
            startY = yPrev;
            endY = yNext;
            while ((startX != endX) || (startY != endY))
            {
                try
                {
                    dx = (endX - startX) / Math.Abs(endX - startX);
                }
                catch (ArithmeticException e)
                {
                    dx = 0;
                }
                try
                {
                    dy = (endY - startY) / Math.Abs(endY - startY);
                }
                catch (ArithmeticException e)
                {
                    dy = 0;
                }
                startX += dx;
                startY += dy;
                bool areWeThere = (startX == endX) && (startY == endY);
                string piece = chessboard_location[startX, startY];
                bool pieceExists = piece != null;
                if (!areWeThere && pieceExists) { return false; }
            }
            return true;
        }
    }
}

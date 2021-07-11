using System.Security.Permissions;

namespace TicTac
{
    public class Board
    {
        private BoardObject[,] m_GameBoard;
        private readonly int r_BoardSize; 
        public Board(int i_size)
        {   
            r_BoardSize = i_size;
            m_GameBoard = new BoardObject[i_size, i_size];
        }

        public void initBoard()
        {
            foreach (BoardObject current in m_GameBoard)
            {
                current.Sign = ePlayerSign.None;
            }
        }
        public int Size
        {
            get { return r_BoardSize; }
        }
        public bool isSpotAvialable(int i_Row, int i_Col)
        {
            bool flag = true;
            if (i_Row - 1 < 0 || i_Row - 1 >= r_BoardSize)
            {
                flag = false;
            }
            else if (i_Col - 1 < 0 || i_Col - 1 >= r_BoardSize)
            {
                flag = false;
            }
            else if (m_GameBoard[i_Row,i_Col].Sign != ePlayerSign.None)
            {
                flag = false;
            }
            return flag;
        }

     }
}

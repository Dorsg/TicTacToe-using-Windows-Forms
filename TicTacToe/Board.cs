using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Board
    {
        
        public  readonly char X = (char)88;
        public  readonly char O = (char)79;

        private char[,] m_GameBoard;
        private readonly int r_BoardSize; 
        public Board(int i_size)
        {
            r_BoardSize = i_size;
            m_GameBoard = new char[i_size, i_size];

            Init();
        }

        public void Init()
        {
            char space = (char)32;

            for (int i = 0; i < r_BoardSize; i++)
            {
                for (int j = 0; j < r_BoardSize; j++)
                {
                    m_GameBoard.SetValue(space, i, j);
                }
            }
           
     
        }
        public char this[int i_Idx1, int i_Idx2] 
        {
            get
            { return m_GameBoard[i_Idx1 - 1, i_Idx2 - 1]; } // throw exception
            set { m_GameBoard.SetValue(value, i_Idx1 - 1, i_Idx2 - 1); }
        }

        public int Size
        {
            get { return r_BoardSize; }
        }

        public  bool isSpotAvialable(int i_row, int i_col) // should throw exceptions in setter !!
        {
            bool flag = true;
            if (i_row - 1 < 0 || i_row - 1 >= r_BoardSize) //wrong logic
            {
                flag = false;
            }
            else if (i_col - 1 < 0 || i_col - 1 >= r_BoardSize)
            {
                flag = false;
            }
            else if (this[i_row, i_col] == X || this[i_row, i_col] == O)
            {
                flag = false;
            }
            return flag;
        }
    }


}

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
        public  Board(int i_size)
        {
            r_BoardSize = i_size;
            m_GameBoard = new char[i_size, i_size];
            char space = (char) 32;
            int colCounter = 0;

            foreach (int rowCount in m_GameBoard)
            {
                m_GameBoard.SetValue(space, rowCount,colCounter);
                if (rowCount % i_size == 0 && rowCount > 0)
                {
                    colCounter++;
                }
            }
        }
        public char this[int i_Idx1, int i_Idx2] 
        {
            get
            { return m_GameBoard[i_Idx1 - 1, i_Idx2 - 1]; } // throw exception
            set { m_GameBoard.SetValue(value, i_Idx1 - 1, i_Idx2 - 1); }
        }
        public  void PrintBorad()
        {
            int columCounter, rowsCounter, valuesCounter;
            rowsCounter = columCounter = valuesCounter = 0;
            valuesCounter = 1;
            for (; rowsCounter <= r_BoardSize; ++rowsCounter)
            {
               Console.Write("-");
                for (columCounter= 0; columCounter <= r_BoardSize; ++columCounter)
                {
                    Console.Write("----");
                }

                Console.WriteLine("");
                Console.Write("|");
                for (columCounter = 0; columCounter <= r_BoardSize; columCounter++)
                {
                    if (columCounter == 0 && rowsCounter > 0)
                    {
                        Console.Write( " "+ valuesCounter +" |");
                        valuesCounter++;
                    }
                    else if (rowsCounter == 0)
                    {
                        Console.Write(" " + columCounter + " |");
                    }
                    else
                    {
                        Console.Write(" " + this[rowsCounter,columCounter] + " |");
                    }
                }
                Console.WriteLine("");
            }
            for (rowsCounter = 0; rowsCounter < r_BoardSize; ++rowsCounter)
            {
                Console.Write("-----");
            }
            Console.WriteLine();
        }

        public  bool isSpotAvialable(int i_row, int i_col) // should throw exceptions in setter !!
        {
            bool flag = true;
            if (i_row - 1 < 0 || i_row - 1 > r_BoardSize) //wrong logic
            {
                flag = false;
            }
            else if (i_col - 1 < 0 || i_col - 1 > r_BoardSize)
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

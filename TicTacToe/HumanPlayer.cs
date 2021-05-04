using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class HumanPlayer
    {
        private int m_WinsCounter;
        private char m_playerSign;
        private string m_Name;
        public HumanPlayer(string i_Name,char i_Sign)
        {
            m_WinsCounter = 0;
            m_playerSign = i_Sign;
            m_Name = i_Name;
        }

        public int Score
        {
            get { return m_WinsCounter; }
            set { m_WinsCounter= value; }
        }

        public char Sign 
        {
            get { return m_playerSign; }
        }
        public string Name
        {
            get { return m_Name; }
        }
        public void getPlayerChoose(ref int i_Row, ref int i_Col, ref bool i_QuitFlag)
        {
            bool trigger = false;
            int row, col;
            char key1, key2;
            while (!trigger)
            {
                Console.WriteLine(m_Name + "  Please choose your next move (only available spots is allowed)");
                Console.WriteLine("Row : ");
                key1 = char.Parse(Console.ReadLine());
                if (!key1.Equals("q") && !key1.Equals("Q"))
                {
                    Console.WriteLine("Col : ");
                    key2 = char.Parse(Console.ReadLine());
                    if (!key2.Equals("q") && !key2.Equals("Q"))
                    {
                        i_Row = int.Parse(key1.ToString());
                        i_Col = int.Parse(key2.ToString());
                        trigger = true;
                    }
                    else
                    {
                        i_QuitFlag = true;
                    }
                }
                else
                {
                    i_QuitFlag = true;
                }
            }
        }
    }
}

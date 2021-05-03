using System;
using System.Collections.Generic;
using System.Linq;
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
        
       
    }
}

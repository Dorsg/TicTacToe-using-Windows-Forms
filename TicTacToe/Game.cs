using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Game
    {
        public const int k_TwoPlayerGame = 1;

        private Board m_Board;
        private Player m_PlayerOne;
        private Player m_PlayerTwo;
        private bool m_TwoPlayerGame = false;
        private bool m_EndGame = false;

        public Game(int i_BoardSize, int i_GameType)
        {
            m_Board = new Board(i_BoardSize);

            if (i_GameType == k_TwoPlayerGame)
            {
                m_TwoPlayerGame = true;
            }

            InitPlayers();
        }

        public void InitPlayers()
        {

            string playerTwoName;
            string playerOneName = Gui.GetPlayerName();

            if (m_TwoPlayerGame)
            {
                playerTwoName = Gui.GetPlayerName();
            }
            else
            {
                playerTwoName = "Computer";
            }

            m_PlayerOne = new Player(playerOneName, 'X');
            m_PlayerTwo = new Player(playerTwoName, 'O');
        }


        public void playSingelGame() // should return bool end of game 
        {
            int maxMatches = m_Board.Size * m_Board.Size;
            int turnsCounter = 0;

            Gui.PrintBoard(m_Board.Size, m_Board);

            while (turnsCounter < maxMatches && !m_EndGame) //flag 
            {
                if (turnsCounter % 2 == 0)
                {
                    PlayMove(m_PlayerOne, ref m_EndGame);
                }
                else
                {
                    if (m_TwoPlayerGame == true)
                    {
                        PlayMove(m_PlayerTwo, ref m_EndGame);
                    }
                    else
                    {
                        ComputerNextMove(m_PlayerTwo); 
                    }
                }

                Gui.PrintBoard(m_Board.Size, m_Board);
                turnsCounter++;
            }
        }

        public void PlayMove(Player i_Player, ref bool quitFlag)
        {
            bool inputIsValid = false;

            int row, col;
            row = col = 0;

            while (!inputIsValid)
            {
                getPlayerChoose(i_Player,ref row, ref col, ref quitFlag);

                if (!quitFlag && m_Board.isSpotAvialable(row, col))
                {
                    // still not working as well 
                    m_Board[row, col] = i_Player.Sign;
                    inputIsValid = true; // to add - checking winning conditions
                }
                else
                {
                    if (!quitFlag) // get out 
                    {
                        Gui.TryAgain();
                    }
                    else
                    {
                        Gui.Quit();
                    }
                }

            }
        }
        public void getPlayerChoose(Player i_Player, ref int i_Row, ref int i_Col, ref bool i_QuitFlag)
        {
            bool keepAsking = true;
            char cRow, cCol;

            Gui.NextMoveInst(i_Player.Name);

            while (keepAsking)
            {
                cRow = Gui.AskForRow();

                if (!cRow.Equals('q') && !cRow.Equals('Q'))
                {
                    cCol = Gui.AskForCol();

                    if (!cCol.Equals('q') && !cCol.Equals('Q'))
                    {
                        i_Row = int.Parse(cRow.ToString());
                        i_Col = int.Parse(cCol.ToString());
                        keepAsking = false;
                    }
                    else
                    {
                        keepAsking = false;
                        i_QuitFlag = true;
                    }
                }
                else
                {
                    keepAsking = false;
                    i_QuitFlag = true;
                }
            }
        }

        public void ComputerNextMove(Player i_Player)
        {
            bool trigger = false;
            int row, col;

            Random r = new Random();
            Random c = new Random();

            while (!trigger)
            {
                row = r.Next(1, m_Board.Size + 1);
                col = c.Next(1, m_Board.Size + 1);

                if (m_Board.isSpotAvialable(row, col))
                {
                    m_Board[row, col] = i_Player.Sign;
                    trigger = true; 
                }
            }
        }

        public bool CheckWinner(Board Board)
        {
            bool win = false;

            if (CheckWinnerCols(Board) || CheckWinnerRow(Board) 
                                       || CheckWinnerDiagDec(Board) || CheckWinnerDiagInc(Board))
            {
                win = true;
            }

            return win;

        }
        //public bool CheckWinnerCols(Board Board)
        //{
            
        //    for (int i = 0; i < Board.Size; i++)
        //    {
        //        foreach (var VARIABLE in COLLECTION)
        //        {
                
        //        }

        //    }

        //}
        //public bool CheckWinnerRow(Board Board)
        //{


        //}
        //public bool CheckWinnerDiagDec(Board Board)
        //{


        //}
        //public bool CheckWinnerDiagInc(Board Board)
        //{


        //}

        public bool IsOn()
        {
            return !m_EndGame;

        }

        public Player Player1
        {
            get { return m_PlayerOne; }
        }

        public Player Player2
        {
            get { return m_PlayerTwo; }
        }
    }
   
}

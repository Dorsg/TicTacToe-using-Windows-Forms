﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime;

namespace TicTacToe
{
    public class Game
    {
        public const int k_TwoPlayerGame = 1;

        private Board m_Board;
        private Player m_PlayerOne;
        private Player m_PlayerTwo;
        private bool m_TwoPlayerGame = false;
        private bool m_EndSessionOfGames = false;

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
            m_PlayerOne = new Player(playerOneName, (char)88);
            m_PlayerTwo = new Player(playerTwoName, (char)79);
        }

        public void SessionOfGames()
        {
            while (!m_EndSessionOfGames)
            {
                int rand = RandTheFirstPlayer();
                if (rand == 1) //random the player who starts
                {
                    playSingelGame(m_PlayerOne, m_PlayerTwo);
                }
                else
                {
                    playSingelGame(m_PlayerTwo, m_PlayerOne);
                }
                Gui.NewGame(Player1.Name, Player1.Score, 
                    Player2.Name, Player2.Score);

                m_Board.Init();
            }

        }
        public void playSingelGame(Player i_First, Player i_Second) // should return bool end of game 
        {
            int maxTurns = m_Board.Size * m_Board.Size;
            int turnsCounter = 0;
            bool endOfGame = false;

            Gui.PrintBoard(m_Board.Size, m_Board);
            
            while (turnsCounter < maxTurns && !endOfGame && !m_EndSessionOfGames) //flag 
            {
                if (turnsCounter % 2 == 0)
                {
                    if (i_First.Name != "Computer")
                    {
                        PlayMove(i_First, ref endOfGame);
                    }
                    else
                    {
                        ComputerNextMove(i_First);
                    }
                }
                else
                {
                    if (i_Second.Name != "Computer")
                    {
                        PlayMove(i_Second, ref endOfGame);
                    }
                    else
                    {
                        ComputerNextMove(i_Second); 
                    }
                }

                if (CheckWinner())
                {
                    endOfGame = true;
                }

                Gui.PrintBoard(m_Board.Size, m_Board);
                turnsCounter++;
            }
        }

        public int RandTheFirstPlayer()
        {
            return new Random().Next(1,3);
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
                        m_EndSessionOfGames = true;
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
                        if (char.IsDigit(cRow) && char.IsDigit(cCol))
                        {
                            i_Row = int.Parse(cRow.ToString());
                            i_Col = int.Parse(cCol.ToString());
                            keepAsking = false;
                        }
                        else { Gui.TryAgain();}
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
        public bool CheckWinner()
        {
            bool win = false;

            if (CheckWinnerCols(Player1.Sign) || CheckWinnerRow(Player1.Sign) 
                                                    || CheckWinnerDiagDec(Player1.Sign))// || CheckWinnerDiagInc(Player1.Sign))
            {
                Player1.Score++;
                win = true;
            }
            if (CheckWinnerCols(Player2.Sign) || CheckWinnerRow(Player2.Sign)
                                              || CheckWinnerDiagDec(Player2.Sign))// || CheckWinnerDiagInc(Player2.Sign))
            {
                Player2.Score++;
                win = true;
            }
            return win;

        }
        public bool CheckWinnerCols(char sign)
        {
            int counter = 0;
            int index = 0;
            bool res = false;
            for (int i = 1; i <= m_Board.Size; i++)
            {
                counter = 0;

                for (int j = 1; j <= m_Board.Size; j++)
                {
                    if (m_Board[i, j] == sign)
                    {
                        counter++;
                    }
                    else
                    { counter = 0; }
                }
                if (counter == m_Board.Size)
                {
                    res = true;

                }
            }
            return res;
        }
        public bool CheckWinnerRow(char sign)
        {
            int counter = 0;
            int index = 0;
            bool res = false;
            for (int i = 1; i <= m_Board.Size; i++)
            {

                for (int j = 1; j <= m_Board.Size; j++)
                {
                    if (m_Board[j, i] == sign)
                    {
                        counter++;
                    }
                    else
                    { counter = 0; }
                }
                if (counter == m_Board.Size)
                {
                    res = true;
                }
            }
            return res;
        }
        public bool CheckWinnerDiagDec(char sign)
        {
            int counter = 0;
            int index = 0;
            bool res = false;
            for (int i = 1; i <= m_Board.Size; i++)
            {
                counter = 0;

                for (int j = 1; j <= m_Board.Size; j++)
                {
                    if (i == j && m_Board[j, i] == sign)
                    {
                        counter++;
                    }
                    else
                    { counter = 0; }
                }

                if (counter == m_Board.Size)
                {
                    res = true;

                }
            }
            return res;
        }
        //public bool CheckWinnerIncInc(char sign)
        //{
        //    int rowC = m_Board.Size;
        //    int delta = 1; 

        //    for (int i = 1; i <= m_Board.Size; i++)
        //    {

        //        for (int j = 1; j <= m_Board.Size; j++)
        //        {
        //            if (rowC == m_Board.Size - delta                    m_Board[j, i] == sign)
        //            {
        //                counter++;
        //            }
        //        }

        //        if (counter == m_Board.Size)
        //        {
        //            return true;
        //        }
        //    }

        //    return false;
        //} // TODO

        public void ComputerNextMove(Player i_Player)
        {
            bool trigger = false;
            int row, col;
            row = col = 0;
            Random r = new Random();
            Random c = new Random();
         
            while (!trigger)
            {
                row = r.Next( m_Board.Size + 1);
                col = c.Next(m_Board.Size + 1);
                row = r.Next(m_Board.Size + 1);
                col = c.Next(m_Board.Size + 1);
                if (m_Board.isSpotAvialable(row, col))
                {
                    m_Board[row, col] = i_Player.Sign;
                    trigger = true; 
                }
            }
        }

        public bool IsOn()
        {
            return !m_EndSessionOfGames;
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
using System;

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

        private void InitPlayers()
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

        public void SessionOfGames(ref bool r_QuitFlag)
        {
            while (!m_EndSessionOfGames && !r_QuitFlag)
            {
                int rand = RandTheFirstPlayer();
                if (rand == 1) //random the player who starts
                {
                    playSingelGame(m_PlayerOne, m_PlayerTwo, ref r_QuitFlag);
                }
                else
                {
                    playSingelGame(m_PlayerTwo, m_PlayerOne, ref r_QuitFlag);
                }
                Gui.NewGame(Player1.Name, Player1.Score, 
                    Player2.Name, Player2.Score);
                m_Board.Init();
            }
        }
        private void playSingelGame(Player i_First, Player i_Second, ref bool r_QuitFlag) // should return bool end of game 
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
                        r_QuitFlag = endOfGame;
                    }
                    else
                    {
                        ComputerNextMove(i_First);
                    }
                    if (CheckWinner(i_First))
                    {
                        i_Second.Score++;
                        endOfGame = true;
                    }
                }
                else
                {
                    if (i_Second.Name != "Computer")
                    {
                        PlayMove(i_Second, ref endOfGame);
                        r_QuitFlag = endOfGame;
                    }
                    else
                    {
                        ComputerNextMove(i_Second); 
                    }
                    if (CheckWinner(i_Second))
                    {
                        i_First.Score++;
                        endOfGame = true;
                    }
                }
                Gui.PrintBoard(m_Board.Size, m_Board);
                turnsCounter++;
            }
        }
        private int RandTheFirstPlayer()
        {
            return new Random().Next(1,3);
        }
        public void PlayMove(Player i_Player, ref bool quitFlag)
        {
            bool inputIsValid = false;

            int row, col;
            row = col = 0;

            while (!inputIsValid && !m_EndSessionOfGames)
            {
                getPlayerChoose(i_Player,ref row, ref col, ref quitFlag);

                if (!quitFlag && m_Board.isSpotAvialable(row, col))
                {
                    m_Board[row, col] = i_Player.Sign;
                    inputIsValid = true; 
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
                    }
                }
            }
        }
        private void getPlayerChoose(Player i_Player, ref int i_Row, ref int i_Col, ref bool i_QuitFlag)
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
        private bool CheckWinner(Player i_Player)
        {
            bool lose = false;

            if (CheckWinnerCols(i_Player.Sign) || CheckWinnerRow(i_Player.Sign) 
                    || CheckWinnerDiagDec(i_Player.Sign) || CheckWinnerDiagInc(i_Player.Sign))
            {
                lose = true;
            }
            return lose; // its a lose not a win
        }
        private bool CheckWinnerCols(char sign)
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
        private bool CheckWinnerRow(char sign)
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
        private bool CheckWinnerDiagDec(char sign)
        {
            int counter = 0;
            int index = 1;
            bool res = false;
            for (; index <= m_Board.Size; ++index)
            {
                if (m_Board[index, index] == sign)
                {
                    counter++;
                }
            }
            if (counter == m_Board.Size)
            {
                res = true;
            }
            return res;
        }
        private bool CheckWinnerDiagInc(char sign)
        {
            int rowC = 1;
            int colC = m_Board.Size;
            int counter  = 0;
            bool res = false;
            for (; rowC <= m_Board.Size; rowC++, colC--)
            {
                if (m_Board[rowC, colC] == sign)
                {
                    counter++;
                }
            }
            if (counter == m_Board.Size)
            {
                res = true;
            }
            return res;
        }
        private void ComputerNextMove(Player i_Player)
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

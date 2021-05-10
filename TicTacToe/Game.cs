
namespace TicTacToe
{
    using System;
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
            initPlayers();
        }
        public Player Player1
        {
            get { return m_PlayerOne; }
        }
        public Player Player2
        {
            get { return m_PlayerTwo; }
        }

        private void initPlayers()
        {
            string playerTwoName;
            string playerOneName = Gui.GetPlayerName();

            if (m_TwoPlayerGame == true)
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
        private void playSingelGame(Player i_FirstPlayer, Player i_SecondPlayer) // should return bool end of game 
        {
            int maxTurns = m_Board.Size * m_Board.Size;
            int turnsCounter = 0;
            bool endOfGame = false;

            Gui.PrintBoard(m_Board.Size, m_Board);
            
            while (turnsCounter < maxTurns && (endOfGame == false) && (m_EndSessionOfGames == false)) //flag 
            {
                if (turnsCounter % 2 == 0)
                {
                    if (i_FirstPlayer.Name != "Computer")
                    {
                        playMove(i_FirstPlayer);
                    }
                    else
                    {
                        computerNextMove(i_FirstPlayer);
                    }
                    if (checkWinner(i_FirstPlayer))
                    {
                        i_SecondPlayer.Score++;
                        endOfGame = true;
                    }
                }
                else
                {
                    if (i_SecondPlayer.Name != "Computer")
                    {
                        playMove(i_SecondPlayer);
                    }
                    else
                    {
                        computerNextMove(i_SecondPlayer); 
                    }
                    if (checkWinner(i_SecondPlayer))
                    {
                        i_FirstPlayer.Score++;
                        endOfGame = true;
                    }
                }
                Gui.PrintBoard(m_Board.Size, m_Board);
                turnsCounter++;
            }
        }
        private int randTheFirstPlayer()
        {
            return new Random().Next(1,3);
        }
        private void playMove(Player i_Player)
        {
            bool inputIsValid = false;

            int row, col;
            row = col = 0;

            while (!inputIsValid && !m_EndSessionOfGames)
            {
                getPlayerChoose(i_Player,ref row, ref col);

                if (m_Board.isSpotAvialable(row, col))
                {
                    m_Board[row, col] = i_Player.Sign;
                    inputIsValid = true; 
                }
            }
        }
        private void getPlayerChoose(Player i_Player, ref int i_Row, ref int i_Col)
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
                        m_EndSessionOfGames = true;
                    }
                }
                else
                {
                    keepAsking = false;
                    m_EndSessionOfGames = true;
                }
            }
        }
        private bool checkWinner(Player i_Player)
        {
            bool lose = false;

            if (checkWinnerCols(i_Player.Sign) || checkWinnerRow(i_Player.Sign) 
                    || checkWinnerDiagDec(i_Player.Sign) || checkWinnerDiagInc(i_Player.Sign))
            {
                lose = true;
            }
            return lose; // its a lose not a win
        }
        private bool checkWinnerCols(char sign)
        {
            int counter = 0;
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
        private bool checkWinnerRow(char sign)
        {
            int counter = 0;

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
        private bool checkWinnerDiagDec(char sign)
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
        private bool checkWinnerDiagInc(char sign)
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
        private void computerNextMove(Player i_Player)
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
        public void SessionOfGames()
        {
            while (m_EndSessionOfGames == false)
            {
                int rand = randTheFirstPlayer();
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
                m_Board.InitBoard();
            }
        }
    }
   
}

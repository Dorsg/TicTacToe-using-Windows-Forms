
namespace TicTac
{
     using System;
     public class Game
     {
          private readonly eGameType m_GameType;
          private ePlayerSign m_NextPlayer;
          private readonly BoardObject[,] m_Board;
          private readonly int m_Size;
          private int m_GameCounter = 0;

          public Game(int i_BoardSize, eGameType i_GameType)
          {
               m_NextPlayer = ePlayerSign.Player1;
               m_Board = new BoardObject[i_BoardSize, i_BoardSize];
               m_Size = i_BoardSize;
               m_GameType = i_GameType;
          }

          public void initBoard()
          {
              foreach (BoardObject current in m_Board)
              {
                  current.Sign = ePlayerSign.None;
              }

              m_GameCounter = 0;
          }
        public BoardObject GetBoardObj(int i_Row, int i_Col)
          {
               var boardObj = m_Board[i_Row, i_Col];
               if(boardObj == null)
               {
                    boardObj = new BoardObject(i_Row, i_Col);
                    m_Board[i_Row, i_Col] = boardObj;
               }
               return boardObj;
          }
          public void playMove(int i_Row, int i_Col)
          {
               m_Board[i_Row, i_Col].Sign = m_NextPlayer;
               m_Board[i_Row, i_Col].OnCellUpdate(EventArgs.Empty);
               m_GameCounter++;
          }
          public void SetNextPlayer()
          {
               if(m_NextPlayer == ePlayerSign.Player1)
               {
                    m_NextPlayer = ePlayerSign.Player2;
               }
               else
               {
                    m_NextPlayer = ePlayerSign.Player1;
               }
          }
          public void computerNextMove()
          {
               Random rnd = new Random();
               int row = rnd.Next(m_Size);
               int col = rnd.Next(m_Size);

               while (!isSpotAvialable(row, col))
               {
                    row = rnd.Next(m_Size);
                    col = rnd.Next(m_Size);
               }

               m_Board[row, col].Sign = ePlayerSign.Player2;
               m_Board[row, col].OnCellUpdate(EventArgs.Empty);
               m_GameCounter++;
        }
          public bool isSpotAvialable(int i_Row, int i_Col)
          {
               bool isAvailable = false;

               if (m_Board[i_Row, i_Col].Sign == ePlayerSign.None)
               {
                    isAvailable = true;
               }
               return isAvailable;
          }
          public bool CheckWinner(out ePlayerSign o_LastPlayed, out bool o_TieFlag)
          {
               o_LastPlayed = getLastPlayer();
               bool therIsAWin = false;
               o_TieFlag = false;
              
               if (CheckWinnerCols(o_LastPlayed) || CheckWinnerRow(o_LastPlayed)
                                                 || CheckWinnerDiagDec(o_LastPlayed) || CheckWinnerDiagInc(o_LastPlayed))
               {
                    therIsAWin = true;
               }
               if (m_GameCounter == m_Size * m_Size &&  !therIsAWin)
               {
                   o_TieFlag = true;
               }
            return therIsAWin; 
          }
          private bool CheckWinnerCols(ePlayerSign i_PlayerSign)
          {
               int counter;
               bool res = false;
               for (int i = 0; i < m_Size; i++)
               {
                    counter = 0;

                    for (int j = 0; j < m_Size; j++)
                    {
                         if (m_Board[i, j].Sign == i_PlayerSign)
                         {
                              counter++;
                         }
                         else
                         { counter = 0; }
                    }
                    if (counter == m_Size)
                    {
                         res = true;
                    }
               }
               return res;
          }
          private bool CheckWinnerRow(ePlayerSign i_PlayerSign)
          {
               int counter = 0;

               bool res = false;
               for (int i = 0; i < m_Size; i++)
               {
                    for (int j = 0; j < m_Size; j++)
                    {
                         if (m_Board[j, i].Sign == i_PlayerSign)
                         {
                              counter++;
                         }
                         else
                         { counter = 0; }
                    }
                    if (counter == m_Size)
                    {
                         res = true;
                    }
               }
               return res;
          }
          private bool CheckWinnerDiagDec(ePlayerSign i_PlayerSign)
          {
               int counter = 0;
               int index = 0;
               bool res = false;
               for (; index < m_Size; ++index)
               {
                    if (m_Board[index, index].Sign == i_PlayerSign)
                    {
                         counter++;
                    }
               }
               if (counter == m_Size)
               {
                    res = true;
               }
               return res;
          }
          private bool CheckWinnerDiagInc(ePlayerSign i_PlayerSign)
          {
               int rowC = 0;
               int colC = m_Size-1;
               int counter = 0;
               bool res = false;
               for (; rowC < m_Size; rowC++, colC--)
               {
                    if (m_Board[rowC, colC].Sign == i_PlayerSign)
                    {
                         counter++;
                    }
               }
               if (counter == m_Size)
               {
                    res = true;
               }
               return res;
          }
          private ePlayerSign getLastPlayer()
          {
               if(m_NextPlayer == ePlayerSign.Player1)
               {
                    return ePlayerSign.Player2;
               }
               else
               {
                    return ePlayerSign.Player1;
               }
          }

          public eGameType GameType
          {
              get { return m_GameType; }
          }

    }

}

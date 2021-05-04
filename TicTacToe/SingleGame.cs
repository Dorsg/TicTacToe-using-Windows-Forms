using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class SingleGame
    {
        private Board m_game;
        private Player m_PlayerOne;
        private Player m_PlayerTwo;
        private bool m_EndOfGame = false;
        private bool m_TwoPlayerGame;

        public SingleGame(string i_PlayerOneName, string i_PlayerTwoName, int i_BoardSize, bool i_GameType)
        {
            m_game = new Board(i_BoardSize);
            m_PlayerOne = new Player(i_PlayerOneName, (char) 88);
            m_PlayerTwo = new Player(i_PlayerTwoName, (char) 79);
            m_TwoPlayerGame = i_GameType;
            playGame();
        }

        private void playGame() // should return bool end of game 
        {
            int count = m_game.Size * m_game.Size;
            m_game.PrintBorad();

            while (count > 0 && !m_EndOfGame) //flag 
            {
                if (count % 2 == 0)
                {
                    PlayerNextMove(m_PlayerOne, ref m_EndOfGame);
                    //check if lose
                    //if so update score
                }
                else
                {
                    if (m_TwoPlayerGame == true)
                    {
                        PlayerNextMove(m_PlayerTwo, ref m_EndOfGame);
                        //check if lose
                        //if so update score
                    }
                    else
                    {
                        ComputerNextMove(m_PlayerTwo); // not workking as well
                        //check if lose
                        //if so update score
                    }
                    // check if lose
                }
                // if count == 0  its a tie
                // else someone won 

                Ex02.ConsoleUtils.Screen.Clear();
                m_game.PrintBorad(); // move it from here somehow
                count--;
            }
        }

        public void PlayerNextMove(Player i_Player, ref bool quitFlag)
        {
            bool trigger = false;

            int row, col;
            row = col = 0;
            while (!trigger)
            {
                getPlayerChoose(i_Player,ref row, ref col, ref quitFlag);

                if (!quitFlag && m_game.isSpotAvialable(row, col))
                {
                    // still not working as well 
                    m_game[row, col] = i_Player.Sign;
                    trigger = true; // to add - checking winning conditions
                }
                else
                {
                    if (!quitFlag) // get out 
                    {
                        Console.WriteLine("Wrong choose, please try again");
                    }
                    else
                    {
                        Console.WriteLine("you have chose to quit ");
                    }
                }

            }
        }
        public void getPlayerChoose(Player i_Player, ref int i_Row, ref int i_Col, ref bool i_QuitFlag)
        {
            bool trigger = false;
            int row, col;
            char key1, key2;
            while (!trigger)
            {
                Console.WriteLine(i_Player.Name + "  Please choose your next move (only available spots is allowed)");
                Console.WriteLine("Row : ");
                key1 = char.Parse(Console.ReadLine());
                if (!key1.Equals('q') && !key1.Equals('Q'))
                {
                    Console.WriteLine("Col : ");
                    key2 = char.Parse(Console.ReadLine());
                    if (!key2.Equals('q') && !key2.Equals('Q'))
                    {
                        i_Row = int.Parse(key1.ToString());
                        i_Col = int.Parse(key2.ToString());
                        trigger = true;
                    }
                    else
                    {
                        trigger = true;
                        i_QuitFlag = true;
                    }
                }
                else
                {
                    trigger = true;
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
                row = r.Next(0, m_game.Size);
                col = c.Next(0, m_game.Size);
                if (m_game.isSpotAvialable(row, col))
                {
                    m_game[row, col] = i_Player.Sign;
                    trigger = true; 
                }
            }
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

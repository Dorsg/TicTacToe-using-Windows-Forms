using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class SingleGame
    {
        private Board m_game;
        private Player m_PlayerOne;
        private Player m_PlayerTwo;
        public SingleGame(string i_PlayerOneName, string i_PlayerTwoName, int i_BoardSize)
        { 
            m_game = new Board(i_BoardSize);
            m_PlayerOne = new Player(i_PlayerOneName, (char)88);
            m_PlayerTwo = new Player(i_PlayerTwoName, (char)79);

            playGame();
        }
        private void playGame()
        {
            int count = 5;
            bool quitFlag = false;
            m_game.PrintBorad();

            while (count > 0  && !quitFlag) //flag 
            {
                if (count % 2 == 0)
                {
                    PlayerNextMove(m_PlayerOne,ref quitFlag);
                    //check if lose
                }
                else
                {
                    PlayerNextMove(m_PlayerTwo, ref quitFlag);
                    // check if lose
                }
                Ex02.ConsoleUtils.Screen.Clear();
                //score ++
                m_game.PrintBorad();
                count--;
            }
            Console.WriteLine("Player One Score : "+ m_PlayerOne.Score);
            Console.WriteLine("Player Two Score : " + m_PlayerTwo.Score);
        }
        public void PlayerNextMove(Player i_Player, ref bool quitFlag)
        {
            bool trigger = false;
           
            int row, col;
            row = col = 0;
            while (!trigger)
            {
                i_Player.getPlayerChoose(ref row, ref col, ref quitFlag);
               
                if (!quitFlag && m_game.isSpotAvialable(row, col))
                {
                     // still not working as well 
                     m_game[row, col] = i_Player.Sign; 
                     trigger = true; // to add - checking winning conditions
                }
                else
                {
                    if (!quitFlag)
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
    }
}

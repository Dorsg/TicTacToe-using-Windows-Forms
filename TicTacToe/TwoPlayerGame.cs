using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class TwoPlayerGame
    {
        private Board m_game;
        private HumanPlayer m_PlayerOne; // to add - string name 
        private HumanPlayer m_PlayerTwo;
        public TwoPlayerGame(string i_PlayerOneName, string i_PlayerTwoName, int i_BoardSize)
        { 
            m_game = new Board(i_BoardSize);
            m_PlayerOne = new HumanPlayer(i_PlayerOneName, (char)88);
            m_PlayerTwo = new HumanPlayer(i_PlayerTwoName, (char)79);

            playGame();
        }
        private void playGame()
        {
            int count = 5;

            m_game.PrintBorad();

            while (count > 0)
            {
                if (count % 2 == 0)
                {
                    getPlayerChoose(m_PlayerOne);
                }
                else
                {
                    getPlayerChoose(m_PlayerTwo);
                }
                Ex02.ConsoleUtils.Screen.Clear();
                m_game.PrintBorad();
                count--;
            }
            Console.WriteLine("Player One Score : "+ m_PlayerOne.Score);
            Console.WriteLine("Player Two Score : " + m_PlayerTwo.Score);
        }
        public void getPlayerChoose(HumanPlayer i_Player)
        {
            bool trigger = false;
            int row, col;
            while (!trigger)
            {
                Console.WriteLine(i_Player.Name + "  Please choose your next move (only available spots is allowed)");
               // int to = int.Parse(Console.ReadKey().ToString());
                row = int.Parse(Console.ReadLine());
                col = int.Parse(Console.ReadLine()); // NOT WORKING WITH WHITESPACES
                if (m_game.isSpotAvialable(row, col))
                {
                     // still not working as well 
                     m_game[row, col] = i_Player.Sign; 
                     trigger = true; // to add - checking winning conditions
                }
                else
                {
                    Console.WriteLine("Wrong choose, please try again");
                }
            }
        }
    }
}

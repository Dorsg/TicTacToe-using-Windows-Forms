using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class MenuProgram
    {
        public const bool k_HumansOption = true;
        public const bool k_ComputerOption = false;
        public static void Main()
        {
            Console.WriteLine("Welcome to TicTacToe game by Aviv and Dor :");
            int sizeOfBoard = GetBoardSize();
            bool gameType = GetGameType();

            if (gameType == k_HumansOption) // flag gaming 
            {
                string playerOneName = GetPlayerName();
                string playerTwoName = GetPlayerName();

                Ex02.ConsoleUtils.Screen.Clear();
                new SingleGame(playerOneName, playerTwoName, sizeOfBoard, gameType);
            }
            else
            {
                string playerOneName = GetPlayerName();
                new SingleGame(playerOneName, "Computer", sizeOfBoard, gameType);
            }
          //  Console.WriteLine("Player One Score : " + m_PlayerOne.Score);
            //Console.WriteLine("Player Two Score : " + m_PlayerTwo.Score);
        }

        public static string GetPlayerName()
        {
            Console.WriteLine("please enter your name: ");
            return Console.ReadLine();
        }

        public static int GetBoardSize()
        {
            Console.WriteLine("please enter the size of board game : ");
            return int.Parse(Console.ReadLine());
        }
        public static bool GetGameType()
        {
            bool res = false;
            Console.WriteLine("please enter type of game: 1 = human | 2 = computer");
            //check valid
           char key1 = char.Parse(Console.ReadLine());
           if (key1 == '1')
           {
               res = true;
           }

           return res;
        }

    }
}

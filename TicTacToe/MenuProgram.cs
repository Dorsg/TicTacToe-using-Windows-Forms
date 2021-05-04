using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class MenuProgram
    {
        public const int k_HumansOption = 1;
        public const int k_ComputerOption = 0;
        public static void Main()
        {
            Console.WriteLine("Welcome to TicTacToe game by Aviv and Dor :");
            int sizeOfBoard = GetBoardSize();
            int gameType = GetGameType();

            if (gameType == k_HumansOption) // flag gaming 
            {
                string playerOneName = GetPlayerName();
                string playerTwoName = GetPlayerName();

                Ex02.ConsoleUtils.Screen.Clear();
                new TwoPlayerGame(playerOneName, playerTwoName, sizeOfBoard);
            }
            else
            {
                string playerOneName = GetPlayerName();

                // computer option 
            }

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
        public static int GetGameType()
        {
            Console.WriteLine("please enter type of game: 1 = human | 2 = computer");
            //check valid
            return int.Parse(Console.ReadLine());
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class GameMenu
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
                // here should be the option to one more game
                string playerOneName = GetPlayerName();
                string playerTwoName = GetPlayerName();

                Ex02.ConsoleUtils.Screen.Clear();
                SingleGame game = new SingleGame(playerOneName, playerTwoName, sizeOfBoard, gameType);
                Console.WriteLine("Player One Score : " + game.Player1.Name);
                Console.WriteLine("Player Two Score : " + game.Player2.Name);
            }
            else // here should be the option to one more game
            {
                string playerOneName = GetPlayerName();
                SingleGame game = new SingleGame(playerOneName, "Computer", sizeOfBoard, gameType);
                Console.WriteLine("Player One Score : " + game.Player1.Name);
                Console.WriteLine("Player Two Score : " + game.Player2.Name);
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

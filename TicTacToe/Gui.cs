using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Gui
    {
        public static void WelcomMessage()
        {
            Console.WriteLine("Welcome to TicTacToe game by Aviv and Dor :");
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
            Console.WriteLine("please enter type of game: 1 = human | 2 = computer");
            //check valid
            return bool.Parse(Console.ReadLine());
        }


    }
}

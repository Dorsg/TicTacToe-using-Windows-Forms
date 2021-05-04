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

        public static int GetGameType()
        {
            Console.WriteLine("please enter type of game: 1 = human | 2 = computer");
            //check valid
            return int.Parse(Console.ReadLine());
        }

        public static void PrintBoard(int i_BoardSize, Board board)
        {
            Ex02.ConsoleUtils.Screen.Clear();

            int columCounter, rowsCounter, valuesCounter;
            rowsCounter = columCounter = valuesCounter = 0;
            valuesCounter = 1;
            for (; rowsCounter <= i_BoardSize; ++rowsCounter)
            {
                Console.Write("-");
                for (columCounter = 0; columCounter <= i_BoardSize; ++columCounter)
                {
                    Console.Write("----");
                }
                Console.WriteLine("");
                Console.Write("|");
                for (columCounter = 0; columCounter <= i_BoardSize; columCounter++)
                {
                    if (columCounter == 0 && rowsCounter > 0)
                    {
                        Console.Write(" " + valuesCounter + " |");
                        valuesCounter++;
                    }
                    else if (rowsCounter == 0)
                    {
                        Console.Write(" " + columCounter + " |");
                    }
                    else
                    {
                        Console.Write(" " + board[rowsCounter, columCounter] + " |");
                    }
                }
                Console.WriteLine("");
            }
            for (rowsCounter = 0; rowsCounter < i_BoardSize; ++rowsCounter)
            {
                Console.Write("-----");
            }
            Console.WriteLine();
        }
        public static char AskForRow()
        {
            Console.WriteLine("enter row : ");
            return char.Parse(Console.ReadLine());
        }
        public static char AskForCol()
        {
            Console.WriteLine("enter col : ");
            return char.Parse(Console.ReadLine());
        }
        public static void NextMoveInst(string i_PlayerName)
        {
            Console.WriteLine(i_PlayerName + "  Please choose your next move or Q if you want to quit");
        }

        public static void TryAgain()
        {
            Console.WriteLine("Wrong choose, please try again");
        }

        public static void Quit()
        {
            Console.WriteLine("you have chose to quit ");
        }
    }
}

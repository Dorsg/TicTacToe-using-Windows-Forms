using System;

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
            Console.WriteLine("Please enter your name: ");
            return Console.ReadLine();
        }
        public static int GetBoardSize()
        {
            Console.WriteLine("Please provide the size of board game : ");
            return int.Parse(Console.ReadLine());
        }
        public static int GetGameType()
        {
            Console.WriteLine("Please enter type of game: 1 = human | 2 = computer");
            return int.Parse(Console.ReadLine());
        }
        public static void PrintBoard(int i_BoardSize, Board i_Board)
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
                        Console.Write(" " + i_Board[rowsCounter, columCounter] + " |");
                    }
                }
                Console.WriteLine("");
            }
            for (rowsCounter = 0; rowsCounter <= i_BoardSize; ++rowsCounter)
            {
                Console.Write("----");
            }
            Console.WriteLine();
        }
        public static char AskForRow()
        {
            Console.WriteLine("Enter row : ");
            return char.Parse(Console.ReadLine());
        }
        public static char AskForCol()
        {
            Console.WriteLine("Enter col : ");
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
            Console.WriteLine("You have chose to Quit ");
        }
        public static void NewGame(string i_Player1Name, int i_Player1Score, string i_Player2Name, int i_Player2Score)
        {
            Console.WriteLine("Last game ended, score is now:" + Environment.NewLine 
                              + i_Player1Name + ": " + i_Player1Score + Environment.NewLine
                              + i_Player2Name + ": "+  i_Player2Score + Environment.NewLine 
                              + "Press any key to continue");
            Console.ReadLine();
        }
        public static void WinnerDecleration(string i_PlayerName)
        {
            Console.WriteLine(i_PlayerName + " is The Winner !! ");
        }
        public static void ThankYou()
        {
            Console.WriteLine("Thank you for playing ");
        }
        public static void Tie()
        {
            Console.WriteLine("Its a tie");
        }
    }
}

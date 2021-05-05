using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class GameMenu
    {
        public const int k_PlayerTwoIsHuman = 1;
        public const int k_PlayerTwoIsComputer = 2;
        public static void Main()
        {
            Gui.WelcomMessage();
            int boardSize = Gui.GetBoardSize();
            int gameType = Gui.GetGameType();

            Game game = new Game(boardSize, gameType);

            while (game.IsOn())
            {
                game.SessionOfGames();

            }

            Console.WriteLine("win!!!!!!!!!!!!");

        }

    }
}

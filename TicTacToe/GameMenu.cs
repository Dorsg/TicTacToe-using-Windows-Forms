using System;

namespace TicTacToe
{
    public class GameMenu
    {
        public const int k_PlayerTwoIsHuman = 1;
        public const int k_PlayerTwoIsComputer = 2;

        public GameMenu()
        {
            Gui.WelcomMessage();
            int boardSize = Gui.GetBoardSize();
            int gameType = Gui.GetGameType();
            bool QuitFlag = false;
            Game game = new Game(boardSize, gameType);

            while (game.IsOn())
            {
                game.SessionOfGames(ref QuitFlag);
            }

            Console.WriteLine("You have chose to quit the game");
            if (game.Player1.Score > game.Player2.Score)
            {
                Console.WriteLine(game.Player1.Name + " is The Winner !! ");
            }
            else if (game.Player1.Score < game.Player2.Score)
            {
                Console.WriteLine(game.Player2.Name + " is The Winner !! ");
            }
            else
            {
                Console.WriteLine("Its a tie");
            }
            Console.WriteLine("Thank you for playing ");
        }
    }
}

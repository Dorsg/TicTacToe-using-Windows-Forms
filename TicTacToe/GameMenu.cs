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

            Gui.Quit();

            if (game.Player1.Score > game.Player2.Score)
            {
                Gui.WinnerDecleration(game.Player1.Name);
            }
            else if (game.Player1.Score < game.Player2.Score)
            {
                Gui.WinnerDecleration(game.Player2.Name);
            }
            else
            {
                Gui.Tie();
            }

            Gui.ThankYou();
        }
    }
}

namespace TicTacToe
{
    public class GameMenu
    {
        public GameMenu()
        {
            Gui.WelcomMessage();
            int boardSize = Gui.GetBoardSize();
            int gameType = Gui.GetGameType();
            Game game = new Game(boardSize, gameType);

            while (game.IsOn())
            {
                game.SessionOfGames();
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

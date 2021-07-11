using System;
using System.Windows.Forms;
using System.Drawing;


namespace TicTac
{
    public class BoardForm : Form
    {
        private MyButton[,] m_ButtonsMatrix;
        private Label m_Player1Name;
        private Label m_Player1Score;
        private Label m_Player2Name;
        private Label m_Player2Score;
        private Game m_Game;

        public BoardForm()
        {
            this.CenterToScreen();
            this.Text = "TicTacToeMisere";
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }
        protected override void OnLoad(EventArgs i_E)
        {
            SettingForm settingsForm = new SettingForm();
            settingsForm.ShowDialog();
            initializeComponents(settingsForm);
            base.OnLoad(i_E);
        }
        private void initializeComponents(SettingForm i_SettingsForm)
        {
            int size = i_SettingsForm.BoardSize;
            m_ButtonsMatrix = new MyButton[size, size];
            eGameType gameType = getGameType(i_SettingsForm);
            m_Game = new Game(size, gameType);

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    m_ButtonsMatrix[row, col] = new MyButton();
                    {
                        m_ButtonsMatrix[row, col].Size = new Size(70, 70);
                        m_Game.GetBoardObj(row, col).UpdateCell += BoardForm_UpdateCell;
                        m_ButtonsMatrix[row, col].TabStop = false;
                        m_ButtonsMatrix[row, col].Row = row;
                        m_ButtonsMatrix[row, col].Col = col;
                        m_ButtonsMatrix[row, col].Left = col * 70;
                        m_ButtonsMatrix[row, col].Top = row * 70;
                        m_ButtonsMatrix[row, col].Click += NewButton_Click;
                        this.Controls.Add(m_ButtonsMatrix[row, col]);
                    }
                }
            }

            m_Player1Name = new Label();
            {
                m_Player1Name.Font = new Font(Label.DefaultFont, FontStyle.Bold);
                m_Player1Name.AutoSize = true;
                m_Player1Name.Text = i_SettingsForm.player1Name;
                m_Player1Name.Location = m_ButtonsMatrix[size - 1, size - 1].Location;
                m_Player1Name.Left = this.Width / 2 - 60;
                m_Player1Name.Top += 70;
                this.Controls.Add(m_Player1Name);
            }

            m_Player1Score = new Label();
            {
                m_Player1Score.AutoSize = true;
                m_Player1Score.Text = "0";
                m_Player1Score.Location = m_Player1Name.Location;
                m_Player1Score.Left = m_Player1Name.Right;
                this.Controls.Add(m_Player1Score);
            }

            m_Player2Name = new Label();
            {
                m_Player2Name.Font = new Font(Label.DefaultFont, FontStyle.Bold);
                m_Player2Name.AutoSize = true;
                m_Player2Name.Location = m_ButtonsMatrix[size - 1, size - 1].Location;
                m_Player2Name.Left = m_Player1Score.Right + 5;
                m_Player2Name.Top = m_Player1Name.Top;
                setPlayer2Name(i_SettingsForm);
                this.Controls.Add(m_Player2Name);
            }

            m_Player2Score = new Label();
            {
                m_Player2Score.AutoSize = true;
                m_Player2Score.Text = "0";
                m_Player2Score.Location = m_Player2Name.Location;
                m_Player2Score.Left = m_Player2Name.Right;
                this.Controls.Add(m_Player2Score);
            }

        }

        private void BoardForm_UpdateCell(object i_Sender, EventArgs e)
        {
            BoardObject cell = i_Sender as BoardObject;
            int row = cell.Row;
            int col = cell.Col;
            ePlayerSign sign = cell.Sign;

            if (sign == ePlayerSign.Player1)
            {
                m_ButtonsMatrix[row, col].Text = "X";
            }
            else if (sign == ePlayerSign.Player2)
            {
                m_ButtonsMatrix[row, col].Text = "O";
            }

            m_ButtonsMatrix[row, col].Enabled = false;
        }

        private eGameType getGameType(SettingForm i_SettingsForm)
        {
            eGameType gameType;

            if (i_SettingsForm.player2Name == "[Computer]")
            {
                gameType = eGameType.AgainstComputer;
            }
            else
            {
                gameType = eGameType.TwoPlayersGame;
            }

            return gameType;

        }
        private void setPlayer2Name(SettingForm i_SettingsForm)
        {
            if (i_SettingsForm.player2Name == "[Computer]")
            {
                m_Player2Name.Text = "Computer";
            }
            else
            {
                m_Player2Name.Text = i_SettingsForm.player2Name;
            }
        }

        public void RestBoardForm()
        {
            foreach (MyButton current in m_ButtonsMatrix)
            {
                current.Text = " ";
                current.Enabled = true;
            }
        }
        private void NewButton_Click(object i_Sender, EventArgs e)
        {
            MyButton theSender = i_Sender as MyButton;
            int buttonRow = theSender.Row;
            int buttonCol = theSender.Col;
            m_Game.playMove(buttonRow, buttonCol);
            m_Game.SetNextPlayer();
            CheckGameConditions();
            
            if (m_Game.GameType == eGameType.AgainstComputer)
            {
                m_Game.computerNextMove();
                m_Game.SetNextPlayer();
            }
        }

        private void CheckGameConditions()
        {
            ePlayerSign lastPlayed;
            bool tieFlag;
            bool finishGame = m_Game.CheckWinner(out lastPlayed, out tieFlag);
            if (finishGame && !tieFlag)
            {
                displayWinner(lastPlayed);
            }
            if (tieFlag)
            {
                MessageBox.Show("Its a tie !");
            }

            if (finishGame)
            {
                DialogResult result = MessageBox.Show($" Would you like to play another round ?", "Game Message:", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    restGame();
                }
                else
                {
                   endSessions();
                }

            }
        }

        private void displayWinner(ePlayerSign i_LastPlayed)
        {
            if (i_LastPlayed == ePlayerSign.Player1)
            {
                MessageBox.Show(m_Player1Name.Text + " has  Won !!");
                m_Player1Score.Text = (int.Parse(m_Player1Score.Text) + 1).ToString();
            }
            else if (i_LastPlayed == ePlayerSign.Player2)
            {
                MessageBox.Show(m_Player2Name.Text + " has  Won !!");
                m_Player2Score.Text = (int.Parse(m_Player2Score.Text) + 1).ToString();
            }
        }
        private void restGame()
        {
            RestBoardForm();
            m_Game.initBoard();
        }
        private void endSessions()
        {
            int player1Score = int.Parse(m_Player1Score.Text);
            int player2Score = int.Parse(m_Player2Score.Text);
            if (player1Score > player2Score)
            {
                MessageBox.Show(m_Player1Name.Text + " is the winner of the session !!", "GoodBye Message:", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (player1Score == player2Score)
            {
                MessageBox.Show("Its a tie !", "GoodBye Message:", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(m_Player2Name.Text + " is the winner of the session !!", "GoodBye Message:", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.Close();
        }

    }
}
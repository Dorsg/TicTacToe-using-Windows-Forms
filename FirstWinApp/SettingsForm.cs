using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;


namespace TicTac
{
     public class SettingForm : Form
     {

          Label m_Players;
          Label m_Player1;
          TextBox m_player1Text;
          CheckBox m_Player2ChekBox;
          Label m_Player2;
          TextBox m_player2Text;
          Label m_BoardSize;
          Label m_Rows;
          NumericUpDown m_RowsUpDown;
          Label m_Coles;
          NumericUpDown m_ColesUpDown;
          Button m_buttonStart;

          public int BoardSize => int.Parse(m_ColesUpDown.Text);
          public string player2Name => m_player2Text.Text;
          public string player1Name => m_player1Text.Text;

          public SettingForm()
          {
               this.MaximumSize = this.Size;
               this.MinimumSize = this.Size;
               this.CenterToScreen();
               this.Text = "Game Settings";
               initializeComponents();
          }

          private void initializeComponents()
          {
               m_Players = new Label();
               m_Players.Text = "Players:";
               m_Players.Left = 16;
               m_Players.Top = 16;
               this.Controls.Add(m_Players);

               m_Player1 = new Label();
               m_Player1.AutoSize = true; 
               m_Player1.Text = "Player 1:";
               m_Player1.Left = m_Players.Left + 10;
               m_Player1.Top = m_Players.Bottom + 5;
               this.Controls.Add(m_Player1);

               m_player1Text = new TextBox();
               m_player1Text.Left = m_Player1.Right + 35;
               m_player1Text.Top = m_Player1.Top + m_Player1.Height / 2 - m_player1Text.Height / 2;
               this.Controls.Add(m_player1Text);

               m_Player2 = new Label();
               m_Player2.AutoSize = true;
               m_Player2.Text = "Player 2:";
               m_Player2.Left = m_Player1.Left + 22;
               m_Player2.Top = m_Player1.Bottom + 15;
               this.Controls.Add(m_Player2);

               m_Player2ChekBox = new CheckBox();
               m_Player2ChekBox.Left = m_Player1.Left + 3;
               m_Player2ChekBox.Top = m_Player2.Top + 1;
               m_Player2ChekBox.Click += player2ChekBox_Click;
               this.Controls.Add(m_Player2ChekBox);

               m_player2Text = new TextBox();
               m_Player2ChekBox.AutoSize = true;
               m_player2Text.Enabled = false;
               m_player2Text.Text = "[Computer]";
               m_player2Text.Left = m_player1Text.Left;
               m_player2Text.Top = m_player1Text.Bottom + 10;
               this.Controls.Add(m_player2Text);

               m_BoardSize = new Label();
               m_BoardSize.Text = "Board Size:";
               m_BoardSize.Left = m_Players.Left;
               m_BoardSize.Top = m_Players.Bottom + 75;
               this.Controls.Add(m_BoardSize);

               m_Rows = new Label();
               m_Rows.AutoSize = true;
               m_Rows.Text = "Rows:";
               m_Rows.Left = m_BoardSize.Left + 10;
               m_Rows.Top = m_BoardSize.Bottom + 5;
               this.Controls.Add(m_Rows);

               m_RowsUpDown = new NumericUpDown();
               m_RowsUpDown.Left = m_Rows.Left + 45;
               m_RowsUpDown.Top = m_Rows.Top - 2;
               m_RowsUpDown.Width = 40;
               m_RowsUpDown.Minimum = 3;
               m_RowsUpDown.Maximum = 9;
               m_RowsUpDown.ValueChanged += M_RowsUpDown_ValueChanged;
               this.Controls.Add(m_RowsUpDown);

               m_Coles = new Label();
               m_Coles.AutoSize = true;
               m_Coles.Text = "Coles:";
               m_Coles.Left = m_Rows.Left + 120;
               m_Coles.Top = m_Rows.Top;
               this.Controls.Add(m_Coles);

               m_ColesUpDown = new NumericUpDown();
               m_ColesUpDown.Left = m_RowsUpDown.Left + 120;
               m_ColesUpDown.Top = m_RowsUpDown.Top;
               m_ColesUpDown.Width = 40;
               m_ColesUpDown.Minimum = 3;
               m_ColesUpDown.Maximum = 9;
               m_ColesUpDown.ValueChanged += M_ColesUpDown_ValueChanged;
               this.Controls.Add(m_ColesUpDown);

               m_buttonStart = new Button();
               m_buttonStart.Text = "start!";
               m_buttonStart.Left = m_Rows.Left;
               m_buttonStart.Top = m_RowsUpDown.Bottom + 50;
               m_buttonStart.Width = 215;
               m_buttonStart.Click += buttonStart_Click;
               this.Controls.Add(m_buttonStart);

          }

          private void M_ColesUpDown_ValueChanged(object sender, EventArgs e)
          {
               m_RowsUpDown.Value = m_ColesUpDown.Value;
          }

          private void M_RowsUpDown_ValueChanged(object sender, EventArgs e)
          {
               m_ColesUpDown.Value = m_RowsUpDown.Value;
          }

          private void buttonStart_Click(object sender, EventArgs e)
          {
               if (m_player1Text.Text != string.Empty)
               {
                    if (m_Player2ChekBox.Checked == false || m_player2Text.Text != String.Empty)
                    {
                         this.Close();
                    }
               }
          }
          private bool ensureAllFilled()
          {
               if (m_player1Text.Text == String.Empty)
               {
                    return false;
               }
               else
               {
                    return true;
               }
          }
          private void player2ChekBox_Click(object sender, EventArgs e)
          {
               if (m_Player2ChekBox.Checked == true)
               {
                    m_player2Text.Enabled = true;
                    m_player2Text.Text = string.Empty;
               }
               else
               {
                    m_player2Text.Enabled = false;
                    m_player2Text.Text = "[Computer]";
               }
          }
     }
}
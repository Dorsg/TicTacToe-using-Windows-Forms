using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace TicTac
{
    public class Program
    {
         [STAThread]
        public static void Main()
        {
             Application.EnableVisualStyles();
             Application.SetCompatibleTextRenderingDefault(false);
             BoardForm boardForm = new BoardForm();
             boardForm.ShowDialog();

        }


     }

   
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTac
{
     public class MyButton : Button
     {

          public int m_Row;
          public int m_Col;
        

          public int Row
          {
               get => m_Row;
               set { m_Row = value; }
          }

          public int Col
          {
               get => m_Col;
               set { m_Col = value; }
          }

          //sign used cell


     }



}

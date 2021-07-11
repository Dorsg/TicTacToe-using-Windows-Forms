using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTac
{
     public class BoardObject
     {
          private int m_Row;
          private int m_Col;
          private ePlayerSign m_Sign;
          public event EventHandler UpdateCell;

          public BoardObject(int i_Row, int i_Col)
          {
               m_Row = i_Row;
               m_Col = i_Col;
               m_Sign = ePlayerSign.None;
          }

          public void OnCellUpdate(EventArgs e)
          {
               UpdateCell?.Invoke(this, e);
          }
     

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

          public ePlayerSign Sign
          {
               get => m_Sign;
               set { m_Sign = value; }
          }
     }
}

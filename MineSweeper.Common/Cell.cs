using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper.Common
{
    public class Cell
    {
        public bool IsOpen;
        public bool Flag;
        public int MineCountAround;
        public bool IsMine;
    }
}

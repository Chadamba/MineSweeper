using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper.Common
{
    public class Game
    {
        public Cell[,] Field;

        public void InitializeFeild(Size size, int mineCount)
        {
            
            Field = new Cell[size.Height,size.Width];

            for (int i = 0; i < size.Height; i++)
            {
                for (int j = 0; j < size.Width; j++)
                {
                    Field[i,j] = new Cell();
                }
            }

            for (int i = 0;i < mineCount; i++)
            {

            }
        }
    }
}

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
        private Random Random = new Random();

        public void InitializeField(Size size, int mineCount)
        {

            Field = new Cell[size.Height, size.Width];

            for (int i = 0; i < size.Height; i++)
            {
                for (int j = 0; j < size.Width; j++)
                {
                    Field[i, j] = new Cell();
                    Field[i, j].IsOpen = true;
                }
            }

            for (int i = 0; i < mineCount; i++)
            {
                int x = Random.Next(0, size.Width);
                int y = Random.Next(0, size.Height);

                if (Field[x, y].IsMine)
                {
                    i--;
                }
                else
                {
                    Field[x, y].IsMine = true;
                }
            }
        }
    }
}

using MineSweeper.Common;
using System.Diagnostics;

internal class Program
{
    private static void Main(string[] args)
    {
        var game = new Game();
        var size = new Size();
        size.Width = 8;
        size.Height = 8;

        var stopwatch = new Stopwatch();
        stopwatch.Start();
        game.InitializeField(size, 8);
        stopwatch.Stop();

        Console.WriteLine(stopwatch.ElapsedTicks);

        for (int i = 0; i < size.Height; i++)
        {
            for (int j = 0; j < size.Width; j++)
            {
                var cell = game.Field[i, j];
                if (cell.IsOpen)
                {
                    if (cell.IsMine)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(cell.MineCountAround);
                    }
                }
                else
                {
                    if (cell.Flag)
                    {
                        Console.Write("P");
                    }
                    else
                    {
                        Console.Write("[ ]");
                    }
                }
                Console.Write("\t");
            }
            Console.WriteLine();
        }



    }
}
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
        Console.WriteLine();
        var standardColor = Console.ForegroundColor;

        for (int i = 0; i < size.Height; i++)
        {
            for (int j = 0; j < size.Width; j++)
            {
                var cell = game.Field[i, j];
                if (cell.IsOpen)
                {
                    if (!cell.IsMine)
                    {
                        Console.Write($"|");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"{cell.MineCountAround}");
                        Console.ForegroundColor = standardColor;
                        Console.Write($"|");
                    }
                    else
                    {
                        Console.Write($"|");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("X");
                        Console.ForegroundColor = standardColor;
                        Console.Write($"|");
                    }
                }
                else
                {
                    Console.Write("[?]");
                }

                Console.Write("");
            }
            Console.WriteLine();

        }
        Console.ReadKey(true);
    }


    /*public void WalkingOnField(ConsoleKey key)
    {
        while ((key = Console.ReadKey(true).Key) != ConsoleKey.Enter)
        {
            switch (key)
            {
                case ConsoleKey.W: break;
                case ConsoleKey.S: break;
                case ConsoleKey.D: break;
                case ConsoleKey.A: break;
            }
        }

    }*/
}
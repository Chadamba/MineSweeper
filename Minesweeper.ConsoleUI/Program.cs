using MineSweeper.Common;
using System.Diagnostics;

internal class Program
{
    private static void Main(string[] args)
    {
        var game = new Game();
        var size = new Size();
        size.Width = 19;
        size.Height = 19;

        var stopwatch = new Stopwatch();
        stopwatch.Start();
        game.InitializeField(size, 100);

        stopwatch.Stop();

        Console.WriteLine(stopwatch.ElapsedTicks);
        Console.WriteLine();
        var standardColor = Console.ForegroundColor;

        for (int i = 0; i < size.Height + 2; i++)
        {
            if (i == 0)
            {
                for (int j = 0; j < size.Width; j++)
                {
                    Console.Write("---");
                }
            }
            else if (i == size.Height + 1)
            {
                for (int j = 0; j < size.Width; j++)
                {
                    Console.Write("---");
                }
            }
            else
            {
                for (int j = 0; j < size.Width; j++)
                {

                    var cell = game.Field[i - 1, j];
                    if (cell.IsOpen)
                    {
                        if (!cell.IsMine)
                        {
                            if (cell.MineCountAround != 0)
                            {
                                Console.Write($"|");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write($"{cell.MineCountAround}");
                                Console.ForegroundColor = standardColor;
                                Console.Write($"|");
                            }
                            else
                            {
                                Console.Write($"|0|");

                            }
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
                        if (cell.Flag)
                        {
                            Console.Write($"|");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("P");
                            Console.ForegroundColor = standardColor;
                            Console.Write($"|");
                        }
                        else
                        {
                            Console.Write($"|");
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("?");
                            Console.ForegroundColor = standardColor;
                            Console.Write($"|");
                        }

                    }

                    Console.Write("");
                }
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
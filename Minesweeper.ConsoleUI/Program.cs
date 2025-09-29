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

        game.InitializeField(size, 10);

        int xGame = 0;
        int yGame = 0;
        ConsoleKey? key = null;
        Console.Clear();

        while (key != ConsoleKey.Escape)
        {
            Console.Clear();

            DrawGameField(game, size);
            switch (key)
            {
                case ConsoleKey.RightArrow:
                    var nextRight = xGame + 1;
                    if (size.Width > nextRight)
                    {
                        ++xGame;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    var nextDown = yGame + 1;
                    if (size.Height > nextDown)
                    {
                        ++yGame;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    var nextLeft = xGame - 1;
                    if (0 <= nextLeft)
                    {
                        --xGame;
                    }
                    break;
                case ConsoleKey.UpArrow:
                    var nextUp = yGame - 1;
                    if (0 <= nextUp)
                    {
                        --yGame;
                    }
                    break;
                case ConsoleKey.Spacebar:
                    game.OpenCell(xGame, yGame);
                    break;
                case ConsoleKey.Enter:
                    game.SetFlag(xGame, yGame);
                    break;
                default:
                    break;
            }
            DrawCell(xGame, yGame, game.Field[yGame, xGame], true);
            key = Console.ReadKey(true).Key;
        }
    }

    private static void DrawGameField(Game game, Size size)
    {
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
                    DrawCell(j, i - 1, cell);
                }
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    private static (int AbsX, int AbsY) ConvertToAbs(int x, int y)
    {
        return (x * 3, y + 1);
    }

    private static void DrawCell(int x, int y, Cell cell, bool isSelected = false)
    {
        var (absX, absY) = ConvertToAbs(x, y);
        Console.SetCursorPosition(absX, absY);

        Console.ForegroundColor = isSelected ? ConsoleColor.Green : ConsoleColor.White;
        Console.Write($"|");
        Console.ForegroundColor = ConsoleColor.White;
        if (cell.IsOpen)
        {
            if (!cell.IsMine)
            {
                WriteNumber(cell.MineCountAround);
            }
            else
            {
                WriteMine();
            }
        }
        else
        {
            if (cell.Flag)
            {
                WriteFlag();
            }
            else
            {
                WriteClosedCell();
            }
        }
        Console.ForegroundColor = isSelected ? ConsoleColor.Green : ConsoleColor.White;
        Console.Write($"|");
        Console.ForegroundColor = ConsoleColor.White;
    }

    private static void WriteMine()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("X");
        Console.ForegroundColor = ConsoleColor.White;
    }

    private static void WriteFlag()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("!");
        Console.ForegroundColor = ConsoleColor.White;
    }

    private static void WriteNumber(int mineCountAround)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write($"{mineCountAround}");
        Console.ForegroundColor = ConsoleColor.White;
    }

    private static void WriteClosedCell()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write("?");
        Console.ForegroundColor = ConsoleColor.White;
    }
}
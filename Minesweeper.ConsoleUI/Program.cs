using MineSweeper.Common;

internal class Program
{
    private static void Main(string[] args)
    {
        var game = new Game();
        var size = new Size();
        size.Width = 9;
        size.Height = 9;

        game.InitializeFeild(size, 5);

        for (int i = 0; i < size.Height; i++)
        {
            for (int j = 0; j < size.Width; j++)
            {
                var cell = game.Field[i, j];
                if (cell.IsOpen)
                {
                    Console.Write(cell.MineCount);
                }
                else
                {
                    if (cell.Flag)
                    {
                        Console.Write("P");
                    }
                    else
                    {
                        Console.Write("X");
                    }
                }
                Console.Write("\t");
            }
            Console.WriteLine();
        }



    }
}
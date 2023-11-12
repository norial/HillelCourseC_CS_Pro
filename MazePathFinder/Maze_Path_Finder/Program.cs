

namespace MazePathFinder
{
    class Program
    {

        static void Main()
        {
            int rows = 10;
            int cols = 5;
            Random random = new Random();
            Point start = new Point(0, random.Next(rows));
            Point exit = new Point(rows - 1, random.Next(rows));

            MazeMaster mazeMaster = new MazeMaster(rows, cols);
            mazeMaster.GenerateMaze(30, start, exit);
            mazeMaster.PrintMaze(start, exit);

            List<Point> path = mazeMaster.FindPath(start, exit);
            Console.WriteLine("\nPath:");
            mazeMaster.PrintMaze(start, exit, path);
            Console.ReadKey();
        }

    }
}
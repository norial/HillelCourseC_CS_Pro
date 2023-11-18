namespace Maze_Path_Finder
{
    public class MazeMaster
    {
        private int[,] maze;
        private int rows;
        private int cols;

        public MazeMaster(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;
            maze = new int[rows, cols];
        }

        public void GenerateMaze(int obstaclePercentage, Point start, Point exit)
        {
            Random rand = new Random();

            // Generate obstacles based on obstaclePercentage
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    maze[i, j] = (rand.Next(100) < obstaclePercentage) ? 1 : 0;
                }
            }

        }

        public List<Point> FindPath(Point start, Point exit)
        {
            // Implementation of the A* algorithm
            PriorityQueue<Point> openSet = new PriorityQueue<Point>();
            HashSet<Point> closedSet = new HashSet<Point>();

            openSet.Enqueue(start, 0);

            Dictionary<Point, Point> cameFrom = new Dictionary<Point, Point>();
            Dictionary<Point, int> gScore = new Dictionary<Point, int>();
            gScore[start] = 0;

            Dictionary<Point, int> fScore = new Dictionary<Point, int>();
            fScore[start] = HeuristicCostEstimate(start, exit);

            while (openSet.Count > 0)
            {
                Point current = openSet.Dequeue();

                if (current.Equals(exit))
                {
                    return ReconstructPath(cameFrom, current);
                }

                closedSet.Add(current);

                foreach (Point neighbor in GetNeighbors(current))
                {
                    if (closedSet.Contains(neighbor))
                        continue;

                    int tentativeGScore = gScore[current] + 1;

                    if (!openSet.Contains(neighbor) || tentativeGScore < gScore[neighbor])
                    {
                        cameFrom[neighbor] = current;
                        gScore[neighbor] = tentativeGScore;
                        fScore[neighbor] = gScore[neighbor] + HeuristicCostEstimate(neighbor, exit);

                        if (!openSet.Contains(neighbor))
                        {
                            openSet.Enqueue(neighbor, fScore[neighbor]);
                        }
                    }
                }
            }

            // If no path found
            return new List<Point>();
        }

        private int HeuristicCostEstimate(Point current, Point goal)
        {
            // Simple Manhattan distance as heuristic
            return Math.Abs(current.X - goal.X) + Math.Abs(current.Y - goal.Y);
        }

        private List<Point> ReconstructPath(Dictionary<Point, Point> cameFrom, Point current)
        {
            List<Point> path = new List<Point> { current };

            while (cameFrom.ContainsKey(current))
            {
                current = cameFrom[current];
                path.Add(current);
            }

            path.Reverse();
            return path;
        }

        private List<Point> GetNeighbors(Point current)
        {
            List<Point> neighbors = new List<Point>();

            if (current.X > 0 && maze[current.X - 1, current.Y] == 0)
                neighbors.Add(new Point(current.X - 1, current.Y));

            if (current.X < rows - 1 && maze[current.X + 1, current.Y] == 0)
                neighbors.Add(new Point(current.X + 1, current.Y));

            if (current.Y > 0 && maze[current.X, current.Y - 1] == 0)
                neighbors.Add(new Point(current.X, current.Y - 1));

            if (current.Y < cols - 1 && maze[current.X, current.Y + 1] == 0)
                neighbors.Add(new Point(current.X, current.Y + 1));

            return neighbors;
        }

        public void PrintMaze(Point start, Point exit, List<Point> path = null)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Point current = new Point(i, j);

                    if (path != null && path.Contains(current))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("P ");
                    }
                    else
                    {
                        if (maze[i, j] == 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("# ");
                        }
                        else if (current.Equals(start))
                        {
                            Console.Write("S ");
                        }
                        else if (current.Equals(exit))
                        {
                            Console.Write("F ");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write(". ");
                        }
                    }
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }
    }

    public class Point : IEquatable<Point>
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public bool Equals(Point other)
        {
            return X == other.X && Y == other.Y;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }
    }

    // Priority Queue implementation for A* algorithm
    public class PriorityQueue<T>
    {
        private List<(T, int)> elements = new List<(T, int)>();

        public int Count => elements.Count;

        public void Enqueue(T item, int priority)
        {
            elements.Add((item, priority));
        }

        public T Dequeue()
        {
            int bestIndex = 0;

            for (int i = 0; i < elements.Count; i++)
            {
                if (elements[i].Item2 < elements[bestIndex].Item2)
                {
                    bestIndex = i;
                }
            }

            T bestItem = elements[bestIndex].Item1;
            elements.RemoveAt(bestIndex);
            return bestItem;
        }

        public bool Contains(T item)
        {
            return elements.Any(x => x.Item1.Equals(item));
        }
    }
}
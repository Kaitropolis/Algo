using System.Diagnostics;

namespace Algo
{
    public class PathFinding : IChoice
    {
        public void Run()
        {
            var grid = new Grid(10, 10);
            var startNode = grid.GetNode(0, 0);
            var endNode = grid.GetNode(9, 5);
            var path = DepthFirstSearch(grid, startNode, endNode);

            PrintGrid(grid, path);
        }

        static void PrintGrid(Grid grid, List<Node> path)
        {
            for (int y = 0; y < grid.Height; y++)
            {
                for (int x = 0; x < grid.Width; x++)
                {
                    if (path != null && path.Exists(n => n.X == x && n.Y == y))
                    {
                        Console.Write("P ");
                    }
                    else if (grid.Nodes[x, y].IsWalkable)
                    {
                        Console.Write(". ");
                    }
                    else
                    {
                        Console.Write("- ");
                    }
                }

                Console.WriteLine();
            }
        }

        public static List<Node> DepthFirstSearch(Grid grid, Node startNode, Node endNode)
        {
            Console.WriteLine("Running Depth First Search\n");

            var stopwatch = new Stopwatch();  
            
            stopwatch.Start();

            stopwatch.Stop();

            LogTimeTaken(stopwatch);

            return new List<Node>();
        }

        static void LogTimeTaken(Stopwatch stopwatch)
        {
            var elapsedSeconds = stopwatch.ElapsedMilliseconds / 1000.0;

            Console.WriteLine($"Time to complete the path: {elapsedSeconds} seconds\n");
        }
    }
}

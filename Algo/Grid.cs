namespace Algo
{
    public class Grid
    {
        public Node[,] Nodes { get; private set; }
        public int Width { get; }
        public int Height { get; }

        public Grid(int width, int height)
        {
            // Populate grid nodes
            Width = width;
            Height = height;
            Nodes = new Node[width, height];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Nodes[x, y] = new Node { X = x, Y = y };
                }
            }
        }

        public Node? GetNode(int x, int y)
        {
            if (x < 0 || y < 0 || x >= Width || y >= Height) return null;
            return Nodes[x, y];
        }

        public IEnumerable<Node> GetNeighbors(Node node)
        {
            var neighbors = new List<Node>();

            for (int dx = -1; dx <= 1; dx++)
            {
                for (int dy = -1; dy <= 1; dy++)
                {
                    if (dx == 0 && dy == 0) continue;

                    var neighbor = GetNode(node.X + dx, node.Y + dy);

                    if (neighbor != null && neighbor.IsWalkable)
                        neighbors.Add(neighbor);
                }
            }

            return neighbors;
        }
    }
}

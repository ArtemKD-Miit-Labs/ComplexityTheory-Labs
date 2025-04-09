using System.Numerics;

internal class Program
{
    static int[] Dijkstra(int[,] graph, int src)
    {
        int verticesCount = graph.GetLength(0);
        int[] distance = new int[verticesCount];
        bool[] shortestPathTreeSet = new bool[verticesCount];

        for (int i = 0; i < verticesCount; i++)
            distance[i] = int.MaxValue;

        distance[src] = 0;

        for (int count = 0; count < verticesCount - 1; count++)
        {
            int u = MinDistance(distance, shortestPathTreeSet);
            shortestPathTreeSet[u] = true;

            for (int v = 0; v < verticesCount; v++)
            {
                if (!shortestPathTreeSet[v] &&
                    graph[u, v] != 0 &&
                    distance[u] != int.MaxValue &&
                    distance[u] + graph[u, v] < distance[v])
                {
                    distance[v] = distance[u] + graph[u, v];
                }
            }
        }

        return distance;
    }

    static int MinDistance(int[] distance, bool[] sptSet)
    {
        int min = int.MaxValue, minIndex = -1;

        for (int v = 0; v < distance.Length; v++)
        {
            if (!sptSet[v] && distance[v] <= min)
            {
                min = distance[v];
                minIndex = v;
            }
        }

        return minIndex;
    }

    private static void Main(string[] args)
    {
        int[,] graph = {
            { 0,  4,  0,  0,  0,  0,  0,  8,  0 },
            { 4,  0,  8,  0,  0,  0,  0, 11,  0 },
            { 0,  8,  0,  7,  0,  4,  0,  0,  2 },
            { 0,  0,  7,  0,  9, 14,  0,  0,  0 },
            { 0,  0,  0,  9,  0, 10,  0,  0,  0 },
            { 0,  0,  4, 14, 10,  0,  2,  0,  0 },
            { 0,  0,  0,  0,  0,  2,  0,  1,  6 },
            { 8, 11,  0,  0,  0,  0,  1,  0,  7 },
            { 0,  0,  2,  0,  0,  0,  6,  7,  0 }
        };

        Console.WriteLine("Алгоритм Дейкстры");
        PrintGraph(graph);

        Console.Write("Введите вершину графа: ");
        int src = int.Parse(Console.ReadLine() ?? throw new ArgumentNullException("Empty input"));

        var distance = Dijkstra(graph, src);

        Console.WriteLine($"Вершина \t Расстояние от вершины {src}");
        for (int i = 0; i < distance.Length; i++)
            Console.WriteLine($"{i} \t\t {distance[i]}");
    }

    static void PrintGraph(int[,] graph)
    {
        int rows = graph.GetLength(0);
        int cols = graph.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write($"{graph[i, j],4}");
            }
            Console.WriteLine();
        }
    }
}
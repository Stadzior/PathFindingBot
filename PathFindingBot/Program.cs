using PathFindingBot.Model;
using System;
using System.Diagnostics;

namespace PathFindingBot
{
    class Program
    {
        static void Main(string[] args)
        {
            var randomMap = Map.Randomize(50, 1, 10, true);
            var djikstraPathFinder = new DjikstraPathFinder(randomMap);
            var sw = new Stopwatch();
            sw.Start();
            var shortestPath = djikstraPathFinder.GetShortestPath();
            sw.Stop();
            Console.Write($"Total: {randomMap.Nodes.Count}\r\n" +
                $"Visited {djikstraPathFinder.NodeVisits}\r\n" +
                $"Time: {sw.Elapsed.TotalMilliseconds}ms\r\n" +
                $"Path length: {djikstraPathFinder.ShortestPathLength.ToString("0.00")}\r\n" +
                $"Path Cost: {djikstraPathFinder.ShortestPathCost.ToString("0.00")}");
            Console.ReadKey();
        }
    }
}

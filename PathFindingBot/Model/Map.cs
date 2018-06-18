using System;
using System.Collections.Generic;
namespace PathFindingBot.Model
{
    public class Map
    {
        public static Map Randomize(int nodeCount, int branching, int seed, bool randomWeights)
        {
            var rnd = new Random(seed);
            var map = new Map();

            for (int i = 0; i < nodeCount; i++)
            {
                var newNode = Node.GetRandom(rnd, i.ToString());
                if (!newNode.ToCloseToAny(map.Nodes))
                    map.Nodes.Add(newNode);
            }

            foreach (var node in map.Nodes)
                node.ConnectClosestNodes(map.Nodes, branching, rnd, randomWeights);
            map.EndNode = map.Nodes[rnd.Next(map.Nodes.Count - 1)];
            map.StartNode = map.Nodes[rnd.Next(map.Nodes.Count - 1)];

            foreach (var node in map.Nodes)
            {
                Console.WriteLine($"{node}");
                foreach (var cnn in node.Connections)
                    Console.WriteLine($"{cnn}");
            }
            return map;
        }

        public List<Node> Nodes { get; set; } = new List<Node>();

        public Node StartNode { get; set; }

        public Node EndNode { get; set; }

        public List<Node> ShortestPath { get; set; } = new List<Node>();
    }
}

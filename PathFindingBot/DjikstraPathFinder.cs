﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PathFindingBot
{
    public class DjikstraPathFinder : IPathFinder
    {
        public List<Node> GetShortestPath()
        {
            Search();
            var shortestPath = new List<Node>();
            shortestPath.Add(End);
            BuildShortestPath(shortestPath, End);
            shortestPath.Reverse();
            return shortestPath;
        }

        private void BuildShortestPath(List<Node> list, Node node)
        {
            if (node.NearestToStart == null)
                return;
            list.Add(node.NearestToStart);
            BuildShortestPath(list, node.NearestToStart);
        }

        private void Search()
        {
            Start.MinCostToStart = 0;
            var prioQueue = new List<Node>();
            prioQueue.Add(Start);
            do
            {
                prioQueue = prioQueue.OrderBy(x => x.MinCostToStart).ToList();
                var node = prioQueue.First();
                prioQueue.Remove(node);
                foreach (var cnn in node.Connections.OrderBy(x => x.Cost))
                {
                    var childNode = cnn.ConnectedNode;
                    if (childNode.Visited)
                        continue;
                    if (childNode.MinCostToStart == null ||
                        node.MinCostToStart + cnn.Cost < childNode.MinCostToStart)
                    {
                        childNode.MinCostToStart = node.MinCostToStart + cnn.Cost;
                        childNode.NearestToStart = node;
                        if (!prioQueue.Contains(childNode))
                            prioQueue.Add(childNode);
                    }
                }
                node.Visited = true;
                if (node == End)
                    return;
            } while (prioQueue.Any());
        }
    }
}
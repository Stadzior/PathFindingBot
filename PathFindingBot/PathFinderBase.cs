using PathFindingBot.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PathFindingBot
{
    public abstract class PathFinderBase : IPathFinder
    {
        public Map Map { get; set; }
        public Node Start { get; set; }
        public Node End { get; set; }
        public int NodeVisits { get; set; }
        public double ShortestPathLength { get; set; }
        public double ShortestPathCost { get; private set; }

        public PathFinderBase(Map map)
        {
            Map = map;
            End = map.EndNode;
            Start = map.StartNode;
        }        

        protected void BuildShortestPath(IList<Node> list, Node node)
        {
            if (node.NearestToStart == null)
                return;
            list.Add(node.NearestToStart);
            BuildShortestPath(list, node.NearestToStart);
        }

        public abstract IList<Node> GetShortestPath();
        protected abstract void Search();
    }
}

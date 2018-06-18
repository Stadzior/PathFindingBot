using PathFindingBot.Model;
using System.Collections.Generic;

namespace PathFindingBot
{
    interface IPathFinder
    {
        IList<Node> GetShortestPath();
    }
}

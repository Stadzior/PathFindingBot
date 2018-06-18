using System;
using System.Collections.Generic;
using System.Text;

namespace PathFindingBot
{
    interface IPathFinder
    {
        IList<Node> GetShortestPath();
    }
}

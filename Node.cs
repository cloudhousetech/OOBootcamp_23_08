using System;
using System.Collections.Generic;
using System.Linq;
using static OoBootCamp.Path;

namespace OoBootCamp
{
    // Understands how to get to other nodes
    public class Node
    {
        private readonly List<Link> _connections = new List<Link>();

        public bool CanReach(Node destination)
        {
            return Paths(destination).Any();
        }
        public Node To(Node target, int cost)
        {
            _connections.Add(new Link(target, cost));

            return target;
        }
        public int HopCount(Node destination)
        {
            return Path(destination, FewestHops).HopCount();
        }
        public double Cost(Node destination)
        {
            return Path(destination).Cost();
        }
        public Path Path(Node destination)
        {
            return Path(destination, LeastCost);
        }

        private Path Path(Node destination, IComparer<Path> pathStrategy)
        {
            var paths = Paths(destination);

            if (!paths.Any()) throw new InvalidOperationException();

            paths.Sort(pathStrategy);

            return paths.First();
        }
        public List<Path> Paths(Node destination)
        {
            return Paths(destination, new List<Node>()).ToList();
        }

        internal IList<Path> Paths(Node destination, List<Node> visitedNodes)
        {
            if (this == destination) return new List<Path> {new Path()};
            if (visitedNodes.Contains(this)) return new List<Path>();
            if (!_connections.Any()) return new List<Path>();

            return _connections
                .SelectMany(c => c.Paths(destination, new List<Node>(visitedNodes) { this }))
                .ToList();
        }
    }
}

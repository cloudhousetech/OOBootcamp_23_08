using System.Collections.Generic;
using System.Linq;

namespace OoBootCamp
{
    //Understands hot to get to node and the cost
    internal class Link
    {
        private readonly Node _destination;
        private readonly double _cost;

        public static double TotalCost(IList<Link> links)
        {
            return links.Sum(l => l._cost);
        }
        internal IList<Path> Paths(Node target, List<Node> nodes)
        {
            return _destination.Paths(target, nodes).Select(e => e.Prepend(this)).ToList();
        }
        internal Link(Node destination, double cost)
        {
            _destination = destination;
            _cost = cost;
        }
    }
}

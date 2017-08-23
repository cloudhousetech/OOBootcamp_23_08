using System.Collections.Generic;

namespace OoBootCamp
{
    // ReachablePath understands how to get from a to b

    public class Path
    {
        public static readonly IComparer<Path> LeastCost =
            Comparer<Path>.Create((left, right) => left.Cost().CompareTo(right.Cost()));
        public static readonly IComparer<Path> FewestHops =
            Comparer<Path>.Create((left, right) => left.HopCount().CompareTo(right.HopCount()));

        private readonly IList<Link> _links = new List<Link>();

        public double Cost()
        {
            return Link.TotalCost(_links);
        }
        public int HopCount()
        {
            return _links.Count;
        }
        internal Path Prepend(Link link)
        {
            _links.Insert(0, link);

            return this;
        }
    }
}

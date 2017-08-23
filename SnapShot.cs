using System;
using System.Collections.Generic;
using System.Linq;

namespace OoBootCamp
{
    public interface SnapShot
    {
        int Count();

    }

    public class CompositeSnapShot : SnapShot
    {
        private readonly IList<SnapShot> _snapshots = new List<SnapShot>();

        public CompositeSnapShot(params SnapShot[] snapshots)
        {
            _snapshots = _snapshots.Concat(snapshots).ToList();
        }
        public int Count() => _snapshots.Sum(s => s.Count()) + 1;
    }

    public class RegistrySnapShot : CompositeSnapShot
    {
        public RegistrySnapShot(params SnapShot[] snapshots) : base(snapshots)
        {
        }
    }

    public class DirectorySnapShot : CompositeSnapShot
    {
        public DirectorySnapShot(params SnapShot[] snapshots) : base(snapshots)
        {
        }
    }
    public class FileSnapShot : SnapShot
    {
        public int Count()
        {
            return 1;
        }
    }

}

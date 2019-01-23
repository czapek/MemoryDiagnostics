using Microsoft.Diagnostics.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryDiagnostics
{
    [Serializable]
    public class ManagedObject
    {
        public string ObjectName { get; set; }
        public int ObjectCount { get; set; }
        public ulong ObjectSize { get; set; }
        public int ObjectChange { get { return ObjectCount - ObjectCountLast; } }

        [NonSerialized]
        public int ObjectCountLast;
        [NonSerialized]
        public DateTime SnapshotKey;

        public override string ToString()
        {
            return ObjectCount + " " + ObjectName;
        }
    }
}

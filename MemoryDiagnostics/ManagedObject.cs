using Microsoft.Diagnostics.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryDiagnostics
{
    public class ManagedObject
    {
        public string ObjectName { get { return ClrType.Name; } }
        public int ObjectCount { get; set; }
        public int ObjectCountLast { get; set; }
        public ulong ObjectSize { get; set; }
        public int ObjectChange { get { return ObjectCount - ObjectCountLast; } }
        public List<ulong> ObjectPtrs { get; set; }
        public ClrType ClrType { get; set; }

        public override string ToString()
        {
            return ObjectCount + " " + ObjectName;
        }
    }
}

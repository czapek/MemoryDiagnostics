using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryDiagnostics
{
    public struct ManagedObject
    {
        public string ObjectName { get; set; }
        public int ObjectCount { get; set; }
        public int ObjectChange { get; set; }

        public override string ToString()
        {
            return ObjectCount + " " + ObjectName;
        }
    }
}

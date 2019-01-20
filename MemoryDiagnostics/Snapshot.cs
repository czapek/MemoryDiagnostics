﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryDiagnostics
{
    public class Snapshot
    {
        public SortedDictionary<string, ManagedObject> ManagedObjectDic { get; set; }
        public int Position { get; set; }
        public ulong MemoryEphemeral { get; set; }
        public ulong MemoryLargeObject { get; set; }
        public ulong MemoryReserved { get; set; }
        public ulong MemoryRegular { get; set; }
        public ulong MemoryOther { get; set; }
        public long MemoryPrivateBytes { get; set; }
        public DateTime Date { get; set; }
    }
}
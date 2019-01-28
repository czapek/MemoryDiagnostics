using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryDiagnostics
{
    public class StringObjectHelper : IEquatable<StringObjectHelper>
    {
        public ulong Size;
        public String String;
        public List<ulong> PtrList = new List<ulong>();

        public override int GetHashCode()
        {
            return String.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("{0} {1:n0} {2}", PtrList.Count, Size, String.Length > 50 ? String.Substring(0, 50) : String);
        }

        bool IEquatable<StringObjectHelper>.Equals(StringObjectHelper other)
        {
            return other.String == this.String;
        }
    }
}

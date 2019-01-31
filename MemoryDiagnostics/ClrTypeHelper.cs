using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryDiagnostics
{
    [Serializable]
    public class ClrTypeHelper : IEquatable<ClrTypeHelper>
    {
        public ulong Ptr;
        public string Name;
        [NonSerialized]
        public string ObjectInfo;
        [NonSerialized]
        public TreeNode TreeNode;
        public ulong Size;
        public HashSet<ClrTypeHelper> Parents = new HashSet<ClrTypeHelper>();

        bool IEquatable<ClrTypeHelper>.Equals(ClrTypeHelper other)
        {
            return other.Ptr == this.Ptr;
        }

        public override int GetHashCode()
        {
            return Ptr.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("{0} {1:X}", this.Name, this.Ptr);
        }
    }
}

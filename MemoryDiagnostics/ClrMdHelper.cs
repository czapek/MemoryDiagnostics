using Microsoft.Diagnostics.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryDiagnostics
{
    public static class ClrMdHelper
    {
        public static List<ClrTypeHelper> GetPtrsForObjectName(ClrRuntime runtime, string objectName)
        {
            List<ClrTypeHelper> ptrList = new List<ClrTypeHelper>();
            if (runtime.Heap.CanWalkHeap)
            {
                foreach (var ptr in runtime.Heap.EnumerateObjectAddresses())
                {
                    var type = runtime.Heap.GetObjectType(ptr);
                    if (type == null || type.Name != objectName)
                    {
                        continue;
                    }

                    ptrList.Add(new ClrTypeHelper()
                    {
                        Ptr = ptr,
                        Name = type.Name,
                        Size = type.GetSize(ptr)
                    });
                }
            }

            return ptrList;
        }

        public static void BuildFullRetentionTree(ClrRuntime runtime, ClrTypeHelper clrTypeHelper)
        {
            Stack<ulong> stack = new Stack<ulong>();
            foreach (var root in runtime.Heap.EnumerateRoots())
            {
                stack.Clear();
                stack.Push(root.Object);
                ClrTypeHelper lastCrlTypeHelper = clrTypeHelper;

                if (GetPathToObject(runtime.Heap, clrTypeHelper.Ptr, stack, new HashSet<ulong>()))
                {
                    foreach (var address in stack)
                    {
                        var t = runtime.Heap.GetObjectType(address);
                        if (t == null)
                        {
                            continue;
                        }

                        String s = String.Format("{0} - {1} - {2} bytes", address, t.Name, t.GetSize(address));

                        if (clrTypeHelper.Ptr == address)
                            continue;

                        ClrTypeHelper c = new ClrTypeHelper()
                        {
                            Ptr = address,
                            Name = t.Name,
                            Size = t.GetSize(address)
                        };

                        ClrTypeHelper stringObjectFound;
                        if (lastCrlTypeHelper.Parents.TryGetValue(c, out stringObjectFound))
                        {
                            lastCrlTypeHelper = stringObjectFound;
                        }
                        else
                        {
                            lastCrlTypeHelper.Parents.Add(c);
                            lastCrlTypeHelper = c;
                        }
                    }
                }
            }
        }

        private static bool GetPathToObject(ClrHeap heap, ulong objectPointer, Stack<ulong> stack, HashSet<ulong> touchedObjects)
        {
            // Start of the journey - get address of the first objetc on our reference chain
            var currentObject = stack.Peek();

            // Have we checked this object before?
            if (!touchedObjects.Add(currentObject))
            {
                return false;
            }

            // Did we find our object? Then we have the path!
            if (currentObject == objectPointer)
            {
                return true;
            }


            // Enumerate internal references of the object
            var found = false;
            var type = heap.GetObjectType(currentObject);
            if (type != null)
            {
                type.EnumerateRefsOfObject(currentObject, (innerObject, fieldOffset) =>
                {
                    if (innerObject == 0 || touchedObjects.Contains(innerObject))
                    {
                        return;
                    }

                    // Push the object onto our stack
                    stack.Push(innerObject);
                    if (GetPathToObject(heap, objectPointer, stack, touchedObjects))
                    {
                        found = true;
                        return;
                    }

                    // If not found, pop the object from our stack as this is not the tree we're looking for
                    stack.Pop();
                });
            }

            return found;
        }

        public static string GetInfoOfObject(ClrRuntime runtime, ulong ptr, ClrType type)
        {
            StringBuilder sb = new StringBuilder();
            if (type == null)
                type = runtime.Heap.GetObjectType(ptr);

            sb.AppendFormat("{1} {0:X}\r\n", ptr, type.Name);

            foreach (ClrInstanceField f in type.Fields)
            {
                object value = "?";
                if (f.ElementType != ClrElementType.Unknown)
                {
                    value = f.GetValue(ptr);

                    if (f.ElementType == ClrElementType.Object)
                    {
                        if ((UInt64)value == 0)
                            value = "ref null";
                        else
                            value = "ref " + ((UInt64)value).ToString("X");
                        //ClrType refType = runtime.Heap.GetObjectType((UInt64)value);
                    }

                    if (f.ElementType == ClrElementType.Struct)
                    {
                        foreach (ClrInstanceField fs in f.Type.Fields)
                        {
                            //TODO struct?
                            value = "struct";
                        }

                        //    if (f.ElementType == ClrElementType.Struct && f.Type.Name == "System.DateTime")
                        //    {
                        //        foreach (ClrInstanceField fd in f.Type.Fields)
                        //            if (fd.Name == "dateData")
                        //            {
                        //                //https://stackoverflow.com/questions/10759287/interpret-uint64-datedata-in-net-datetime-structure
                        //                //http://www.dotnetframework.org/default.aspx/DotNET/DotNET/8@0/untmp/whidbey/REDBITS/ndp/clr/src/BCL/System/DateTime@cs/1/DateTime@cs
                        //                UInt64 dateData = (UInt64)fd.GetValue(fd.GetAddress(ptr));
                        //                Int64 ticks = (Int64)(dateData & (UInt64)0x3FFFFFFFFFFFFFFF);
                        //                //TODO klappt nicht so recht
                        //                //value = DateTime.FromBinary(ticks);
                        //            }
                        //    }
                    }
                }
                sb.AppendFormat("\t{0}: {1} [{2}]\r\n", f.Name.StartsWith("<") ? f.Name.Replace(">k__BackingField", "").TrimStart('<') : f.Name, value == null ? "null" : value, f.Type.Name);
            }
            return sb.ToString();
        }      
    }
}

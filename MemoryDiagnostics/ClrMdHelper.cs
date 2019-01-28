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
    }
}

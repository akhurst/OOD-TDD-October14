using System.Collections.Generic;

namespace OODTDD.Monopoly
{
    public static class LinkedListNodeExtensions
    {
        public static LinkedListNode<T> CircularNext<T>(this LinkedListNode<T> list)
        {
            if (list.Next == null)
            {
                return list.List.First;
            }

            return list.Next;
        }
    }
}
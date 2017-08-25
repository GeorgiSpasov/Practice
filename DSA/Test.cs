using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA
{
    class Test
    {
        static void Main(string[] args)
        {

            LinkedList<string> linkedList = new LinkedList<string>();
            LinkedListNode<string> first = new LinkedListNode<string>("first");
            linkedList.AddFirst(first);
            linkedList.AddAfter(linkedList.Find("first"), "after first");
            linkedList.AddLast("last");
            int counter = 0;
            var result = linkedList.Select(n => $"{counter++}. {n}").ToList();

            Console.WriteLine(string.Join(", ",result));

            SortedSet<string> set = new SortedSet<string>();

        }
    }
}

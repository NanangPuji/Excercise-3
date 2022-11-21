using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Excercise_3
{
    internal class Program
    {
        class Node
        {
            /*creates Node for the cicular nexted list*/
            public int rollNumber;
            public string nama;
            public Node next;
        }
        class CircularList
        {
            Node LAST;
            public CircularList()
            {
                LAST = null;
            }

            static void Main(string[] args)
            {
            }
        }
    }
}

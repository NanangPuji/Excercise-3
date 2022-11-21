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

            //add node 
            public void addnode()
            {
                int number;
                string nm;

                //deklarasi element
                Console.WriteLine("\nMasukkan No.Barang : ");
                number = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\nMasukkan Nama Barang : ");
                nm = Console.ReadLine();

                Node newnode = new Node();

                //membuat penyimpanan
                newnode rollNumnber;
                newnode.nama = nm;

                //if list empty
                if (listempty())
                {
                    newnode.next = newnode;
                    LAST = newnode;
                }

                //mulai proses pengurutan proses pengurutan data
                else if (number < LAST.next.rollNumber)//node dari kiri
                {
                    newnode.next = LAST.next;
                    LAST.next = newnode;
                }
                else if (number > LAST.rollNumber)//node dari kanan
                {
                    newnode.next = LAST.next;
                    LAST.next = newnode;
                    LAST = newnode;
                }
                //menambahkan node ditengah-tengah
                else
                {
                    Node current, previous;
                    current = previous = LAST.next;

                    int i = 0;
                    while (i < number - 1)
                    {
                        previous = current;
                        current = current.next;
                        i++;
                    }
                    newnode.next = current;
                    previous.next = newnode;
                }
            }
            //menambahkan method mencari data
            public bool Search(int thn, ref Node previous, ref Node current)
            {
                for (previous = current = LAST.next; current != LAST; previous = current, current = current.next)
                {
                    if (thn == current.rollNumber)
                        return true;//return true if the node is found
                }
                if (thn == LAST.rollNumber)
                    return true;
                else
                    return (false);
            }
            //menambahkan method delete
            public bool delNode(int number)
            {
                Node previous, current;
                previous = current = LAST.next;

                //mengecek spesifikasi isi nod sekarang masih ada didalam list atau tidak
                if (Search(number, ref previous, ref current) == false)
                    return false;
                previous.next = current.next;

                //proses mendelete data
                if (LAST.next.rollNumber == LAST.rollNumber)
                {
                    LAST.next = null;
                    LAST = null;
                }
                static void Main(string[] args)
                {
                }
            }
        }
    }
}

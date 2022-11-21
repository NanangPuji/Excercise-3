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
                else if (number == LAST.rollNumber)
                {
                    LAST.next = current.next;
                }
                else
                {
                    LAST = LAST.next;
                }
                return true;
            }
            //mendisplay atau traverse semua node di list
            public void display()
            {
                //if list empty
                if (listempty())
                    Console.WriteLine("\nList Is Empty : ");
                //menampilkan data
                else
                {
                    Console.WriteLine("\nRecord in the list are : ");
                    Node currentNode;

                    currentNode = LAST.next;
                    while (currentNode != LAST)
                    {
                        Console.Write(currentNode.rollNumber + " " + currentNode.nama + "\n");
                        currentNode = currentNode.next;
                    }
                    Console.Write(LAST.rollNumber + " " + LAST.nama + "\n");
                }
            }
            public bool listempty()
            {
                if (LAST == null)
                    return true;
                else
                    return false;
            }
        }
        class Program
        {
            public void Demo()
            {
                Console.WriteLine("========================");
                Console.WriteLine("----DATA BARANG ANDA----");
                Console.WriteLine("========================");
                Console.WriteLine("1. Add a record to the list");
                Console.WriteLine("2. Delete a record from the list");
                Console.WriteLine("3. View all records in list");
                Console.WriteLine("4. Search for a record in the list");
                Console.WriteLine("5. Exit\n");
                Console.WriteLine("Enter your choice (1-6): ");
            }
            static void Main(string[] args)
            {
                Program menu = new Program();
                CircularLinkedList data = new CircularLinkedList();
                Node a = new Node();

                while (true)
                {
                    try
                    {
                        Console.WriteLine();
                        menu.Demo();
                        char ch = Convert.ToChar(Console.ReadLine());

                        switch (ch)
                        {//add data
                            case '1':
                                {
                                    data.addnode();
                                }
                                break;
                            //del node
                            case '2':
                                {
                                    if (data.listempty())
                                    {
                                        Console.WriteLine("\nlist is empty");
                                        break;
                                    }
                                    //pencarian node list yang akan didelete
                                    Console.Write("\nMasukkan No.Barang yang akan dihapus : ");
                                    int value = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine();

                                    //output data yang didelete node
                                    if (data.delNode(value) == false)
                                        Console.WriteLine("\nData tidak ditemukan");
                                    else
                                        Console.WriteLine("Data Barang dengan No" + value + "dihapus dari list");
                                }
                                break;
                            //display
                            case '3':
                                {
                                    data.display();
                                }
                                break;
                            case '4':
                                {
                                    //if list empyty
                                    if (data.listempty() == true)
                                    {
                                        Console.WriteLine("\nList is empty");
                                        break;
                                    }

                                    //proses pencarian
                                    Node previous, current;
                                    previous = current = null;

                                    Console.Write("\nMasukkan tahun pembelian yang dicari : ");
                                    int value = Convert.ToInt32(Console.ReadLine());

                                    //memulai pencarian
                                    if (data.Search(value, ref previous, ref current) == false)
                                        Console.WriteLine("\nData tidak ditemukan");
                                    else//mencari output
                                    {
                                        Console.WriteLine("\n====================");
                                        Console.WriteLine("----Data ditemukan----");
                                        Console.WriteLine("====================\n");
                                        Console.WriteLine("No.Barang       : " + current.rollNumber);
                                        Console.WriteLine("Nama Barang     : " + current.nama);
                                    }
                                }
                                break;
                            case '5':
                                return;
                            default:
                                {
                                    Console.WriteLine("\ninvalid Option");
                                    Console.ReadKey();
                                    break;
                                }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
        }
    }
}
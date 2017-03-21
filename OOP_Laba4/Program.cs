using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Laba4
{
    class Program
    {
        static void Main(string[] args)
        {
            ColectionType<String> s = new ColectionType<String>();
            s.Add("America");
            s.Add("Belarus");
            s.Add("England");
            s.Add("Germany");
            s.Add("Russia");
            s.Add("China");
            s.Add("Japan");
            s.Print();
            s.WriteToFile("E:\\OOP4.txt");
            s.RemoveAt(2);
            Console.WriteLine("Delete item № 3");
            s.Print();
            s.RemoveRang(1, 3);
            Console.WriteLine("Delete item 2 - 4");
            s.Print();
            s.WriteToFile("R:\\OOO.txt");
            Console.WriteLine("Insert");
            s.Insert(4, "Columbiya");
            s.Insert(2, "Korea");
            s.Insert(0, "Poland");
            s.Print();
            s.WriteToFile("E:\\OOP4.txt");
            Console.WriteLine("Indexator get");
            Console.WriteLine("№2 {0}", s[1]);
            Console.WriteLine("№4 {0}", s[3]);
            Console.WriteLine("Indexator set №1 & №3");
            s[0] = "Pompei";
            s[2] = "Australia";
            s.Print();

            ColectionType<Rectangle> R = new ColectionType<Rectangle>();
            R.Add(new Rectangle(2, 7));
            R.Add(new Rectangle(3, 2));
            R.Add(new Rectangle(5, 5));
            R.Add(new Rectangle(4, 4));
            R.Add(new Rectangle(8, 2));
            R.Add(new Rectangle(10, 10));
            R.Print();
            Console.WriteLine("Sotr Rectangels from S");
            R.Sort();
            foreach (Rectangle i in R)//Вывод колекции через foreach
                Console.Write(i + "\n");
            Console.WriteLine("\nWork with array of ColectionType");
            ColectionType<String>[] humans =
                {
                 new ColectionType<String>(new String[]{"ct1 Evlampiya","ct1 Vanya"}),
                 new ColectionType<String>(new String[]{"ct2 Sasha","ct2 Vlad","ct2 Maxim","ct2 Egor"}),
                 new ColectionType<String>(new String[]{"ct3 Tanya","ct3 Vera","ct3 Margorita"})
                };
            foreach (var i in humans)
                i.Print();
            Console.WriteLine("\nColections where count > 2");
            IEnumerable<ColectionType<String>> q1 = from score in humans
                                                    where score.getCount() > 2
                                                    select score;
            foreach (var i in q1)
                i.Print();
            Console.WriteLine("\nColections where count is MAX");
            IEnumerable<ColectionType<String>> q2 = humans
                                                    .OrderByDescending(i => i.getCount())
                                                    .Take(1);
            foreach (var i in q2)
            {
                Console.WriteLine("\nCount = {0}", i.getCount());
                i.Print();
            }

            Console.WriteLine("\nColections where Like'%anya%'");
            var q3 = humans.Where((score) =>
                                   {
                                       bool tf = false;
                                       foreach (String i in score)
                                           if (i.Contains("anya")) tf = true;
                                       return tf;
                                   }).Select(score => score);

            foreach (var i in q3)
                i.Print();
            LinkedList<String> LL = new LinkedList<String>();
            //for(int i=0;i<6;i++)
            //{
            //    LL.AddFirst(Console.ReadLine());
            //}
            LL.AddFirst("1 One***");
            LL.AddFirst("2 Two****");
            LL.AddFirst("3 Three***");
            LL.AddBefore(LL.Find("2 Two****"),"4 Four****");
            LL.AddAfter(LL.Find("2 Two****"), "5 Five******");
            LL.AddLast("6 Six********");
            Console.WriteLine("\nLinkedList:");
            foreach (var i in LL)
                Console.WriteLine(i);
            Console.WriteLine("\nSorted:");
            foreach (var i in LL.OrderBy(i => i.Length))
                Console.WriteLine(i);
            Console.WriteLine("\nCount string where Length=10 is {0}" ,LL.Where(i => i.Length == 10).Count());
        }
    }
}

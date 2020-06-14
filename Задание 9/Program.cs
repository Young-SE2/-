using System;

namespace Задание_9
{
    class Point
    {
        public int data;
        public Point next, pred;
        public Point(int d)
        {
            data = d;
            next = null;
            pred = null;
        }
        public override string ToString()
        {
            return data + " ";
        }
    }
    class Program
    {
        static Point MakePoint(int d)
        {
            Point p = new Point(d);
            return p;
        }
        static Point MakeList(int size, Point l, int c)
        {
            int count = c;
            Point beg = MakePoint(size - count);
            if (count < size)
            {
                l.next = beg;
                beg.pred = l;
                l = beg;
                count++;
                MakeList(size, l, count);
            }
            return beg;
        }
        static void PrintList(Point beg)
        {
            Point p = beg;
            while (p != null)
            {
                Console.Write(p + "\t");
                p = p.next;
            }
            Console.WriteLine();
        }
        static int EnterSize()
        {
            bool ok;
            int s = 0;
            do
            {
                Console.WriteLine("Введите размер массива");
                ok = Int32.TryParse(Console.ReadLine(), out s);
                if (!ok)
                    Console.WriteLine("Неверные данные");
                else if (s <= 0)
                {
                    Console.WriteLine("Введите размер массива");
                }
            } while (!ok || s <= 0);
            return s;
        }
        static Point DeleteEl(Point e, Point beg, int sure, Point first)
        {
            if (first == null)
            {
                Console.WriteLine("Массив мустой");
                return first;
            }
            else if (beg.next == null && beg.data != e.data && sure == 0)
            {
                Console.WriteLine("Такого элемента нет");
                return first;
            }
            if (first.data == e.data)
            {
                sure++;
                beg = beg.next;
                first = beg;
            }
            else if (beg.data != e.data)
            {
                beg = beg.next;
                DeleteEl(e, beg, sure, first);
            }
            else if (beg.data == e.data)
            {
                sure++;
                beg.pred.next = beg.next;
            }
            else if (beg.data == e.data && beg.next == null)
            {
                beg = null;
            }
            return first;
        }
        static void Search(Point beg, int e, int count)
        {
            if (beg == null)
            {
                Console.WriteLine("Такого элемента нет");
            }
            else if (beg.data != e)
            {
                beg = beg.next;
                count++;
                Search(beg, e, count);
            }
            else if (beg.data == e)
            {
                Console.WriteLine("Индекс элемента - {0}", count);
            }
        }
        static int ChooseAction()
        {
            bool ok;
            int c;
            do
            {
                Console.WriteLine("Что вы хотите сделать?");
                Console.WriteLine("1. Удалить элемент из массива");
                Console.WriteLine("2. Поиск элемента в массиве");
                ok = Int32.TryParse(Console.ReadLine(), out c);
                if (!ok)
                    Console.WriteLine("Неверные данные");
                else if (c != 1 && c != 2)
                {
                    Console.WriteLine("Прости, но такого пункта нет(");
                }
            } while (!ok || (c != 1 && c != 2));
            return c;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать");
            int end = 0;
            int size = EnterSize();
            Point begining = new Point(1);
            Point thislist = MakeList(size, begining, 0);
            PrintList(thislist);
            do
            {
                int num = ChooseAction();
                switch (num)
                {
                    case 1:
                        Console.WriteLine("Какой элемент хотите удалить?");
                        Point that = new Point(Int32.Parse(Console.ReadLine()));
                        Console.WriteLine();
                        thislist = DeleteEl(that, thislist, 0, thislist);
                        PrintList(thislist);
                        break;
                    case 2:
                        Console.WriteLine("Номер какого элемента вы хотите увидеть?");
                        int index = Int32.Parse(Console.ReadLine());
                        Search(thislist, index, 0);
                        break;
                }
                Console.WriteLine("Если вы хотите выйти из программы введите выход или exit.");
                string answer = Console.ReadLine();
                if (answer == "exit" || answer == "выход")
                    end++;
            } while (end == 0);
        }
    }
}

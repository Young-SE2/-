using System;

namespace Задание_4
{
    class Program
    {
        static void Main(string[] args)
        {
            double s = 0;
            double a = 0.5;
            int i = 1;
            double e = 0;
            Console.WriteLine("Введите e : ");
            bool check1 = false;
            string rez = Console.ReadLine();
            while (!check1)
            {
                if (check1 = double.TryParse(rez, out e) && (e > 0)) check1 = true;
                else
                {
                    Console.WriteLine("Попробуй снова!");
                    Console.WriteLine("Введите e : ");
                    rez = Console.ReadLine();
                }
            }

                while (a > e)
                {
                    i++;
                    s += a;
                    a = 1.0 / (i * (i + 1.0));
                }
                Console.WriteLine(s);
            Console.ReadLine();
        }
    }
}

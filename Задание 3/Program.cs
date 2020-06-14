using System;

namespace Задание_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите координату х : ");
            double x = 0;
            bool check1 = false;
            string rez = Console.ReadLine();
            while (!check1)
            {
                if (check1 = double.TryParse(rez, out x)) check1 = true;
                else
                {
                    Console.WriteLine("Попробуй снова!");
                    Console.Write("Введите координату х : ");
                    rez = Console.ReadLine();
                }
            }
            Console.Write("Введите координату y : ");
            double y = 0;
            bool check2 = false;
            string rez2 = Console.ReadLine();
            while (!check2)
            {
                if (check2 = double.TryParse(rez2, out y)) check2 = true;
                else
                {
                    Console.WriteLine("Попробуй снова!");
                    Console.Write("Введите координату y : ");
                    rez2 = Console.ReadLine();
                }
            }

            if (y >= 0 && y <= -x && x >= (y - 3) / 2 || y <= 0 && x >= (y - 3) / 2 && y >= (x - 1) / 3)
                Console.WriteLine("Входит в фигуру");
            else
                Console.WriteLine("Не входит в фигуру");

            Console.ReadLine();
        }
    }
}

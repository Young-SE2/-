using System;
using System.Collections.Generic;

namespace Задание_6
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            double a1, a2, a3;
            int N;
            double E;

            Console.WriteLine("Введите а1 (первый элемент последовательности)");
            a1 = EnterDouble();
            Console.WriteLine("Введите а2 (второй элемент последовательности)");
            a2 = EnterDouble();
            Console.WriteLine("Введите а3 (третий элемент последовательности)");
            a3 = EnterDouble();
            Console.WriteLine("Введите N (кол-во элементов последовательности)");
            N = EnterInt(3, 100);
            Console.WriteLine("Введите E (максимальная разность между a(k) - a(k-1))");
            E = EnterDouble(0, double.MaxValue);

            double[] arr = new double[N];
            arr[0] = a1;
            arr[1] = a2;
            arr[2] = a3;

            var indexesOfPars = Solve(ref arr, E);

            Console.WriteLine("Кол-во пар, удовлетворяющих условию |ак – ак–1| < E: " + indexesOfPars.Count);

            Console.WriteLine("Номера пар, удовлетворяющих условию: ");
            if (indexesOfPars.Count > 0)
            {
                foreach (var index in indexesOfPars)
                {
                    Console.WriteLine($"ak-1: {index[0] + 1} (число {arr[index[0]]})  ak: {index[1] + 1} (число {arr[index[1]]})");
                }
            }
            else
            {
                Console.WriteLine("Пар, удовлетворяющих условию, нет");
            }

            Console.ReadLine();
        }

        public static List<int[]> Solve(ref double[] arr, double E, int i = 1, List<int[]> indexesOfPars = null)
        {
            if (indexesOfPars == null)
            {
                indexesOfPars = new List<int[]>();
            }

            if (i >= 3)
            {
                arr[i] = (arr[i - 1] / 3) + (arr[i - 2] / 2) + ((2 * arr[i - 3]) / 3);
            }

            if (Math.Abs(arr[i] - arr[i - 1]) < E)
            {
                indexesOfPars.Add(new[] { i - 1, i });
            }

            if (i == arr.Length - 1)
            {
                return indexesOfPars;
            }

            return Solve(ref arr, E, ++i, indexesOfPars);
        }

        public static int EnterInt(int min, int max)
        {
            int num;

            while (!int.TryParse(Console.ReadLine(), out num) || num < min || num > max)
            {
                if (num < min || num > max)
                {
                    Console.WriteLine($"Введите целое число от {min} до {max}");
                    continue;
                }
                Console.WriteLine("Введите целое число");
            }

            return num;
        }

        public static double EnterDouble()
        {
            double num;

            while (!double.TryParse(Console.ReadLine(), out num))
            {
                Console.WriteLine("Введите число. Если это дробное число, отделите дробную часть запятой");
            }

            return num;
        }

        public static double EnterDouble(double min, double max)
        {
            double num;

            while (!double.TryParse(Console.ReadLine(), out num) || num < min || num > max)
            {
                if (num < min || num > max)
                {
                    Console.WriteLine($"Введите число от {min} до {max}");
                    continue;
                }
                Console.WriteLine("Введите число. Если это дробное число, отделите дробную часть запятой");
            }

            return num;
        }
    }
}

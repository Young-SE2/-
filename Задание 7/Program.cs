using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_7
{
    class Program
    {
        static void Main(string[] args)
        {
            const int argsCount = 3;
            int[] vector = new int[(int)Math.Pow(2, argsCount)];//всего возможных комбинаций аргументов у функции 2^n
            int count = 1;
            Console.WriteLine("Все немонотонные Булевы функции от {0} аргументов (заданы вектором):\n", argsCount);
            for (int i = 0; i < Math.Pow(2, Math.Pow(2, argsCount)); i++)//всего возможных функций будет 2^(2^n)
            {
                string vectorStr = "";
                for (int j = 0; j < vector.Length; j++)
                    vectorStr += vector[j].ToString();

                if (!isMonotone(vectorStr))
                {
                    Console.WriteLine($"{count++}) " + vectorStr);
                }

                NextVector(ref vector);
            }
            Console.ReadKey();
        }

        //универсальный метод определения монотонности функции от n аргументов (сравниваются наборы значений).
        static bool isMonotone(string vectorStr)
        {
            string a = vectorStr.Substring(0, vectorStr.Length / 2);
            string b = vectorStr.Substring(vectorStr.Length / 2, vectorStr.Length / 2);

            for (int i = 0; i < a.Length; i++) //a и b всегда имеют одинаковую длину
                if (a[i] > b[i])
                    return false;

            if (a.Length != 1)
                return isMonotone(a) && isMonotone(b);

            return true;
        }

        static void NextVector(ref int[] vector)
        {
            vector[vector.Length - 1]++;

            for (int i = vector.Length - 1; i >= 1; i--)
            {
                if (vector[i] == 2)
                {
                    vector[i] = 0;
                    vector[i - 1]++;
                }
                else
                    break;
            }
        }
    }
}
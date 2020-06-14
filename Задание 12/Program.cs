using System;

namespace Задание_12
{
    class Program
    {
        // Сортировка перемешиванием
        static int[] ShakerSort(int[] mass) //n^2
        {
            int left = 0,
                right = mass.Length - 1,
                countComp = 0,
                countEx = 0;
            bool flag = true;

            while (left <= right && flag)
            {
                flag = false;
                for (int i = left; i < right; i++)
                {
                    countComp++;
                    if (mass[i] > mass[i + 1])
                    {
                        Swap(mass, i, i + 1);
                        countEx++;
                        flag = true;
                    }
                }
                right--;
                for (int i = right; i > left; i--)
                {
                    countComp++;
                    if (mass[i - 1] > mass[i])
                    {
                        Swap(mass, i - 1, i);
                        countEx += 2;
                        flag = true;
                    }
                }
                left++;
            }
            Console.WriteLine("Количество сравнений: " + countComp);
            Console.WriteLine("Количество пересылок: " + countEx);
            return mass;
        }

        // Сортировка Шелла
        static int[] ShellaSort(int[] mass) //n^2
        {
            int j;
            int countCompares = 0,
                countExchanges = 0;
            int step = mass.Length / 2;
            while (step > 0)
            {
                for (int i = 0; i < (mass.Length - step); i++)
                {
                    j = i;
                    while (j >= 0)
                    {
                        if (mass[j] < mass[j + step])
                        {
                            countCompares++;
                            break;
                        }

                        countCompares++;
                        Swap(mass, j, j + step);
                        j -= step;
                        countExchanges += 2;
                    }
                }

                step = step / 2;
            }

            Console.WriteLine("Количество сравнений: " + countCompares);
            Console.WriteLine("Количество пересылок: " + countExchanges);
            return mass;
        }

        static void Swap(int[] mass, int i, int j)
        {
            int temp = mass[i];
            mass[i] = mass[j];
            mass[j] = temp;
        }

        static void ShowArray(int[] mass)
        {
            for (int i = 0; i < mass.Length; i++)
            {
                Console.Write(mass[i] + " ");
            }

            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            ///////////////////////////////////
            int[] massUnsorted = { 44, 55, 12, 42, 94, 18, 6, 67, 3, 15, 14, 49, 115, 187, 144, 1, 13, 428, 2, 45, 18, 33 };
            int[] massUnsorted1 = { 44, 55, 12, 42, 94, 18, 6, 67, 3, 15, 14, 49, 115, 187, 144, 1, 13, 428, 2, 45, 18, 33 };
            Console.WriteLine("Сортировка неупорядоченных массивов:");
            Console.WriteLine("Сортировка перемешиванием:");
            massUnsorted1 = ShakerSort(massUnsorted1);
            ShowArray(massUnsorted1);
            Console.WriteLine("Сортировка Шелла:");
            massUnsorted = ShellaSort(massUnsorted);
            ShowArray(massUnsorted);
            Console.WriteLine();
            ///////////////////////////////////
            int[] sort = { 1, 2, 3, 6, 12, 13, 14, 15, 18, 18, 33, 42, 44, 45, 49, 55, 67, 94, 115, 144, 187, 428 };
            int[] sort1 = { 1, 2, 3, 6, 12, 13, 14, 15, 18, 18, 33, 42, 44, 45, 49, 55, 67, 94, 115, 144, 187, 428 };
            Console.WriteLine("Сортировка массивов, упорядоченных по возрастанию:");
            Console.WriteLine("Сортировка перемешиванием:");
            sort = ShakerSort(sort);
            ShowArray(sort);
            Console.WriteLine("Сортировка Шелла:");
            sort = ShellaSort(sort);
            ShowArray(sort);
            Console.WriteLine();
            ////////////////////////////////////
            int[] sortedDown = { 428, 187, 144, 115, 94, 67, 55, 49, 45, 44, 42, 33, 18, 18, 15, 14, 13, 12, 6, 3, 2, 1 };
            int[] sortedDown1 = { 428, 187, 144, 115, 94, 67, 55, 49, 45, 44, 42, 33, 18, 18, 15, 14, 13, 12, 6, 3, 2, 1 };
            Console.WriteLine("Сортировка массивов, упорядоченных по убыванию:");
            Console.WriteLine("Сортировка перемешиванием:");
            sortedDown = ShakerSort(sortedDown);
            ShowArray(sortedDown);
            Console.WriteLine("Сортировка Шелла:");
            sortedDown1 = ShellaSort(sortedDown1);
            ShowArray(sortedDown1);
            /////////////////////////////////////
            Console.ReadLine();
        }
    }
}

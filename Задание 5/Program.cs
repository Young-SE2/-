using System;

namespace Задание_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите порядок");
            Enter();
        }

        static int[,] DeleteString(int[,] table, int strings, int columns, int num)
        {
            int[,] temp = new int[strings - 1, columns];
            int i, j;
            int index = 0;
            for (i = 0; i < strings; i++)
            {
                if (i == num)
                {
                    continue;
                }
                else
                {
                    for (j = 0; j < columns; j++)
                    {
                        temp[index, j] = table[i, j];
                    }
                    index++;
                }

            }
            return temp;
        }

        static int[,] DeleteRow(int[,] matrix, int pos)
        {
            int[,] tmp = new int[matrix.GetLength(0), matrix.GetLength(1) - 1];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < pos; j++)
                {
                    tmp[i, j] = matrix[i, j];
                }
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = pos; j < matrix.GetLength(1) - 1; j++)
                {
                    tmp[i, j] = matrix[i, j + 1];
                }
            }
            return tmp;
        }
        static void Print(int[,] table, int strings, int columns)
        {

            for (int i = 0; i < strings; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(table[i, j] + "  ");
                }
                Console.WriteLine();
            }
        }

        static void Enter()
        {
            int deleterow;
            int deletestring;
            int strings = 0;
            int columns = 0;
            try
            {
                Random rnd = new Random();
                strings = Int32.Parse((Console.ReadLine()));
                columns = strings;
                int[,] table = new int[strings, columns];
                int i, j;
                for (i = 0; i < strings; i++)
                {
                    for (j = 0; j < columns; j++)
                    {
                        table[i, j] = rnd.Next(1, 10);
                    }
                }
                Print(table, strings, columns);
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                Console.WriteLine("Какую строку нужно удалить (от 1 до {0}):", strings);
                deletestring = Convert.ToInt32(Console.ReadLine());
                if (deletestring > 0 && deletestring <= strings)
                {
                    Console.WriteLine("Полученный массив:");
                    table = DeleteString(table, strings, columns, deletestring - 1);
                    strings--;
                    Print(table, strings, columns);
                }
                else
                {
                    Console.WriteLine("Попробуйте снова");
                    Console.Clear();
                    Enter();
                }

                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                Console.WriteLine("Какой столбец нужно удалить (от 1 до {0}):", columns);
                deleterow = Int32.Parse((Console.ReadLine()));
                if (deleterow > 0 && deleterow <= columns)
                {
                    Console.WriteLine("Полученный массив:");
                    table = DeleteRow(table, deleterow - 1);
                    columns--;
                    Print(table, strings, columns);
                }
                else
                {
                    Console.WriteLine("Попробуйте снова");
                    Console.Clear();
                    Enter();
                }
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            }
            catch (Exception)
            {
                Console.WriteLine("Попробуйте снова");
                Console.Clear();
                Enter();
            }

        }
    }
}

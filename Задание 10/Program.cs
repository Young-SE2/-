using System;

namespace Задание_10
{
    class Program
    {
        static void Main(string[] args)
        {
            PointTree tree = null;

            ShowMenu(tree);
        }
        static void ShowMenu(PointTree tree)
        {
            while (true)
            {
                Console.WriteLine();
                int min = 1;
                int max = 4;

                Console.WriteLine(@"Выберите действие:");
                Console.WriteLine("1) Создание сбалансированного дерева");
                Console.WriteLine("2) Печать дерева");
                Console.WriteLine("3) Добавить элемент в сбалансированное дерево");
                Console.WriteLine("4) Выход из программы");

                int method = InputInt(min, max);

                Console.Clear();

                switch (method)
                {
                    case 1:
                        Console.WriteLine("Введите число элементов дерева от 0 до 50:");
                        tree = PointTree.IdealTree(InputInt(0, 50));
                        Console.WriteLine("Дерево создано");
                        break;
                    case 2:
                        if (tree == null)
                        {
                            Console.WriteLine("Дерево пустое");
                            break;
                        }

                        PointTree.Print(tree);
                        break;
                    case 3:
                        Console.WriteLine("Введите элемент для добавления от -2000 до 2000:");
                        tree = PointTree.Add(tree, InputInt(-2000, 2000));
                        Console.WriteLine("Элемент добавлен");

                        break;
                    case 4:
                        return;
                }
            }
        }

        private static int InputInt(int min, int max)
        {
            int number;

            while (!int.TryParse(Console.ReadLine(), out number) ||
                   !(number >= min && number <= max))
            {
                Console.Error.WriteLine($"Введите целое число от {min} до {max}");
            }

            return number;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Задание_10
{

    public class PointTree
    {
        public double data;

        // Адрес левого поддерева
        public PointTree left;

        // Адрес правого поддерева
        public PointTree right;

        static private Random rand = new Random();

        public PointTree(double num)
        {
            data = num;
            left = null;
            right = null;
        }

        public override string ToString()
        {
            return data + " ";
        }

        public static void Print(PointTree p, int l = 0)
        {
            if (p != null)
            {
                // Переход к левому поддереву
                Print(p.left, l + 3);

                for (int i = 0; i < l; i++)
                {
                    Console.Write(" ");
                }

                Console.WriteLine(p.data);

                // Переход к правому поддереву
                Print(p.right, l + 3);
            }
        }

        static public int CountElements(PointTree p)
        {
            if (p == null || p.left == null && p.right == null)
            {
                return 1;
            }

            int left = p.left != null ? CountElements(p.left) : 0;
            int right = p.right != null ? CountElements(p.right) : 0;

            return left + right + 1;
        }

        public static int Height(PointTree point)
        {
            if (point == null)
            {
                return 0;
            }

            // Находим высоту правой и левой ветки, и из них берем максимальную
            return 1 + Math.Max(Height(point.left), Height(point.right));
        }

        public static PointTree Add(PointTree root, double num)
        {
            if (root == null)
            {
                return new PointTree(num);
            }

            bool isExist = num == root.data;

            if (isExist)
            {
                Console.WriteLine("Объект с таким числом уже есть в дереве: добавление невозможно");

                return root;
            }

            if (Height(root.left) < Height(root.right))
            {
                root.left = Add(root.left, num);
            }
            else if (Height(root.left) > Height(root.right))
            {
                root.right = Add(root.right, num);
            }
            else
            {
                if (CountElements(root.left) < CountElements(root.right))
                {
                    root.left = Add(root.left, num);
                }
                else
                {
                    root.right = Add(root.right, num);
                }
            }

            return root;
        }

        public static PointTree IdealTree(int size)
        {
            PointTree p;
            int nl, nr;

            if (size == 0)
            {
                return null;
            }

            nl = size / 2;
            nr = size - nl - 1;

            p = new PointTree(rand.Next(-2000, 2000));
            p.left = IdealTree(nl);
            p.right = IdealTree(nr);
            return p;
        }
    }
}

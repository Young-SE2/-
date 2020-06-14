using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] vertexes = VertexGenerator();
            foreach (string v in vertexes)
                Console.Write(v + " ");
            Console.WriteLine();

            string[] lines = LinesGenerator(vertexes);
            foreach (string l in lines)
                Console.Write(l + " ");
            Console.WriteLine();

            int K = GetK();

            if (K <= vertexes.Length)
            {
                int numOfLines = K * (K - 1) / 2;

                int endIndex;
                if (K == 2)
                    endIndex = lines.Length - 1;
                else
                    endIndex = lines.Length - K;

                GetCombinations(lines, 0, endIndex, "", K, numOfLines);

                if (allCliques == "")
                    Console.WriteLine("There are no cliques!");
                else
                {
                    Console.WriteLine("THE LIST OF CLIQUES:");
                    for (int i = 0; i < allCliques.Length; i++)
                    {
                        if (allCliques[i] != ' ')
                            Console.Write(allCliques[i]);
                        else
                            Console.WriteLine();
                    }
                }
            }
            else
            {
                Console.WriteLine("Impossible!");
            }

            Console.ReadLine();
        }

        public static int GetK()
        {
            int K;
            bool ok;
            do
            {
                Console.Write("Enter the K: ");
                ok = Int32.TryParse(Console.ReadLine(), out K);
                if (!ok || K < 2)
                    Console.WriteLine("Input error! K shoud be a natural number greater than 1");
            } while (!ok || K < 2);

            return K;
        }

        public static string allCliques = "";

        public static string GetCombinations(string[] lines, int startIndex, int endIndex, string combination, int K, int numOfLines)
        {
            if (numOfLines == 0)
            {
                Analysis(combination, K);
                return "";
            }
            else
            {
                if (endIndex >= lines.Length)
                    endIndex = lines.Length - 1;

                for (int i = startIndex; i <= endIndex; i++)
                {
                    combination += lines[i];

                    combination += GetCombinations(lines, i + 1, endIndex + 1, combination, K, numOfLines - 1);

                    combination = combination.Substring(0, combination.Length - 2);

                }

                return "";
            }
        }

        public static void Analysis(string combination, int K)
        {
            char[] vertexes = combination.ToCharArray();

            Array.Sort(vertexes);

            bool ok = true;

            for (int i = 0; i < vertexes.Length; i += K - 1)
            {
                for (int j = i; j < i + K - 2; j++)
                {
                    if (vertexes[j] != vertexes[j + 1])
                    {
                        ok = false;
                        break;
                    }
                }

                if (!ok)
                    break;
            }

            if (ok)
            {
                for (int i = 0; i < vertexes.Length; i += K - 1)
                {
                    allCliques += vertexes[i];
                }
                allCliques += " ";
            }
        }

        public static Random rnd = new Random();

        public static string[] VertexGenerator()
        {
            string[] vertexes = new string[rnd.Next(2, 11)];
            for (int i = 0; i < vertexes.Length; i++)
                vertexes[i] = ((char)(i + 65)).ToString();

            return vertexes;
        }

        public static string[] LinesGenerator(string[] vertexes)
        {
            string linesStr = "";

            for (int i = 0; i < vertexes.Length; i++)
            {
                int numOfCurrLines = rnd.Next(0, vertexes.Length - i - 1);

                string currLines = "";

                for (int j = 0; j < numOfCurrLines; j++)
                {
                    int randomIndex;

                    do
                    {
                        randomIndex = rnd.Next(i, vertexes.Length - 1);
                    } while (currLines.Contains(vertexes[randomIndex]) || vertexes[randomIndex] == vertexes[i]);

                    currLines += vertexes[i] + vertexes[randomIndex] + " ";
                }

                linesStr += currLines;
            }

            if (linesStr != "")
                linesStr = linesStr.Remove(linesStr.Length - 1, 1);

            string[] lines = linesStr.Split(' ');

            return lines;
        }
    }
}

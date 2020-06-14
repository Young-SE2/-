using System;
using System.IO;

namespace Задание_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] newText = new string[4];
            int sum = 0;
            using (StreamReader sr = new StreamReader(@"C:/test/INPUT.txt"))
            {
                for (int i = 0; !sr.EndOfStream; i++)
                {
                    newText[i] = sr.ReadLine();
                }
            }

            using (StreamWriter sw = new StreamWriter(@"C:/test/OUTPUT.TXT"))
            {
                sw.WriteLine(sum);
            }
        }
    }
}

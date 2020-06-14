using System;
using System.IO;

namespace Практика
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] newText = new string[2];
            int p = 0;

            using (StreamReader sr = new StreamReader("INPUT.TXT"))
            {
                
                for (int i = 0; !sr.EndOfStream; i++)
                {
                    newText[i] = sr.ReadLine();
                }
            }

            string s1 = newText[0];
            string s2 = newText[1];

            int k = s1.Length;

            char[] chars1 = new char[k];
            char[] chars2 = new char[k];
            chars1 = s1.ToCharArray();
            chars2 = s2.ToCharArray();


            while (s1 != s2)
            {
                char tmp = s2[0];
                for (int i = 0; i < k - 1; i++)
                {
                    chars2[i] = chars2[i + 1];
                }
                chars2[k - 1] = tmp;
                p++;
                ////////////////////////////////////////////////
                if (p == k)
                    break;
                ////////////////////////////////////////////////
            }



            using (StreamWriter sw = new StreamWriter(@"C:/test/OUTPUT.TXT"))
            {
                sw.WriteLine(p);
            }
        }

    }
}

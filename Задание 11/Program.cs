using System;

namespace Задание_11
{
    class Program
    {
        static void Main(string[] args)
        {
            string message;
            string eMessage;
            string dMessage; 
            Console.WriteLine("\nШифрование сообщения");

            Console.WriteLine("Введите сообщение:");
            message = Enter();

            eMessage = GetEMessage(message);

            Console.WriteLine("Начальное сообщение:");
            Console.WriteLine(message);
            Console.WriteLine("Зашифрованное сообщение:");
            Console.WriteLine(eMessage);

            Console.WriteLine("\nШифрование сообщения завершено");

            Console.WriteLine("\nДешифрование сообщения");

            Console.WriteLine("Введите зашифрованное сообщение:");
            message = Enter();

            dMessage = GetDMessage(message);

            Console.WriteLine("Зашифрованное сообщение:");
            Console.WriteLine(eMessage);
            Console.WriteLine("Расшифрованное сообщение:");
            Console.WriteLine(dMessage);

            Console.WriteLine("\nРасшифрование сообщения завершено");

            Console.WriteLine("\nЗавершение работы в приложении по работе с криптографией");
        }

        public static string GetEMessage(string message)
        {
            string eMessage = message[0].ToString();
            for (int i = 1; i < message.Length; i++)
            {
                if (message[i].Equals(message[i - 1]))
                    eMessage += "1";
                else
                    eMessage += "0";
            }
            return eMessage;
        }

        public static string GetDMessage(string message)
        {
            string dMessage = message[0].ToString();
            for (int i = 1; i < message.Length; i++)
            {
                if (message[i].Equals(dMessage[i - 1]))
                    dMessage += "1";
                else
                    dMessage += "0";
            }
            return dMessage;
        }

        private static string Enter()
        {
            string input;
            bool inputCheck;
            do
            {
                input = Console.ReadLine();
                inputCheck = CheckMessage(input) && input.Length >= 2 && input.Length <= 100;
                if (!inputCheck) Console.WriteLine($"Ошибка! Введите сообщение, состоящее из 0 и 1, а также с длиной в пределах от 2 до 100");
            } while (!inputCheck);
            return input;
        }

        public static bool CheckMessage(string message)
        {
            if (message.Length > 100 || message.Length < 2) return false;
            foreach (char s in message)
            {
                if (s != '0' && s != '1')
                {
                    return false;
                }
            }
            return true;
        }
       
    }
}

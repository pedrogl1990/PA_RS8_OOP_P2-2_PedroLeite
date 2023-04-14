using System;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;

namespace D00_Utility
{
    public static class Utility
    {
        public static void SetUnicodeConsole()
        {
            Console.OutputEncoding = Encoding.UTF8;
        }

        public static void WriteTitle(string title)
        {
            Console.WriteLine(new String('-', 50));
            Console.WriteLine(title.ToUpper());
            Console.WriteLine(new String('-', 50));
        }
        public static void WriteTitle(string title, string title2)
        {
            Console.WriteLine(new String('-', 50));
            Console.Write(title.ToUpper());
            BlueText(title2);
            Console.WriteLine();
            Console.WriteLine(new String('-', 50));
        }

        public static void BlockSeparator(string separator)
        {
            Console.WriteLine(separator);
        }

        public static void TerminateConsole()
        {
            Console.Write("\n\nPress any key to exit");
            Console.ReadKey();
            Environment.Exit(0);
        }

        public static bool ValidateNumber0(double valor)
        {
            return valor == 0;
        }

        public static bool ValidateNumberDouble(string valor)
        {
            double result;
            bool converted, check;
            converted = Double.TryParse(valor, out result);

            return check = !ValidateNumber0(result);

        }

        public static void Check(bool checkIf)
        {
            Console.WriteLine(checkIf);
        }

        public static void WriteMessage(string message, string beginTerminator = "", string endTerminator = "")
        {
            Console.Write($"{beginTerminator}{message}{endTerminator}");
        }

        public static void ListMenu(string[] menu, string menuTitle, string menuTitle2)
        {
            WriteTitle(menuTitle, menuTitle2);
            Console.WriteLine();
            for (int i = 0; i < menu.Length; i++)
            {
                Console.WriteLine($"{i + 1} - {menu[i]}");
            }
            Console.WriteLine();
        }

        public static void ValidationError(string inputType, string rule, string title, string title2)
        {
            Console.Clear();
            WriteTitle(title, title2);
            Console.WriteLine($"\nInvalid {inputType}\n");
            RedText(rule);
            Console.ReadLine();
            Console.Clear();
        }

        public static void ReturnMenuMessage(string menu)
        {
            Console.Clear();
            Console.WriteLine($"Redirection you to {menu} menu");
            Console.ReadKey();
        }

        public static void GreenText(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(text);
            Console.ResetColor();
        }

        public static void GreenText2(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public static void BlueText(string text)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(text);
            Console.ResetColor();
        }

        public static void RedText(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(text);
            Console.ResetColor();
        }

        public static void InitialSaudation()
        {
            WriteTitle("RSGymPT - ", "Administration Module");
            Console.WriteLine("\nLet's manage it like hell!\n");
            GreenText("Loading...");
            Thread.Sleep(4000);
            Console.Clear();
        }

        public static void GoodbyeModule()
        {
            Console.Clear();
            Utility.WriteTitle("RSGymPT - ", "Closing App");
            Console.WriteLine("\nThank you for helping managing our App!\n");
            Utility.RedText("Remember: \n");
            Console.Write("Failure is Success in progress!\n(Albert Einstein)");
            Console.ReadKey();
        } 

        public static void SuccesMessage(string title1, string title2, string message1, string message2)
        {
            WriteTitle(title1, title2);
            GreenText($"\n{message1}\n");
            Console.ReadKey();
            Console.WriteLine($"\n{message2}");
            Console.ReadKey();
        }

        public static void ReadMessage(string message1)
        {
            Console.ReadKey();
            Console.WriteLine($"\n{message1}");
            Console.ReadKey();
        }
    }
}

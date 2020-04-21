using System;
using System.Text.RegularExpressions;

namespace BlackJack
{
    public class ConsoleE
    {
        public static void PrintfConColor(int x, int y, string texto, ConsoleColor c)
        {
            ConsoleColor cAux = Console.ForegroundColor;
            Console.ForegroundColor = c;
            Printf(x, y, texto);
            Console.ForegroundColor = cAux;
        }
        public static void Printf(int x, int y, string texto)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(texto);
        }
        public static string Read(
                        int x, int y,
                        ConsoleColor foreGround,
                        ConsoleColor backGround,
                        int tamaño,
                        string patron,
                        bool hidden = false)
        {
            string text = "";
            ConsoleColor fAux = Console.ForegroundColor;
            ConsoleColor bAux = Console.BackgroundColor;
            Console.ForegroundColor = foreGround;
            Console.BackgroundColor = backGround;
            Console.SetCursorPosition(x, y);
            for (int i = 0; i < tamaño; i++) Console.Write(" ");
            Console.SetCursorPosition(x, y);
            do
            {
                Console.CursorVisible = text.Length < tamaño;
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Backspace
                    &&
                    key.Key != ConsoleKey.Enter
                    &&
                    Console.CursorVisible
                    &&
                    Regex.IsMatch(text + key.KeyChar, patron))
                {
                    text += key.KeyChar;
                    Console.Write(hidden ? "*" : key.KeyChar.ToString());
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && text.Length > 0)
                    {
                        text = text.Substring(0, (text.Length - 1));
                        Console.Write("\b \b");
                    }
                    else if (key.Key == ConsoleKey.Enter && Regex.IsMatch(text, patron))
                    {
                        break;
                    }
                }
            } while (true);
            Console.ForegroundColor = fAux;
            Console.BackgroundColor = bAux;
            Console.CursorVisible = false;

            return text;
        }

        public static void Borra(int x, int y, int tamaño)
        {
            Printf(x, y, "".PadLeft(tamaño, ' '));
        }

        public static string ReadWithLabel(
            int x, int y,
            string etiqueta,
            int tamaño,
            string patron)
        {
            Printf(x, y, etiqueta);
            string texto = Read(x + etiqueta.Length, y,
                        ConsoleColor.Black, ConsoleColor.Gray,
                        tamaño, patron);
            Borra(x, y, etiqueta.Length + tamaño);
            return texto;
        }
    }
}

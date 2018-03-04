using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlChat
{
    public static class ConsoleAdditions
    {
        public static void ColoredWrite(ConsoleColor color, string text)
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ForegroundColor = originalColor;
        }

        public static void ColoredWriteLine(ConsoleColor color, string text)
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = originalColor;
        }

        public static void WriteLine(string text)
        {
            Write(text);
            Console.WriteLine();
        }

        public static void Write(string text)
        {
            string[] split = text.Split('§');
            if(split.Count() < 2)
            {
                Console.Write(text);
                return;
            }

            for(int i = 1; i < split.Count(); i++)
            {
                FIX THIS
            }
        }
    }
}

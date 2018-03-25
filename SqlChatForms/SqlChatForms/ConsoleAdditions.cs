using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlChatForms
{
    public static class ConsoleAdditions
    {

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

            if(text[0] == '§')
            {
                CreateColor(split[0]);
            }
            else
            {
                Console.Write(split[0]);
            }

            for(int i = 1; i < split.Count(); i++)
            {
                CreateColor(split[i]);
            }
        }

        private static void CreateColor(string text)
        {
            if (text == string.Empty) return;
            int hex = text[0].ToHexInt();

            if(hex == -1)
            {
                Console.Write(text);
                return;
            }

            Console.ForegroundColor = (ConsoleColor)(hex);
            Console.Write(text.Substring(1));
        }
    }
}

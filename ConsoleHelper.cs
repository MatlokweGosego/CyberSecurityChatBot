using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurityChatBot
{
    public static class ConsoleHelper
    {
        //Colors for the Greetind and Conversation Class
        private const ConsoleColor UserColor = ConsoleColor.DarkMagenta;
        private const ConsoleColor ChatBotColor = ConsoleColor.Cyan;
        private const ConsoleColor WarningColor = ConsoleColor.Red;
        private const ConsoleColor ErrorColor = ConsoleColor.DarkRed;
        private const ConsoleColor AsciiColor = ConsoleColor.DarkBlue;


        //method to set the colors to execute 

        public static void PrintUser(string message)
        {
            Console.ForegroundColor = UserColor;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void PrintChatBot(string message)
        {
            Console.ForegroundColor = ChatBotColor;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void PrintWarning(string message)
        {
            Console.ForegroundColor = WarningColor;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void PrintError(string message)
        {
            Console.ForegroundColor = ErrorColor;
            Console.WriteLine(message);
            Console.ResetColor();
        }

    }
}



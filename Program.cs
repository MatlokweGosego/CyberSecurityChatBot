using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace CyberSecurityChatBot
{ 
    /// <summary> this is the entrypoint of the Cybersecurity Awareness Chatbot console application
    
    public class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Greeting greeting = new Greeting(); // this initializes the greeting module that playes the voicegreeting that welcomes the user, shows the ASCII ART and gets the users name 
            string userName = greeting.GetUserName();// this module gets the users name and handles an empty input by assigning the user as User1, allowa the personalization for all other modules
            Conversation conversation = new Conversation(userName); // this initializes the main conversatin loop and hanldes userinput filtratin and conveys the answers that user needs 
            conversation.Start();
        }
    }
}

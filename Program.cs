using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace CyberSecurityChatBot
{
    public class Program
    {
        static void Main(string[] args)
        {
            Greeting greeting = new Greeting();
            string userName = greeting.GetUserName();
            Conversation conversation = new Conversation(userName);
            conversation.Start();
        }
    }
}
// add comments finish the readme file :) 
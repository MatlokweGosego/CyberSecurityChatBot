using System;
using System.Media;

namespace CyberSecurityChatBot
{
    public  class Greeting
    {
        public Greeting()
        {
            SoundPlayer player = new SoundPlayer(@"C:\Users\RC_Student_lab\source\repos\CyberSecurityChatBot\CyberSecurityAwarenessChatbotGreeting.wav");
            player.PlaySync();
            Console.WriteLine("Hello!Welcome to the Cubersecurity Chatbot. I am your Assistant");
        }
    }
}
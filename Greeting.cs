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
            Console.WriteLine("What is your name?:)");
            string userName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(userName))
            {
                Console.WriteLine("Sorry, I did not quite get that. Can you please write your name below?");
               userName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(userName)) {
                    Console.WriteLine("Thats okay, I will call you User1");
                    userName = "User1";
                }
            }
            Console.WriteLine($"Hello {userName} ! I am your cybersecurity assistant. I am here to educate you about cybersecurity and help keep You safe online!");
            return userName;
        }

    }
}

//we are supposed to add the ASCII image here and ensure that it displays as it should:) After hours? as well as the decorative s
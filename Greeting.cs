using System;
using System.Media;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;

namespace CyberSecurityChatBot
{
    public class Greeting
    {
        public Greeting()
        {
            SoundPlayer player = new SoundPlayer(@"C:\Users\RC_Student_lab\source\repos\CyberSecurityChatBot\CyberSecurityAwarenessChatbotGreeting.wav");
            player.PlaySync();
            DisplayASCIIArt(@"C:\Users\RC_Student_lab\source\repos\CyberSecurityChatBot\abstract-cyber-security-logo-line-blue-light-shield-icon-linear-style-with-eye-lens-camera-combination-isolated-on-blue-background-flat-logo-design-template-element-vector.jpg");
        }
        public string GetUserName()
        {
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
            Console.WriteLine("     ╔════════════════════════════════════════════╗");
            Console.WriteLine($"    ║              Hello {userName}              ║");
            Console.WriteLine("     ╚════════════════════════════════════════════╝");
            Console.WriteLine($"Hello {userName} ! I am your cybersecurity assistant. I am here to educate you about cybersecurity and help keep You safe online!");
            return userName;
        }

        private void DisplayASCIIArt(string imagePath)
        {
            string characters = "@#$%&*!:'.' ";
            try
            {
                Bitmap bitmap = new Bitmap(imagePath);
                int width = 100;
                int height = (bitmap.Height * width) / bitmap.Width;
                Bitmap resized = new Bitmap(bitmap, new Size(width, height));

                for (int y = 0; y < resized.Height; y++)
                {
                    for (int x = 0; x < resized.Width; x++)
                    {
                        Color pixelColor = resized.GetPixel(x, y);
                        int gray = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                        int index = (gray * characters.Length - 1) / 255;
                        Console.Write(characters[index]);
                    }
                    Console.WriteLine();
                }
            }
            catch (Exception ex) {
                Console.WriteLine("Error: " + ex.Message);
            }
    }
    }
}
using System;
using System.Media; // Ths is used for the Soundlaye to lay the audio greeting
using System.Drawing; // this is required for the bitmap to display the ASCII art 
using System.Security.Cryptography.X509Certificates;

namespace CyberSecurityChatBot
{
    public class Greeting
    {
        // this handles the greeting. It plays the voice welcome message, displays the ASCII art and gets the usersname and stores it in the username module
        public Greeting() // the greeting constrcutor that initializes the voice greeting immediately displays the ASCII art after playing the voice greeting
        {
            SoundPlayer player = new SoundPlayer(@"C:\Users\RC_Student_lab\source\repos\CyberSecurityChatBot\CyberSecurityAwarenessChatbotGreeting.wav");
            player.PlaySync(); // stps execution of the application to allow the voice greeting to play n full before the applicatin fully runs. 
            DisplayASCIIArt(@"C:\Users\RC_Student_lab\source\repos\CyberSecurityChatBot\abstract-cyber-security-logo-line-blue-light-shield-icon-linear-style-with-eye-lens-camera-combination-isolated-on-blue-background-flat-logo-design-template-element-vector.jpg");
            //// displays the ASCIII art image 
        }
        public string GetUserName()
        {
            // the module used to cllect the users name and validated the users input of theyr name thatwill be used to personalise the rest of the application
            Console.WriteLine("Hello!Welcome to the Cubersecurity Chatbot. I am your Assistant");
            Console.WriteLine("What is your name?:)"); // prompts thew user to enter their name and stores it in the userNmae string 
            string userName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(userName)) // validates the users input if theres nothing requires the user to have a secxnd ttemp at entering ther nameif theres nothing thereafter  assigns the user as USER1
            {
                Console.WriteLine("Sorry, I did not quite get that. Can you please write your name below?");
                userName = Console.ReadLine();//second attemt given t the usr to enter their name 
                if (string.IsNullOrWhiteSpace(userName)) {
                    Console.WriteLine("Thats okay, I will call you User1");
                    userName = "User1"; // assigns user as user1 in the event that the user deos not enter their name 
                }
            }
            // dislays formatted greeting with borders and the users name 
            Console.WriteLine("     ╔════════════════════════════════════════════╗");
            Console.WriteLine($"    ║              Hello {userName}              ║");
            Console.WriteLine("     ╚════════════════════════════════════════════╝");
            Console.WriteLine($"Hello {userName} ! I am your cybersecurity assistant. I am here to educate you about cybersecurity and help keep You safe online!");
            return userName;
        } // returns username to use in the conversation class

        private void DisplayASCIIArt(string imagePath) 
        {
            //converts the image assesin to the image ath to an ASCII art 
            string characters = "@#$%&*!:'.' ";
            // CHARACTER GRADIENT FROM DARKEST TO LIGHTEST 
            try // resizes the image for console display for uniformity amoung different console displays
            {
                Bitmap bitmap = new Bitmap(imagePath);
                int width = 100;// the width in characters fr the ASCCII art
                int height = (bitmap.Height * width) / bitmap.Width; // the aspect rati 
                Bitmap resized = new Bitmap(bitmap, new Size(width, height));

                for (int y = 0; y < resized.Height; y++)
                {
                    for (int x = 0; x < resized.Width; x++)
                    {
                        Color pixelColor = resized.GetPixel(x, y); // to convert the pixels in the iamge to ascii characters as specified above
                        int gray = (pixelColor.R + pixelColor.G + pixelColor.B) / 3; // convert rgb to grayscale 
                        int index = (gray * characters.Length - 1) / 255;
                        Console.Write(characters[index]);
                    }
                    Console.WriteLine();// new line after each row of ASCII 
                }
            }
            catch (Exception ex) {
                Console.WriteLine("Error: " + ex.Message); /// this is to hande possible errors in displaying the ascii image 
            }
    }
    }
}
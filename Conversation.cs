using System;
using System.Collections.Generic;
using System.Linq;
namespace CyberSecurityChatBot
{
    public class Conversation
    {
        private string userName;
        public Conversation(string name) 
        {
            userName = name;

        }
         public void Start() { 
       

            while (true)
            {
                Console.Write("\nYou ");
                string userInput = Console.ReadLine()?.ToLower().Trim();
                if (userInput == "exit" || userInput == "Nothing" || userInput == "no")
                {
                    Console.WriteLine($"Got it! {userName} ! If there,s anything you would want to ask me at a later time, I am availabke to assit. Enjoy the rest of your day.:)");
                    break;
                }
                else if (string.IsNullOrEmpty(userInput))
                {
                    Console.WriteLine("Please ask a question related to cybersecurity so I can assit you :) or type 'exit' to close the application.");

                }
                string[] words = userInput.Split(' ');

                if (words.Contains("how") && (words.Contains("are") && (words.Contains("you"))))
                {
                    Console.WriteLine("\nChatBot: I am a computer program, so I don't have feelings, but I am here to help you with any cybersecurity questions you may have.");

                }
                else if (words.Contains("what") && (words.Contains("purpose")))
                {
                    Console.WriteLine("\nChatBot: The purpose of this chatbot is to provide information on cybersecurity and answer any questions you may have to help you stay safe online");
                }
                else if (words.Contains("what") && (words.Contains("can") && (words.Contains("i") && (words.Contains("ask") && (words.Contains("about"))))))
                {
                    Console.WriteLine("\nChatBot: You can ask me about topics like:\n" +
                        "-  Password safety\n" +
                        "-  Phishing\n" +
                        "-  Safe browsing n\"" +
                        "-  Malware and ransomware\n" +
                        "-  Multi-factor authentication (MFA) ");
                }
                else if (words.Contains("password"))
                {
                    Console.WriteLine("\nChatBot: Use a strong password.  Characteristics of a strong password:\n" +
                        " -  A password should be at least 12 characters long.\n" +
                        " -  It should be complex; include a mix of uppercase letters, lowercase letters, numbers, and symbols.\n" +
                        " -  It should not be any of your personal information (name, birthday, address).\n" +
                        " -  It should not contain common words or phrases or be a pattern on a keyboard.\n" +
                        " -  It should be random to make it harder for humans and computers to guess.\n" +
                        " -  Do not write your password down or store it in an easily accessible digital file.\n" +
                        " -  Always try to implement multi-factor authentication (MFA).");
                }
                else if (words.Contains("phishing"))
                {
                    Console.WriteLine("\nChatbot: Do not click on any suspicious links.\n" +
                        " -  Do not share personal information in emails.\n" +
                        " -  Do not accept invitations from unknown sources.\n" +
                        " -  Examine the sender's details and check for inconsistencies compared to usual sender addresses.\n" +
                        " -  Look for poor grammar or spelling errors in the email.");
                }
                else if (words.Contains("safe") && words.Contains("browsing"))
                {
                    Console.WriteLine("\nChatbot: Here are some safe browsing tips:\n" +
                        " - Keep your browser and operating system up to date.\n" +
                        " - Use a reputable antivirus software and keep it updated.\n" +
                        " - Be cautious about the websites you visit, especially when entering sensitive information.\n" +
                        " - Avoid clicking on suspicious links or downloading files from untrusted sources.\n" +
                        " - Use a firewall.");
                }
                else if (words.Contains("mfa") || userInput.Contains("multi-factor") || userInput.Contains("authentication"))
                {
                    Console.WriteLine("\nChatbot: Multi-factor authentication (MFA) is a security process that requires users to verify their identity in more ways than one.\n" +
                        "It combines something you know (your password) with something you have (smartphone, hardware token) or something you are (biometrics).\n" +
                        "This decreases the chances of anyone who might know your password from accessing your device or accounts.\n" +
                        "It also helps defend against password theft and phishing.");
                }
                else if (words.Contains("malware") || words.Contains("ransomware"))
                {
                    Console.WriteLine("\nChatbot: Malware is software designed to harm or exploit any device, service, or network.\n" +
                        "Here are some tips to protect against malware:\n" +
                        " - Keep your software up to date.\n" +
                        " - Use antivirus software.\n" +
                        " - Be careful about what you download or click on.");
                }
                else
                {
                    Console.WriteLine("\nChatBot: I am sorry, I cannot help you with that. Please ask me another question. ");
                }


            }
        }
    }
}
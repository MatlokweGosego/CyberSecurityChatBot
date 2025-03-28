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
         public void Start()
        {
            Console.WriteLine("How can I be of Asssistance? You can ask me anything related to cybersecurity. \n for exapmple:" +
                "Phishing, password creation, authentication, network security, artifical intelligence, identity security, ranmsomware, malware");
            string[] passwordKeywords = { "Password", "authentication", " manager" };
            string[] phishingKeywords = { "Phishing", "email", "scam", "link", "attachment" };

            string[] BrowsingKeywords = { "Safe browsing", "websites", "https", "http", "secure", "unsecure" };

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

                else if (userInput.Split(' ').Any(word => passwordKeywords.Contains(word)))
                {
                    Console.WriteLine("\nChatBot: Use a strong password. : Chracterristics of a strong password:\n You are advised to have a password of at least 12 characters, It shi=ould be complex; include a mix of Uppercase letters, Lowercase letters, Numbers, and Symbols\n this password shouldnt be any of your personal information (name, birthday adress) It shoudnt have common phrases be patterns on a keyboard.It should always be random to make it harder for humans and computers to guess. " +
                        "This password shpulnt be placed on a sticky noe or in a note pad that is easily accesible to avaid it being stolen." +
                        "Always try to implement mutli-factor authentication" +
                        "(multi-factor auntehntication is: a security process that reuires the user to verify their identity), by use of biometrics(facial recogniton, fingerprint, iris scan) or one time codes sent to the users phone.(by security key, password, PIN or a security question." +
                        "This decrases the chances of anyone who might know your password from accessing your device or accounts.it also helps defend againts password theft, and phishing" +
                        "always try to update your password every once in a while.");
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
namespace CyberSecurityChatBot
{
    /// <summary>
    /// This class  handles the interactive cnversation between the user and the chatbot about various cybersecurity relayted concerns such as hishing, malware, password creation. 
    /// </summary>
    public class Conversation // initializes a new intance fr the conversation class to run 
    {
        private string userName;// uses the username for a personalized experience
        public Conversation(string name) 
        {
            userName = name;
            // stores the username throughout the conversation. 
        }
         public void Start() { 
       

            while (true) // the while loop that keeps the conversation going while the application runs till the user exits the application 
            {
                Console.Write("\nYou "); // prompts the user for their input 
                string userInput = Console.ReadLine()?.ToLower().Trim();
                if (userInput == "exit" || userInput == "Nothing" || userInput == "no")
                {
                    Console.WriteLine($"Got it! {userName} ! If there,s anything you would want to ask me at a later time, I am availabke to assit. Enjoy the rest of your day.:)");
                    break;// breaks when the user exits the application and displays a personalized message 
                }
                else if (string.IsNullOrEmpty(userInput))
                {
                    Console.WriteLine("Please ask a question related to cybersecurity so I can assit you :) or type 'exit' to close the application.");
                    // this handles the cases where the user does not enter anything into their input spaces and sends the msessage tothe chatbot
                }
                string[] words = userInput.Split(' '); // split fuction used to split the useres input into words t identify for the chatbot t filter the respones and espond accordingliy 

                if (words.Contains("how") && (words.Contains("are") && (words.Contains("you")))) // filters the response from the user to provide accurate response 
                {
                    Console.WriteLine("\nChatBot: I am a computer program, so I don't have feelings, but I am here to help you with any cybersecurity questions you may have.");

                }
                else if (words.Contains("what") && (words.Contains("purpose")))  // filters the response from the user to provide accurate response
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
                else if (words.Contains("password"))  // filters the response from the user to provide accurate response
                {
                    Console.WriteLine("\nChatBot: Use a strong password.  Characteristics of a strong password:\n" + // responses on questions related to password creation
                        " -  A password should be at least 12 characters long.\n" +
                        " -  It should be complex; include a mix of uppercase letters, lowercase letters, numbers, and symbols.\n" +
                        " -  It should not be any of your personal information (name, birthday, address).\n" +
                        " -  It should not contain common words or phrases or be a pattern on a keyboard.\n" +
                        " -  It should be random to make it harder for humans and computers to guess.\n" +
                        " -  Do not write your password down or store it in an easily accessible digital file.\n" +
                        " -  Always try to implement multi-factor authentication (MFA).");
                }
                else if (words.Contains("phishing"))  // filters the response from the user to provide accurate response
                {
                    Console.WriteLine("\nChatbot: Do not click on any suspicious links.\n" + // respnses to questions related to phishing
                        " -  Do not share personal information in emails.\n" +
                        " -  Do not accept invitations from unknown sources.\n" +
                        " -  Examine the sender's details and check for inconsistencies compared to usual sender addresses.\n" +
                        " -  Look for poor grammar or spelling errors in the email.");
                }
                else if (words.Contains("safe") && words.Contains("browsing"))  // filters the response from the user to provide accurate response
                {
                    Console.WriteLine("\nChatbot: Here are some safe browsing tips:\n" + // responses to questions related to safe browsing
                        " - Keep your browser and operating system up to date.\n" +
                        " - Use a reputable antivirus software and keep it updated.\n" +
                        " - Be cautious about the websites you visit, especially when entering sensitive information.\n" +
                        " - Avoid clicking on suspicious links or downloading files from untrusted sources.\n" +
                        " - Use a firewall.");
                }
                else if (words.Contains("mfa") || userInput.Contains("multi-factor") || userInput.Contains("authentication"))// filters the response from the user to provide accurate response 
                {
                    Console.WriteLine("\nChatbot: Multi-factor authentication (MFA) is a security process that requires users to verify their identity in more ways than one.\n" +
                        "It combines something you know (your password) with something you have (smartphone, hardware token) or something you are (biometrics).\n" +
                        "This decreases the chances of anyone who might know your password from accessing your device or accounts.\n" +
                        "It also helps defend against password theft and phishing.");
                }
                else if (words.Contains("malware") || words.Contains("ransomware"))  // filters the response from the user to provide accurate response
                {
                    Console.WriteLine("\nChatbot: Malware is software designed to harm or exploit any device, service, or network.\n" + // respones to questions related to ransomware or malware
                        "Here are some tips to protect against malware:\n" +
                        " - Keep your software up to date.\n" +
                        " - Use antivirus software.\n" +
                        " - Be careful about what you download or click on.");
                }                                                                  
                else
                {
                    Console.WriteLine("\nChatBot: I am sorry, I cannot help you with that. Please ask me another question. "); // in the case where the user asks a questin that the chatbot has np infrmation n or when the user asks abut things that are not related to cubersecurity 
                }


            }
        }
    }
}
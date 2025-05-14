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
        private Dictionary<string, List<string>> keywordResponses;
        private Random random = new Random();
        private string currentQuery = null;
        private string favoriteQuery = null;
        private bool askedFavoriteQuery = false;
        public Conversation(string name) 
        {
            userName = name;
            // stores the username throughout the conversation.
            random = new Random();

            keywordResponses = new Dictionary<string, List<String>>()
            {

                {
                    "password", new List<string>
                    {
                        " \nChatBot:  A password should be at least 12 characters long.\n" +
                        "  -   It should be complex; include a mix of uppercase letters, lowercase letters, numbers, and symbols.\n" ,
                        " \nChatBot:  It should not be any of your personal information (name, birthday, address).\n" +
                        "  -   It should not contain common words or phrases or be a pattern on a keyboard.\n",
                        " \nChatBot:  It should be random to make it harder for humans and computers to guess.\n" ,
                        " \nChatBot:  Do not write your password down or store it in an easily accessible digital file.\n" ,
                        " \nChatBot:  Always try to implement multi-factor authentication (MFA)."}
                    },

                {
                    "phishing" , new List<string>
                    {
                        "\nChatbot: Do not click on any suspicious links.\n" +
                        " -  Do not share personal information in emails.\n" +
                        " \nChatbot:  Do not accept invitations from unknown sources.\n" ,
                        " \nChatbot:  Examine the sender's details and check for inconsistencies compared to usual sender addresses.\n" ,
                        " \nChatbot:  Look for poor grammar or spelling errors in the email."
                     }
                },

                {
                    "safe browing", new List<string>
                    {
                    " \nChatbot: Here are some safe browsing tips:\n" +
                        " - Keep your browser and operating system up to date.\n" +
                        " - Use a reputable antivirus software and keep it updated.\n" ,
                        " \nChatbot: Be cautious about the websites you visit, especially when entering sensitive information.\n" +
                        " \nChatbot: Avoid clicking on suspicious links or downloading files from untrusted sources.\n" ,
                        " \nChatbot: Use a firewall."
                    }
                },

                {
                    "mfa", new List<string>
                    {
                    "\nChatbot: Multi-factor authentication (MFA) is a security process that requires users to verify their identity in more ways than one.\n" +
                        "It combines something you know (your password) with something you have (smartphone, hardware token) or something you are (biometrics).\n" +
                        "This decreases the chances of anyone who might know your password from accessing your device or accounts.\n" ,
                        " \nChatbot: It also helps defend against password theft and phishing."
                    }
                },

                {
                    "malware", new List<string>
                    {
                    "\nChatbot: Malware is software designed to harm or exploit any device, service, or network.\n" +
                        "Here are some tips to protect against malware:\n" +
                        " - Keep your software up to date.\n" +
                        " \nChatbot: Use antivirus software.\n" ,
                        " - Be careful about what you download or click on."
                    }
                },
                { 
                    "favourite", new List<string> 
                    { 
                    "That's interesting!"
                    }
                },

                { 
                    "interested", new List<string> 
                    { 
                    "Great to know!"
                    }
                }


             };
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

                bool responded = false;
                string newQuery = null;
                foreach (var keywordResponsePair in keywordResponses)
                {
                    if (userInput.Contains(keywordResponsePair.Key))
                    {

                        string response = GetRandomResponse(keywordResponsePair.Value);
                        Console.WriteLine($"\nChatBot: {response}");
                        responded = true;
                        break;
                    }
                }
                if (!responded && currentQuery != null) { 

                    if (userInput.Contains("more") && keywordResponses.ContainsKey(currentQuery))
                    {

                        string response = GetRandomResponse(keywordResponses[currentQuery]);
                        Console.WriteLine($"\nChatBot (While we were talking about {currentQuery}): {response}");
                        responded = true;
                    }

                    else if (userInput.Contains("confused") || userInput.Contains("details") || userInput.Contains("explain"))
                    {
                        if (keywordResponses.ContainsKey(currentQuery))
                        {
                            string response = GetRandomResponse(keywordResponses[currentQuery]);
                            Console.WriteLine($"\nChatBot (More on {currentQuery}): {response}");
                            responded = true;
                        }
                    }
                }

                    if (!responded)
                {
                    Console.WriteLine("\nChatBot: I'm sorry, I didn't understand that. Please ask a question about cybersecurity.");
                }
                if (!responded)
                {

                    string[] words = userInput.Split(' '); // split fuction used to split the useres input into words t identify for the chatbot t filter the respones and espond accordingliy 

                    if (words.Contains("how") && (words.Contains("are") && (words.Contains("you")))) // filters the response from the user to provide accurate response 
                    {
                        Console.WriteLine("\nChatBot: I am a computer program, so I don't have feelings, but I am here to help you with any cybersecurity questions you may have.");
                        responded = true;
                    }
                    else if (words.Contains("what") && (words.Contains("purpose")))  // filters the response from the user to provide accurate response
                    {
                        Console.WriteLine("\nChatBot: The purpose of this chatbot is to provide information on cybersecurity and answer any questions you may have to help you stay safe online");
                        responded = true;
                    }
                    else if (words.Contains("what") && (words.Contains("can") && (words.Contains("i") && (words.Contains("ask") && (words.Contains("about"))))))
                    {
                        Console.WriteLine("\nChatBot: You can ask me about topics like:\n" +
                            "-  Password safety\n" +
                            "-  Phishing\n" +
                            "-  Safe browsing n\"" +
                            "-  Malware and ransomware\n" +
                            "-  Multi-factor authentication (MFA) ");
                        responded = true;
                    }
                }
                if (!responded)
                {
                    Console.WriteLine("\nChatBot: I'm not sure I understand. Can you try rephrasing or ask about a different cybersecurity topic?");
                    currentQuery = null;
                }
                else
                {
                    currentQuery = newQuery;
                }

                if (responded && favoriteQuery != null && random.Next(3) == 0) 
                {
                    if (keywordResponses.ContainsKey(favoriteQuery))
                    {
                        string followUpResponse = GetRandomResponse(keywordResponses[favoriteQuery]);
                        Console.WriteLine($"\nChatBot (You seem interested in {favoriteQuery}): Here's another point: {followUpResponse}");
                    }
                }
        }
        private string GetRandomResponse(List<string> responses)
        {
            if (responses != null && responses.Count > 0)
            {
                int index = random.Next(responses.Count);
                return responses[index];
            }
            return "I'm not sure how to respond to that right now.";
        }
    }

}
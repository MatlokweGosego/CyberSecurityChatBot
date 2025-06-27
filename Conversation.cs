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
        private Dictionary<string, List<string>> keywordResponses; //stores the responses for different cyber security related topic, sentiment detections
        private Random random = new Random();// used toselect random responses
        private string currentTopic = null; // keeps memory of the current conversation
        private string favoriteTopic = null; //remebers the users favoirte query
        private bool askedAboutFavorite = false; //used to keep track of whether or now we asked about favorite queries
        private List<string> conversationHistory = new List<string>(); // stores the conversation history for the current session
        public Conversation(string name)
        {
            userName = name;// stores the username throughout the conversation.
            keywordResponses = new Dictionary<string, List<string>>();
            InitializeResponses();
        }
        private void InitializeResponses()
        {  // initializes the dictionary that holds the different random responses

            if (keywordResponses == null)
            {
                keywordResponses = new Dictionary<string, List<string>>();
            }

            random = new Random();

            keywordResponses = new Dictionary<string, List<String>>() // initializes the dictionary that holds the different random responses
            {

                { //random responses for the password quries.
                    "password", new List<string>
                    {
                        " A password should be at least 12 characters long.\n" +
                        " It should be complex; include a mix of uppercase letters, lowercase letters, numbers, and symbols.\n" ,
                        " It should not be any of your personal information (name, birthday, address).\n" +
                        " It should not contain common words or phrases or be a pattern on a keyboard.\n",
                        " It should be random to make it harder for humans and computers to guess.\n" ,
                        " Do not write your password down or store it in an easily accessible digital file.\n" ,
                        " Always try to implement multi-factor authentication (MFA)."}
                    },

                { //random responses for the phishing quries
                    "phishing" , new List<string>
                    {
                        " Do not click on any suspicious links.\n" +
                        " Do not share personal information in emails.\n" +
                        " Do not accept invitations from unknown sources.\n" ,
                        " Examine the sender's details and check for inconsistencies compared to usual sender addresses.\n" ,
                        " Look for poor grammar or spelling errors in the email."
                     }
                },

                { //random responses for the safe browsing quries
                    "safe browsing", new List<string>
                    {
                    " Here are some safe browsing tips:\n" +
                        " Keep your browser and operating system up to date.\n" +
                        "Use a reputable antivirus software and keep it updated.\n" ,
                        " Be cautious about the websites you visit, especially when entering sensitive information.\n" +
                        "Avoid clicking on suspicious links or downloading files from untrusted sources.\n" ,
                        " Use a firewall."
                    }
                },

                {  //random responses for the multifactor authentication quries
                    "mfa", new List<string>
                    {
                    "Multi-factor authentication (MFA) is a security process that requires users to verify their identity in more ways than one.\n" ,
                        "It combines something you know (your password) with something you have (smartphone, hardware token) or something you are (biometrics).\n" ,
                        "This decreases the chances of anyone who might know your password from accessing your device or accounts.\n" ,
                        "It also helps defend against password theft and phishing."
                    }
                },

                { //random responses for the malware quries
                    "malware", new List<string>
                    {
                    " Malware is software designed to harm or exploit any device, service, or network.\n" +
                        "Here are some tips to protect against malware:\n" +
                        " Keep your software up to date.\n" +
                        " Use antivirus software.\n" ,
                        " Be careful about what you download or click on."
                    }
                },
                // user interest response to get what the useres fvorite query i abiut
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
                },
                //sentiment detecion responses
                {
                    "worried", new List<string>
                    {
                    "It's understandable to feel worried about online threats. Let me share some tips to help you feel more secure.",
                    "Don't worry, I'm here to help you understand how to stay safe online."
                    }
                },

                {
                    "curious", new List<string>
                    {
                    "That's great that you're curious! Asking questions is the first step to staying informed.",
                    "Being curious about cybersecurity is a good thing! What would you like to know?"
                     }
                },

                {
                    "frustrated", new List<string>
                    {
                    "I understand it can be frustrating dealing with online security. Let's break it down step by step.",
                    "It's okay to feel frustrated. I'll try my best to make this clear for you."
                    }
                },

                {
                    "unsure", new List<string>
                    {
                    "It's alright to feel unsure.Let me reassure you. That's what I'm here for. Ask away!",
                    "No problem at all. Let me clarify things for you."
                    }
                }

             };
        }
        /// <summary>
        /// Main civersation loop that handles and generatesmrespones
        /// </summary>

        public void Start()
        {
            ConsoleHelper.PrintChatBot("\nYou can ask me about Cybersecurty Topic like passwords, phishing, amkware");
            ConsoleHelper.PrintChatBot("Type 'exit' to end this coversation");

            while (true) // the while loop that keeps the conversation going while the application runs till the user exits the application 
            {
                ConsoleHelper.PrintUser("\nYou "); // prompts the user for their input 
                string userInput = Console.ReadLine()?.ToLower().Trim();
                conversationHistory.Add($"User : {userInput}");

                if (ShouldExit(userInput))
                {
                    DisplayExitMessage();
                    break;
                }

                if (string.IsNullOrEmpty(userInput))
                {
                    PromptForInput();
                    continue;
                }

                ProcessUserInput(userInput);
            }

        }
        private bool ShouldExit(string input)
        {
            return input == "exit" || input == "nothing" || input == "no";
        }

        private void DisplayExitMessage()
        {

            ConsoleHelper.PrintChatBot($"\nChatBot: Got it {userName}! If there's anything you'd like to ask later, I'm here to help. Enjoy your day! :)");
        }

        private void PromptForInput()
        {

            ConsoleHelper.PrintChatBot("\nChatBot: Please ask a cybersecurity question or type 'exit' to close.");
        }

        private void ProcessUserInput(string userInput)
        {
            bool responded = false;

            // Check for sentiment keywords first
            responded = CheckForSentimentKeywords(userInput);

            // Check for cybersecurity keywords if no sentiment response
            if (!responded)
            {
                responded = CheckForCybersecurityKeywords(userInput);
            }

            // Handle favorite topic logic
            if (!responded)
            {
                responded = HandleFavoriteTopicLogic(userInput);
            }

            // Handle follow-up questions if we're in a topic
            if (!responded && currentTopic != null)
            {
                responded = HandleFollowUpQuestions(userInput);
            }

            // Handle general questions
            if (!responded)
            {
                responded = HandleGeneralQuestions(userInput);
            }

            // Final fallback if nothing matched
            if (!responded)
            {

                ConsoleHelper.PrintChatBot("\nChatBot: I'm not sure I understand. Can you try rephrasing or ask about a different cybersecurity topic?");
            }

            // Occasionally offer more info about favorite topic
            if (responded && favoriteTopic != null && random.Next(3) == 0)
            {
                OfferFollowUpInfo();
            }
        }
        private bool CheckForSentimentKeywords(string userInput)
        {
            if (keywordResponses == null || keywordResponses.Count == 0)
            {
                ConsoleHelper.PrintWarning("Warning: Responses not initialized properly");
                return false;
            }

            var sentimentKeys = keywordResponses
                .Where(kvp => kvp.Key == "worried" ||
                              kvp.Key == "curious" ||
                              kvp.Key == "frustrated" ||
                              kvp.Key == "unsure")
                .ToList();

            foreach (var pair in keywordResponses.Where(kvp =>
                kvp.Key == "worried" || kvp.Key == "curious" ||
                kvp.Key == "frustrated" || kvp.Key == "unsure"))
            {
                if (userInput.Contains(pair.Key))
                {
                    Respond(pair.Value, "ChatBot");
                    return true;
                }
            }
            return false;
        }

        private bool CheckForCybersecurityKeywords(string userInput)
        {
            foreach (var pair in keywordResponses)
            {
                if (userInput.Contains(pair.Key) &&
                    pair.Key != "worried" && pair.Key != "curious" &&
                    pair.Key != "frustrated" && pair.Key != "unsure")
                {
                    currentTopic = pair.Key;
                    Respond(pair.Value, "ChatBot");
                    return true;
                }
            }
            return false;
        }


        private bool HandleFavoriteTopicLogic(string userInput)
        {
            if (userInput.Contains("favorite") && userInput.Contains("topic") && !askedAboutFavorite)
            {

                ConsoleHelper.PrintChatBot("\nChatBot: That's interesting! What makes you particularly interested in that?");
                favoriteTopic = currentTopic;
                askedAboutFavorite = true;
                return true;
            }
            else if (userInput.Contains("interested") && userInput.Contains("in") && !askedAboutFavorite)
            {
                string[] parts = userInput.Split(new string[] { "interested in" }, StringSplitOptions.None);
                if (parts.Length > 1)
                {
                    favoriteTopic = parts[1].Trim();

                    ConsoleHelper.PrintChatBot($"\nChatBot: Great! I'll remember you're interested in {favoriteTopic}. It's important for online safety.");
                    askedAboutFavorite = true;
                    return true;
                }
            }
            else if (favoriteTopic != null && userInput.Contains(favoriteTopic))
            {
                if (keywordResponses.ContainsKey(favoriteTopic))
                {
                    Respond(keywordResponses[favoriteTopic], $"ChatBot (about your favorite topic {favoriteTopic})");
                    return true;
                }
            }
            return false;
        }

        private bool HandleFollowUpQuestions(string userInput)
        {
            if ((userInput.Contains("more") || userInput.Contains("explain")) &&
                keywordResponses.ContainsKey(currentTopic))
            {
                Respond(keywordResponses[currentTopic], $"ChatBot (more about {currentTopic})");
                return true;
            }
            return false;
        }

        private bool HandleGeneralQuestions(string userInput)
        {
            string[] words = userInput.Split(' ');

            if (words.Contains("how") && words.Contains("are") && words.Contains("you"))
            {

                ConsoleHelper.PrintChatBot("\nChatBot: I'm a program without feelings, but ready to help with cybersecurity questions!");
                return true;
            }
            else if (words.Contains("what") && words.Contains("can") && words.Contains("ask"))
            {

                ConsoleHelper.PrintChatBot("\nChatBot: You can ask about:\n- Password safety\n- Phishing\n- Safe browsing\n- Malware\n- Multi-factor authentication");
                return true;
            }
            return false;
        }

        private void OfferFollowUpInfo()
        {
            if (keywordResponses.ContainsKey(favoriteTopic))
            {
                Respond(keywordResponses[favoriteTopic], $"ChatBot (follow-up about {favoriteTopic})");
            }
        }
        private void Respond(List<string> responses, string prefix)
        {

            ConsoleHelper.PrintChatBot($"\n{prefix}: {GetRandomResponse(responses)}");
        }

        private string GetRandomResponse(List<string> responses)
        {
            return responses != null && responses.Count > 0 ?
                responses[random.Next(responses.Count)] :
                "I'm not sure how to respond to that right now.";
        }

    }

}

using System;
using System.Collections.Generic;

namespace HelperApp
{
    [Serializable]
    public class Constants
    {
        public List<string> help = new List<string>
        {
            "Ticket Booking",
            "Shopping",
            "Password Change",
            "Software Installation"
        };
        public List<string> Welcome = new List<string>()
        {
            "Hey how can I help you",
            "How can I help you today",
            "What service can I offer you today?",
            "Hey what can I assist you with",
        };
        public List<string> Goodbye = new List<string>()
        {
            "Have a good day",
            "Happy to help",
            "Okay goodbye",
            "See you later",
            "Hope I was of some help"
        };
        public List<string> Thanks = new List<string>()
        {
            "You are most welcome",
            "No need to thank me, it was my job",
            "The honour is mine"
        };
        public List<string> SoftwareOption = new List<string>
        {
            "Microsoft Office",
            "Microsoft Visual Studio",
            "Android Studio",
            "Mozilla Firefox",
            "Google Chrome",
            "Adobe Photoshop",
            "Notepad++",
            "Other Software"
        };

        public List<string> PasswordOption = new List<string>
        {
            "System",
            "Gmail Account",
            "Facebook Account",
            "Github Account",
            "Skype Account",
            "Other"
        };

        public List<string> ShoppingSite = new List<string>
        {
            "Flipkart",
            "Amazon",
            "Myntra",
            "Jabong"
        };

        public List<string> BookingOption = new List<string>
        {
            "Movie",
            "Railway",
            "Flight"
        };

        public List<string> Selection = new List<string>
        {
            "Rate us",
            "Not now",
            "Never show again"
        };

        public List<string> Score = new List<string>
        {
            "Best",
            "Good",
            "Moderate",
            "Bad",
            "Worst"
        };
    }
}
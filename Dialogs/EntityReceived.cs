using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace HelperApp
{
    [Serializable]
    public class EntityReceived : BasicLuisDialog
    {
        public async Task Booking(IDialogContext context, string r)
        {
            await context.PostAsync($"Request to book {r} tickets is received");
            if (r.ToLower().Equals("movie") || r.ToLower().Equals("cinema") || r.ToLower().Equals("film"))
            {
                await context.SayAsync(text: "Movie Ticket Booking Link: https://www.bookmyshow.com", speak: "This is the movie ticket booking link. You can visit this link and book tickets");
            }
            else if (r.ToLower().Equals("flight") || r.ToLower().Equals("plane") || r.ToLower().Equals("airplane"))
            {
                await context.SayAsync(text: "Flight Ticket Booking Link: https://ww.makemytrip.com", speak: "This is the flight ticket booking link. You can visit this link and book tickets");
            }
            else if (r.ToLower().Equals("railway") || r.ToLower().Equals("train"))
            {
                await context.SayAsync(text: "Railway Ticket Booking Link: https://www.irctc.co.in", speak: "This is the railway ticket booking link. You can visit this link and book tickets");
            }
            await new CloseContact().ConversationEnding(context);
        }
        public async Task Shopping(IDialogContext context, string r)
        {
            await context.PostAsync($"Request to shop online in '{r}' is received.");
            await context.SayAsync(text: $"Shopping Site Link: https://www.{r}.com", speak: "This is your requested online shopping site link");
            await new CloseContact().ConversationEnding(context);
        }
        public async Task PasswordChange(IDialogContext context, string r)
        {
            string step1, step2, step3, step4, step5;
            await context.PostAsync($"Request to change the password of '{r}' is received.");
            if (r.ToLower().Contains("gmail"))
            {
                step1 = "Step 1: Log into your Gmail account, and click the gear icon in the upper right - hand corner.";
                step2 = "Step 2: Click 'Settings.'";
                step3 = "Step 3: Click 'Accounts and Import' at the top.";
                step4 = "Step 4: In the 'Change Account Settings' section, click 'Change password.'";
                step5 = "Step 5: You’ll be prompted to re-enter your current password to confirm your identity.Next, as seen in the screen pictured below, you’ll need to enter a new password — twice(note that you can’t reuse an old password once you change it).";
                await context.SayAsync(text: step1 + "<br/>" + step2 + "<br/>" + step3 + "<br/>" + step4 + "<br/>" + step5, speak: step1 + " " + step2 + " " + step3 + " " + step4 + " " + step5);
                await new CloseContact().ConversationEnding(context);
            }
            else if (r.ToLower().Contains("facebook"))
            {
                step1 = "Step 1: Click in the top right corner of any Facebook page and select Settings.";
                step2 = "Step 2: Click Security and Login.";
                step3 = "Step 3: Click Edit next to Change Password.";
                step4 = "Step 4: Click Save Changes.";
                await context.SayAsync(text: step1 + "<br/>" + step2 + "<br/>" + step3 + "<br/>" + step4, speak: step1 + " " + step2 + " " + step3 + " " + step4);
                await new CloseContact().ConversationEnding(context);
            }
            else if (r.ToLower().Contains("skype"))
            {
                step1 = "Step 1: If you are signed into the Skype app you will want to sign out from the Settings menu.";
                step2 = "Step 2: Input your user name.";
                step3 = "Step 3: Click on the 'Problems signing in?' link.";
                step4 = "Step 4: Enter your email address and wait for email to be sent.";
                step5 = "Step 5: Click link and reset your password with a stronger password.";
                await context.SayAsync(text: step1 + "<br/>" + step2 + "<br/>" + step3 + "<br/>" + step4 + "<br/>" + step5, speak: step1 + " " + step2 + " " + step3 + " " + step4 + " " + step5);
                await new CloseContact().ConversationEnding(context);
            }
            else if (r.ToLower().Contains("github"))
            {
                step1 = "Step 1: Sign in to GitHub.";
                step2 = "Step 2: In the upper-right corner of any page, click your profile photo, then click Settings.";
                step3 = "Step 3: In the left sidebar, click Account settings.";
                step4 = "Step 4: Under 'Change password', type your old password, a strong new password, and confirm your new password.";
                step5 = "Step 5: Click Update password.";
                await context.SayAsync(text: step1 + "<br/>" + step2 + "<br/>" + step3 + "<br/>" + step4 + "<br/>" + step5, speak: step1 + " " + step2 + " " + step3 + " " + step4 + " " + step5);
                await new CloseContact().ConversationEnding(context);
            }
            else if (r.ToLower().Contains("system"))
            {
                step1 = "Step 1: Open Control Panel.";
                step2 = "Step 2: Double-click the Users Accounts icon.";
                step3 = "Step 3: Select the account you want to change.";
                step4 = "Step 4: Select the option 'Change my name' to change your username or 'Create a password' or 'Change my password' to change your password.";
                await context.SayAsync(text: step1 + "<br/>" + step2 + "<br/>" + step3 + "<br/>" + step4, speak: step1 + " " + step2 + " " + step3 + " " + step4);
                await new CloseContact().ConversationEnding(context);
            }
            else
            {
                string str = r.Replace(" ", string.Empty);
                await context.PostAsync("I can search the web for that");
                await context.SayAsync(text: $"Search Link: http://www.google.com/search?q=how+to+change+the+password+of"+str, speak: "You can find the result in this link");
                await new CloseContact().ConversationEnding(context);
            }
        }
        public async Task Installation(IDialogContext context, string r)
        {
            await context.PostAsync($"Request to install '{r}' is received.");
            string str = r.Replace(" ", String.Empty);
            await context.SayAsync(text: $"Search Link: http://www.google.com/search?q=download+str", speak: "Click to see the result");
            await new CloseContact().ConversationEnding(context);
        }
    }
}
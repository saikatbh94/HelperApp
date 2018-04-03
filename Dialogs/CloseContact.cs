using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace HelperApp
{
    [Serializable]
    public class CloseContact : BasicLuisDialog
    {
        public List<string> HelpMessage = new List<string>
        {
            "Is there any additional help required?",
            "Do you need any additional help?",
            "Can I be of some more help?"
        };
        public List<string> RestartMessage = new List<string>
        {
            "Okay, tell me what can I do for you.",
            "Please, tell me what can I do for you.",
            "You are requested to tell me what to do.",
            "Tell me what else do you want."
        };
        public async Task ConversationEnding(IDialogContext context)
        {
            List<string> choices = new List<string> { "Yes", "No" };
            string prompt = new GlobalHandler().GetRandomString(HelpMessage);
            string retryprompt = "Please try again";
            var promptOptions = new PromptOptions<string>(prompt: prompt, options: choices, retry: retryprompt, speak: prompt, retrySpeak: retryprompt, promptStyler: new PromptStyler());
            PromptDialog.Choice(context, Confirm, promptOptions);
        }
        public async Task Confirm(IDialogContext context, IAwaitable<string> result)
        {
            string confirm = await result;
            if (confirm.ToLower() == "no")
            {
                if (GlobalHandler.flag == 0)
                {
                    await new Sentiment().StartAsync(context);
                }
                else
                {
                    await context.PostAsync("You can again start a new conversation by asking me things like 'Install software', 'Change password', 'Book tickets' or 'Shopping on Amazon'");
                    context.Wait(this.MessageReceived);
                }
            }
            else
            {
                string restart = new GlobalHandler().GetRandomString(RestartMessage);
                await context.SayAsync(text: $"{restart} You can try asking me things like 'Install software', 'Change password', 'Book tickets' or 'Shopping on Amazon'");
                context.Wait(this.MessageReceived);
            }
        }
    }
}
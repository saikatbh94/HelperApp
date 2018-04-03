using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace HelperApp
{
    [Serializable]
    public class Sentiment : BasicLuisDialog, IDialog<object>
    {
        static Constants constants = new Constants();
        public async Task StartAsync(IDialogContext context)
        {
            string prompt = "Do you want to rate this app?";
            string retryprompt = "Please try again";
            var promptOptions = new PromptOptions<string>(prompt: prompt, options: constants.Selection, retry: retryprompt, speak: prompt, retrySpeak: retryprompt, promptStyler: new PromptStyler());
            PromptDialog.Choice(context, Rate, promptOptions);
        }
        public async Task Rate(IDialogContext context, IAwaitable<string> result)
        {
            string selection = await result;
            if (selection.ToLower().Contains("rate"))
            {
                string prompt = "Can you please tell us what do you think?";
                string retryprompt = "Please try again";
                var promptOptions = new PromptOptions<string>(prompt: prompt, options: constants.Score, retry: retryprompt, speak: prompt, retrySpeak: retryprompt, promptStyler: new PromptStyler());
                PromptDialog.Choice(context, Score, promptOptions);
            }
            else if (selection.ToLower().Contains("not"))
            {
                await context.PostAsync("So you dont want to rate us. Okay thank you anyway.");
                context.Wait(this.MessageReceived);
            }
            else if (selection.ToLower().Contains("never"))
            {
                await context.PostAsync("Okay, we will not show it again.");
                GlobalHandler.flag = 1;
                context.Wait(this.MessageReceived);
            }
        }
        public async Task Score(IDialogContext context, IAwaitable<string> result)
        {
            string score = await result;
            if (score.ToLower().Contains("best"))
            {
                await context.PostAsync("Thank you very much for your feedback. You have rated our app 10 out of 10");
                context.Wait(this.MessageReceived);
            }
            else if (score.ToLower().Contains("good"))
            {
                await context.PostAsync(text: "Thank you for your feedback. You have rated our app 7 out of 10");
                context.Wait(this.MessageReceived);
            }
            else if (score.ToLower().Contains("moderate"))
            {
                await context.PostAsync("Thank you for your feedback. You have rated our app 5 out of 10");
                context.Wait(this.MessageReceived);
            }
            else if (score.ToLower().Contains("bad"))
            {
                await context.PostAsync("We have received your feedback. You have rated our app 3 out of 10");
                List<string> choices = new List<string> { "Yes", "No" };
                string prompt = "Do you have any suggestions for us?";
                string retryprompt = "Please try again";
                var promptOptions = new PromptOptions<string>(prompt: prompt, options: choices, retry: retryprompt, speak: prompt, retrySpeak: retryprompt, promptStyler: new PromptStyler());
                PromptDialog.Choice(context, Suggestion, promptOptions);
            }
            else
            {
                await context.PostAsync(text: "We have received your feedback. You have rated our app 1 out of 10");
                List<string> choices = new List<string> { "Yes", "No" };
                string prompt = "Do you have any suggestions for us?";
                string retryprompt = "Please try again";
                var promptOptions = new PromptOptions<string>(prompt: prompt, options: choices, retry: retryprompt, speak: prompt, retrySpeak: retryprompt, promptStyler: new PromptStyler());
                PromptDialog.Choice(context, Suggestion, promptOptions);
            }
        }
        public async Task Suggestion(IDialogContext context, IAwaitable<string> result)
        {
            string suggest = await result;
            if (suggest.ToLower().Contains("yes"))
            {
                await context.PostAsync("Tell us your suggestions please...");
                context.Wait(SuggestionReceived);
            }
            else
            {
                await context.PostAsync("So you dont have any suggestions. Okay thank you anyway.");
                context.Wait(this.MessageReceived);
            }
        }
        public async Task SuggestionReceived(IDialogContext context, IAwaitable<IMessageActivity> activity)
        {
            var suggestion = await activity;
            await context.PostAsync("Thank you for your suggestion. We will keep it in mind.");
            context.Wait(this.MessageReceived);
        }
    }
}
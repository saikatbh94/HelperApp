using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace HelperApp
{
    public class Issue : IDialog<object>
    {
        static Constants constants = new Constants();
        public async Task StartAsync(IDialogContext context)
        {
            string prompt = "Please tell me how can I help you?";
            string retryprompt = "Please try again";
            var promptOptions = new PromptOptions<string>(prompt: prompt, options: constants.help, retry: retryprompt, speak: prompt, retrySpeak: retryprompt, promptStyler: new PromptStyler());
            PromptDialog.Choice(context, HelpReceivedAsync, promptOptions);
        }
        public async Task HelpReceivedAsync(IDialogContext context, IAwaitable<string> result)
        {
            string help = await result;
            if (help.ToLower().Contains("ticket") || help.ToLower().Contains("booking"))
            {
                await new EntityNotReceived().Booking(context);
            }
            else if (help.ToLower().Contains("shopping"))
            {
                await new EntityNotReceived().Shopping(context);
            }
            else if (help.ToLower().Contains("password") || help.ToLower().Contains("change"))
            {
                await new EntityNotReceived().PasswordChange(context);
            }
            else if (help.ToLower().Contains("software") || help.ToLower().Contains("installation"))
            {
                await new EntityNotReceived().Installation(context);
            }
        }
    }
}
using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace HelperApp
{
    public class Help : BasicLuisDialog, IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            await context.PostAsync("You can try asking me things like 'Install software', 'Change password', 'Book tickets' or 'Shopping on Amazon', etc");
            context.Wait(this.MessageReceived);
        }
    }
}
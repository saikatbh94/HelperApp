using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;

namespace HelperApp
{
    [Serializable]
    public class BasicLuisDialog : LuisDialog<object>
    {
        public BasicLuisDialog() : base(new LuisService(new LuisModelAttribute(
            ConfigurationManager.AppSettings["LuisAppId"],
            ConfigurationManager.AppSettings["LuisAPIKey"],
            domain: ConfigurationManager.AppSettings["LuisAPIHostName"])))
        {
        }
        private const string EntityBook = "BookingOption";

        private const string EntityShopping = "ShoppingSite";

        private const string EntityPassword = "PasswordOption";

        private const string EntitySoftware = "Software";

        [LuisIntent("None")]
        public async Task NoneIntent(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"Sorry, I did not understand '{result.Query}'. Type 'help' if you need assistance.");
            context.Wait(this.MessageReceived);
        }
        [LuisIntent("Help")]
        public async Task HelpIntent(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("You can try asking me things like 'Install software', 'Change password', 'Book tickets' or 'Shopping on Amazon', etc");
            context.Wait(this.MessageReceived);
        }
        [LuisIntent("Greet")]
        public async Task GreetIntent(IDialogContext context, LuisResult result)
        {
            string greet = new GlobalHandler().GetRandomString(new Constants().Welcome);
            await context.PostAsync($"{greet}");
            context.Wait(this.MessageReceived);
        }
        [LuisIntent("BidBye")]
        public async Task BidByeIntent(IDialogContext context, LuisResult result)
        {
            string bidbye = new GlobalHandler().GetRandomString(new Constants().Goodbye);
            await context.PostAsync($"{bidbye}");
            if (GlobalHandler.flag == 0)
            {
                await new Sentiment().StartAsync(context);
            }
            else
            {
                context.Wait(this.MessageReceived);
            }
        }
        [LuisIntent("ThanksGiving")]
        public async Task ThanksGivingIntent(IDialogContext context, LuisResult result)
        {
            string thanksgiving = new GlobalHandler().GetRandomString(new Constants().Thanks);
            await context.PostAsync($"{thanksgiving}");
            if (GlobalHandler.flag == 0)
            {
                await new Sentiment().StartAsync(context);
            }
            else
            {
                context.Wait(this.MessageReceived);
            }
        }
        [LuisIntent("Booking")]
        public async Task BookingIntent(IDialogContext context, LuisResult result)
        {
            EntityRecommendation Booking;
            if (result.TryFindEntity(EntityBook, out Booking))
            {
                string r = result.Entities[0].Entity;
                await new EntityReceived().Booking(context, r);
            }
            else
            {
                await new EntityNotReceived().Booking(context);
            }
        }
        [LuisIntent("Shopping")]
        public async Task ShoppingIntent(IDialogContext context, LuisResult result)
        {
            EntityRecommendation Shopping;
            if (result.TryFindEntity(EntityShopping, out Shopping))
            {
                string r = result.Entities[0].Entity;
                await new EntityReceived().Shopping(context, r);
            }
            else
            {
                await new EntityNotReceived().Shopping(context);
            }
        }
        [LuisIntent("PassChange")]
        public async Task PassChangeIntent(IDialogContext context, LuisResult result)
        {
            EntityRecommendation password;
            if (result.TryFindEntity(EntityPassword, out password))
            {
                string r = result.Entities[0].Entity;
                await new EntityReceived().PasswordChange(context, r);
            }
            else
            {
                await new EntityNotReceived().PasswordChange(context);
            }
        }
        [LuisIntent("Installation")]
        public async Task InstallationIntent(IDialogContext context, LuisResult result)
        {
            EntityRecommendation software;
            if (result.TryFindEntity(EntitySoftware, out software))
            {
                string r = result.Entities[0].Entity;
                await new EntityReceived().Installation(context, r);
            }
            else
            {
                await new EntityNotReceived().Installation(context);
            }
        }
    }
}

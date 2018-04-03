using Autofac;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Dialogs.Internals;
using Microsoft.Bot.Builder.Internals.Fibers;
using Microsoft.Bot.Builder.Scorables;
using Microsoft.Bot.Connector;
using System.Web;
using System.Web.Http;

namespace HelperApp
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            this.RegisterBotModules();

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        private void RegisterBotModules()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule(new ReflectionSurrogateModule());

            builder.RegisterModule<GlobalMessageHandlersBotModule>();

            builder.Update(Conversation.Container);
        }
    }

    public class GlobalMessageHandlersBotModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder
                .Register(c => new ChangeMindScorable(c.Resolve<IDialogTask>()))
                .As<IScorable<IActivity, double>>()
                .InstancePerLifetimeScope();
            builder
                .Register(c => new HelpScorable(c.Resolve<IDialogTask>()))
                .As<IScorable<IActivity, double>>()
                .InstancePerLifetimeScope();
        }
    }
}

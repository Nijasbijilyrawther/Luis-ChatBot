using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Sample_Bot_Application.Dialogs
{
    [LuisModel("72dc487b-da2a-422f-bc46-0d3b94e735bf", "8c0397b954114dce93938066bd81d5a6")]
    [Serializable]
    public class MeBotLuisDailog : LuisDialog<object>
    {
        public MeBotLuisDailog(params ILuisService[] services) : base(services)
        {
        }

        [LuisIntent("None")]
        [LuisIntent("")]
        public async Task None(IDialogContext context, IAwaitable<IMessageActivity> message, LuisResult result)
        {
            var cts = new CancellationTokenSource();
            await context.Forward(new GreetingsDialog(), GreetingDialogDone, await message, cts.Token);
        }

        private async Task GreetingDialogDone(IDialogContext context, IAwaitable<object> result)
        {
            var success = await result;
            if (!(bool)success)
                await context.PostAsync("I'm sorry. I didn't understand you.");

            context.Wait(MessageReceived);
        }

        [LuisIntent("About Apttus")]
        public async Task AboutApttus(IDialogContext context, LuisResult result)
        {
            await context.PostAsync(@"Apttus is a software giant offering complete automation of revenue operations from beginning to end, successfully transforming the Quote-to-Cash process for some of the largest and most complex businesses around the globe.
 You can have a look into our management team here https://apttus.com/company/management/ ,  If you are interested to know more , Please have a read here https://apttus.com/company/about/");
            context.Wait(MessageReceived);
        }

        [LuisIntent("Welcome")]
        public async Task Welcome(IDialogContext context, LuisResult result)
        {
            await context.PostAsync(@"Hi, Welcome to Apttus Chat Bot Service! Wish you a good day! How may i help you! ");
            context.Wait(MessageReceived);
        }


        [LuisIntent("Contact")]
        public async Task Contact(IDialogContext context, LuisResult result)
        {
            await context.PostAsync(@"Please follow this link to connect with us and know more about our locations. https://apttus.com/company/contact-us/ ");
            context.Wait(MessageReceived);
        }

        [LuisIntent("Issues")]
        public async Task Interest(IDialogContext context, LuisResult result)
        {
            await context.PostAsync(@"Thanks for contacting us! If you are an existing customer , please click on the following link https://login.salesforce.com/ to login and report the issue, If you are visiting 
us for the first time, please click on the following link https://apttus.com/company/contact-us/ to get in touch with us! Thanks!");
            context.Wait(MessageReceived);
        }

        [LuisIntent("Products")]
        public async Task Products(IDialogContext context, LuisResult result)
        {
            await context.PostAsync(@"Thanks for the question, Kindly have a glimpse into our products and their descriptions over this link https://apttus.com/solutions/quote-to-cash/");
            context.Wait(MessageReceived);
        }


        [LuisIntent("Customers")]
        public async Task Customers(IDialogContext context, LuisResult result)
        {
            await context.PostAsync(@"Thanks for asking. Please check this link to have a glimpse into our prestigious Customer list  https://apttus.com/customers/");
            context.Wait(MessageReceived);
        }


        [LuisIntent("Schedule Demo")]
        public async Task ScheduleDemo(IDialogContext context, LuisResult result)
        {
            await context.PostAsync(@"Thanks for showing interest in Us. Please check this link to schedule a demo with us! https://apttus.com/on-demand-demos/?ref=topnav#schedule");
            context.Wait(MessageReceived);
        }

        [LuisIntent("Career Opportunities")]
        public async Task Career(IDialogContext context, LuisResult result)
        {
            await context.PostAsync(@"Congrats , you are now one step closer to a more exciting life! Come and join a very ambitious, energetic and live Apttus Team. 
Please check this link to see the exciting set of job opportunities we have for you!https://apttus.com/company/careers/ ");
            context.Wait(MessageReceived);
        }


        [LuisIntent("Latest News")]
        public async Task News(IDialogContext context, LuisResult result)
        {
            await context.PostAsync(@"Appreciate your interest in Apttus. Please check the following link to see whats brewing up in Apttus Lately! https://apttus.com/company/press/");
            context.Wait(MessageReceived);
        }

        [LuisIntent("About Bot")]
        public async Task AboutMe(IDialogContext context, LuisResult result)
        {
            await context.PostAsync(@"I am a machine ,with no name and feelings! However you can call me Bot! But please dont ask me more personal questions. Thanks in advance.");
            context.Wait(MessageReceived);
        }

        [LuisIntent("General Questions")]
        public async Task GeneralQuestions(IDialogContext context, LuisResult result)
        {
            await context.PostAsync(@"Come On, you are capable enough to find this, you dont need my help here, Cheers!");
            context.Wait(MessageReceived);
        }


    }
}
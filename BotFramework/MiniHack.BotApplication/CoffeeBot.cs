using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Builder.FormFlow.Json;
using MiniHack.BotApplication.Resource;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace MiniHack.BotApplication
{


    [Serializable]
    [Template(TemplateUsage.NotUnderstood, "I do not understand \"{0}\".", "Try again, I don't get \"{0}\".")]
    [Template(TemplateUsage.EnumSelectOne, "What kind of {&} would you like on your coffee? {||}", ChoiceStyle = ChoiceStyleOptions.Buttons)]
    public class CoffeeOrder
    {
        public string Name {get;set;}

        private static ConcurrentDictionary<CultureInfo, IForm<CoffeeOrder>> _forms = new ConcurrentDictionary<CultureInfo, IForm<CoffeeOrder>>();

        public static IForm<CoffeeOrder> BuildForm()
        {
            var culture = Thread.CurrentThread.CurrentUICulture;
            IForm<CoffeeOrder> form;

            if (!_forms.TryGetValue(culture, out form))
            {
                OnCompletionAsyncDelegate<CoffeeOrder> processOrder = async (context, state) =>
                {
                    await context.PostAsync(DynamicCoffee.Processing);
                };

                var builder = new FormBuilder<CoffeeOrder>()
                        .Message(DynamicCoffee.Welcome)
                        .AddRemainingFields();

                builder.Configuration.DefaultPrompt.ChoiceStyle = ChoiceStyleOptions.Auto;
                form = builder.Build();
                _forms[culture] = form;
            }
            return form;
        }
    }
}
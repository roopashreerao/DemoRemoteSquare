using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;

namespace ServiceBusDemo
{
    public class TopicReceiver
    {

        private static string _sbConnectionString = "Endpoint=sb://demo59sbn.servicebus.windows.net/;SharedAccessKeyName=topic59policy;SharedAccessKey=QlAub/N/0stY3FzTI9i1m+7z30RFBFZDoRN9ei03RhY=;EntityPath=topic59";

        private static ISubscriptionClient _subscriptionClient;
        private static string _subscriptionName = "sub59";

        public void ReceiveMessage()
        {
            ReceiveMessageFromAzureBus().GetAwaiter().GetResult();
        }

        private static async Task ReceiveMessageFromAzureBus()
        {
            ServiceBusConnectionStringBuilder builder = new ServiceBusConnectionStringBuilder(_sbConnectionString);
            _subscriptionClient = new SubscriptionClient(builder, _subscriptionName);

            var _options = new MessageHandlerOptions(ExceptionRecieved)
            {
                MaxConcurrentCalls = 1,
                AutoComplete = false
            };

            _subscriptionClient.RegisterMessageHandler(Process_Message, _options);

           Console.ReadKey();

        }

        private static async Task Process_Message(Message _message, System.Threading.CancellationToken _token)
        {
            var messageBody = Encoding.UTF8.GetString(_message.Body);

            Console.WriteLine(messageBody);
            MySquare mySquare = JsonConvert.DeserializeObject<MySquare>(messageBody);
            Console.WriteLine($"Square Area : {mySquare.Area().ToString()}");

            await _subscriptionClient.CompleteAsync(_message.SystemProperties.LockToken);

            Console.ReadLine();
        }


        private static Task ExceptionRecieved(ExceptionReceivedEventArgs args)
        {
            Console.WriteLine(args.Exception);
            return Task.CompletedTask;
        }

    }

}

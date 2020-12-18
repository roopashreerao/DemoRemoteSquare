using Microsoft.Azure.ServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecieveTopic
{
    class Program
    {
        private static string _sbConnectionString = "Endpoint=sb://demo59sbn.servicebus.windows.net/;SharedAccessKeyName=topic59policy;SharedAccessKey=QlAub/N/0stY3FzTI9i1m+7z30RFBFZDoRN9ei03RhY=;EntityPath=topic59";

        private static ISubscriptionClient _client;
        private static string _subscriptionName = "sub59";

        static void Main(string[] args)
        {
            TopicFunction().GetAwaiter().GetResult();
        }

        static async Task TopicFunction()
        {
            ServiceBusConnectionStringBuilder builder = new ServiceBusConnectionStringBuilder(_sbConnectionString);
            _client = new SubscriptionClient(builder, _subscriptionName);
            var _options = new MessageHandlerOptions(ExceptionRecieved)
            {
                MaxConcurrentCalls = 1,
                AutoComplete = false
            };

            _client.RegisterMessageHandler(Process_Message, _options);
            Console.ReadKey();

        }

        static async Task Process_Message(Message _message, System.Threading.CancellationToken _token)
        {
            Console.WriteLine(Encoding.UTF8.GetString(_message.Body));
            await _client.CompleteAsync(_message.SystemProperties.LockToken);
        }

        static Task ExceptionRecieved(ExceptionReceivedEventArgs args)
        {
            Console.WriteLine(args.Exception);
            return Task.CompletedTask;
        }

    }
}

using Microsoft.Azure.ServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendTopic
{
    class Program
    {
        private static string _sbConnectionString = "Endpoint=sb://demo59sbn.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=dcxDc98A6Gjj3Svg6mYmQG+0WmASBziSwQidLEtD810=";
        private static string _topicName = "topic59";

        static async Task Main(string[] args)
        {
           // await managementClient.CreateTopicAsync(new TopicDescription(topicName) { EnablePartitioning = true });

           
           // ServiceBusManagementClient sbClient = ...

//sbClient.Topics.CreateOrUpdateAsync("resource group name", "namespace name", "topic name",new Microsoft.Azure.Management.ServiceBus.Models.SBTopic());

            ITopicClient _client = new TopicClient(_sbConnectionString, _topicName);
            Console.WriteLine("Sending Messages");
            for (int i = 1; i <= 3; i++)
            {
                var _message = new Message(Encoding.UTF8.GetBytes(i.ToString()));
                await _client.SendAsync(_message);
                Console.WriteLine($"Sending Message : {i.ToString()}");
               // Console.ReadLine();
            }

        }
    }
}

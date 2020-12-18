using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;

namespace ServiceBusDemo
{
    public class TopicSender
    {
        private static string _sbConnectionString = "Endpoint=sb://demo59sbn.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=dcxDc98A6Gjj3Svg6mYmQG+0WmASBziSwQidLEtD810=";
        private static string _topicName = "topic59";


        public void SendMessage(String messageBody)
        {
            SendMessageToAzureBus(messageBody).GetAwaiter().GetResult(); ;
        }

        private static async Task SendMessageToAzureBus(String messageBody)
        {
            try
            {
                ITopicClient _client = new TopicClient(_sbConnectionString, _topicName);

                Message message = new Message(Encoding.UTF8.GetBytes(messageBody));
                await _client.SendAsync(message);
                Console.WriteLine($"Sending Message : {messageBody.ToString()}");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SendMessage()
        {
            SendMessageToAzureBus().GetAwaiter().GetResult(); ;
        }

        private static async Task SendMessageToAzureBus()
        {
            try
            {
                ITopicClient _client = new TopicClient(_sbConnectionString, _topicName);
                Console.WriteLine("Sending Messages");
                for (int i = 1; i <= 3; i++)
                {
                    var _message = new Message(Encoding.UTF8.GetBytes(i.ToString()));
                    await _client.SendAsync(_message);
                    Console.WriteLine($"Sending Message : {i.ToString()}");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }


    }
}

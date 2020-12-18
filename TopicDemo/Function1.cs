using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using ServiceBusDemo;

namespace TopicDemo
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static void Run([ServiceBusTrigger("topic59", "sub59", Connection = "AzureWebJobSeviceBus")]string mySbMsg, ILogger log)
        {
            log.LogInformation($"C# ServiceBus topic trigger function processed message: {mySbMsg}");
            MySquare mySquare = JsonConvert.DeserializeObject<MySquare>(mySbMsg);
            log.LogInformation($"Square Area : {mySquare.Area().ToString()}");
            Console.ReadLine();
        }
    }
}

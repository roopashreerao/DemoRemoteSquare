using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace TopicFnTrigger
{
    public static class Function1
    {
        [FunctionName("GetAreaFromSquare")]
        public static void Run([ServiceBusTrigger("topic59", "sub59", Connection = "QlAub/N/0stY3FzTI9i1m+7z30RFBFZDoRN9ei03RhY=")]string mySbMsg, ILogger log)
        {
            log.LogInformation($"C# Roopa ServiceBus topic trigger function processed message: {mySbMsg}");
        }
    }
}

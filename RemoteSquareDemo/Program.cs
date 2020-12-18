using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ServiceBusDemo;

namespace RemoteSquareDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            MySquare mySquare = new MySquare();

            Console.WriteLine("Enter square height");
            mySquare.Height = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter square width");
            mySquare.Width = Convert.ToInt32(Console.ReadLine());

            new TopicSender().SendMessage(JsonConvert.SerializeObject(mySquare));

          //  new TopicReceiver().ReceiveMessage();

            Console.WriteLine("Press any key.....");

        }
    }
}

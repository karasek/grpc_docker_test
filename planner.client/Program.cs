using System;
using System.Threading.Tasks;
using Actionplanner;
using Grpc.Core;

namespace planner
{
    class Program
    {

        public static async Task Main(string[] args)
        {
            var channel = new Channel("127.0.0.1:6000", ChannelCredentials.Insecure);
            var client = new Planner.PlannerClient(channel);

            var status = client.GetStatus(new StatusQuery());
            Console.WriteLine(status);

            await channel.ShutdownAsync();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey(); 
        }
    }
}

using System;
using System.Threading;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace planner
{
    class Program
    {

        const int Port = 5000;

        public static async Task Main(string[] args)
        {
            var hostBuilder = new HostBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    Server server = new Server
                    {
                        Services = { Actionplanner.Planner.BindService(new PlannerImpl()) },
                        Ports = { new ServerPort("0.0.0.0", Port, ServerCredentials.Insecure) }
                    };
                    services.AddSingleton<Server>(server);
                    services.AddSingleton<IHostedService, PlannerHostedService>();
                });

            await hostBuilder.RunConsoleAsync();
            //Server server = new Server
            //{
            //    Services = { 
            //        Actionplanner.Planner.BindService(new PlannerImpl()) 
            //    },
            //    Ports = { new ServerPort("0.0.0.0", Port, ServerCredentials.Insecure) }
            //};
            //server.Start();
            //Console.WriteLine("Status server listening on port " + Port);
            //Thread.Sleep(Timeout.Infinite);
            //server.ShutdownAsync().Wait(); 
        }
    }
}

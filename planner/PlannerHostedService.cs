using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Hosting;

namespace planner
{
    public class PlannerHostedService : IHostedService
    {
        readonly Server _server;

        public PlannerHostedService(Server server)
        {
            _server = server;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            //throw new Exception("die");
            System.Console.WriteLine($"Starting at {_server.Ports.First()}");
            _server.Start();
            System.Console.WriteLine("Started");
            return Task.CompletedTask;
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            System.Console.WriteLine("Stopping");
            await _server.ShutdownAsync();
            System.Console.WriteLine("Stopped");
        }
    }
}
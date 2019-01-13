using System.Threading.Tasks;
using Actionplanner;
using Grpc.Core;
using Status = Actionplanner.Status;


namespace planner
{
    public class PlannerImpl : Planner.PlannerBase
    {
        public override Task<Status> GetStatus(StatusQuery request, ServerCallContext context)
        {
            return Task.FromResult(new Status { Status_ = "OK" });
        }
    }
}
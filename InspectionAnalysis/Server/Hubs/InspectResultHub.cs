using InspectionAnalysis.Operator;
using Microsoft.AspNetCore.SignalR;

namespace InspectionAnalysis.Server.Hubs
{
    public class InspectResultHub : Hub
    {
        public async Task SendData(DateTime startTime, DateTime endTime)
        {
            var results = Select.InspectResultWhereTime(startTime, endTime).ToList();

            await Clients.All.SendAsync("ReceiveData", results);
        }
    }
}

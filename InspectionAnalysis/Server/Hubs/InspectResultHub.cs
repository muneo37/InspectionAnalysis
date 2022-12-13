using Microsoft.AspNetCore.SignalR;

namespace InspectionAnalysis.Server.Hubs
{
    public class InspectResultHub : Hub
    {
        public async Task SendData(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveData", user, message);
        }
    }
}

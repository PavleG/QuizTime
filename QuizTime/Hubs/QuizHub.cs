using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace QuizTime.Hubs{
    public class QuizHub : Hub{
        public async Task SendMessage(string user, string message){
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
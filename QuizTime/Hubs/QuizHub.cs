using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Authentication;
using System.Threading.Tasks;

namespace QuizTime.Hubs{
    public class QuizHub : Hub{
        // IHubContext<QuizHub> _hubContext;
        // public QuizHub(IHubContext<QuizHub> hubContext){
        //     _hubContext = hubContext;
        // }
        public async Task AddToQuiz(string quizCode){
            await Groups.AddToGroupAsync(Context.ConnectionId, quizCode);
        }
        // public async Task AppendPlayerToList(string player, string quizCode){
        //     await Clients.Group(quizCode).SendAsync("DisplayPlayerName", player);
        // }
        public async Task AppendPlayerToList(string user, string message){
            await Clients.All.SendAsync("DisplayPlayerName", user);
        }
    }
}
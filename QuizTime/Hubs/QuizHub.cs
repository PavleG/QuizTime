using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Authentication;
using System.Threading.Tasks;
using System;

namespace QuizTime.Hubs{
    public class QuizHub : Hub{
        // IHubContext<QuizHub> _hubContext;
        // public QuizHub(IHubContext<QuizHub> hubContext){
        //     _hubContext = hubContext;
        // }
        public void AddToQuiz(string quizCode){
            // await Groups.AddToGroupAsync(Context.ConnectionId, quizCode);
            Console.WriteLine("Added to quiz " + Context.ConnectionId);
        }
        // public async Task AppendPlayerToList(string player, string quizCode){
        //     await Clients.Group(quizCode).SendAsync("DisplayPlayerName", player);
        //     Console.WriteLine("Append player "+player+quizCode);
        // }
        public async Task AppendPlayerToList(string player, string quizCode){
            await Clients.All.SendAsync("DisplayPlayerName", player);
        }
    }
}
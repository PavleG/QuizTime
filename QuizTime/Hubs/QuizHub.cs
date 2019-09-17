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
        public void AddToQuizGroup(string pin){
            // await Groups.AddToGroupAsync(Context.ConnectionId, pin);
            Console.WriteLine("Added to quiz " + Context.ConnectionId);
        }
        // public async Task AppendPlayerToList(string player, string quizCode){
        //     await Clients.Group(quizCode).SendAsync("DisplayPlayerName", player);
        //     Console.WriteLine("Append player "+player+quizCode);
        // }
        ///Displaying the player who has joined
        public async Task JoinQuiz(string name, string pin){
            AddToQuizGroup(pin);
            
            await Clients.All.SendAsync("AppendNameToListOfPlayers", name);
            await Clients.Caller.SendAsync("Wait");
        }

        // public async Task RemoveFromQuiz(string name, string pin){
        //     Console.WriteLine("Removed connection " + connectionId);
        //     await Clients.Client(connectionId).SendAsync("Removed");
        //     await Groups.RemoveFromGroupAsync(connectionId, pin);
        // }
    }
}
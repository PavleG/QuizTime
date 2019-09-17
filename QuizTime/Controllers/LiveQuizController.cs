using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using QuizTime.Models;

namespace QuizTime.Controllers {
    public class LiveQuizController : Controller {
        private LiveQuiz quiz;
        public LiveQuizController()
        {
            quiz.HostName = HttpContext.User.Identity.Name;
        }

        public void AddToQuiz(string UserName){
            quiz.AddPlayerToQuiz(UserName);
            Console.WriteLine("Added " + UserName + " to LiveQuiz host: " + quiz.HostName);
            
        }

        public void RemoveFromQuiz(string UserName){
            quiz.RemovePlayerFromQuiz(UserName);
            Console.WriteLine("Removed " + UserName + " from LiveQuiz");
        }
    }
}
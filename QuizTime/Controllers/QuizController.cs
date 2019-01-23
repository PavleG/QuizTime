using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Authorization;
using QuizTime.Models;
using QuizTime.Hubs;
using System.Threading.Tasks;
using System;

namespace QuizTime.Controllers{
    [Authorize(Roles = "QuizMaster")]
    public class QuizController : Controller{
        private readonly IHubContext<QuizHub> _quizHub;
        public QuizController(IHubContext<QuizHub> quizHub){
            _quizHub = quizHub;
        }
        public ViewResult Index() => View();

        public ViewResult Lobby(){
            // Random rnd = new Random();
            // var quizCode = rnd.Next(maxValue: 999999);
            // string quizCode = "12345";
            
            // await _quizHub.Groups.AddToGroupAsync(, quizCode);
            return View();
        }

        public ViewResult Quiz(){
            QuestionModel question1 = new QuestionModel{
                Question = "Capitol of Serbia is...",
                CorrectAnswer = "Belgrad",
                WrongAnswer = "Zagreb"
            };
            QuestionModel question2 = new QuestionModel{
                Question = "Capitol of Croatia is...",
                CorrectAnswer = "Zagreb",
                WrongAnswer = "Sarajevo"
            };
            QuizModel model = new QuizModel{
                Questions = new List<QuestionModel>(){
                    question1, question2
                }
            };
            /* Get model from DB */
            return View(model);
        }
    }
    /*TO DO Quiz master selects a QuizModel and passes it to QuizDisplay component */
}
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using QuizTime.Models;

namespace QuizTime.Controllers{
    [Authorize(Roles = "QuizMaster")]
    public class QuizController : Controller{
        public ViewResult Index() => View();

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
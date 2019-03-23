using System.Collections.Generic;
using System.Linq;
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
        private IQuizRepository _quizRepository;
        public QuizController(IHubContext<QuizHub> quizHub, IQuizRepository repo){
            _quizHub = quizHub;
            _quizRepository = repo;
        }
        public ViewResult Index() => View(_quizRepository.ListOfQuizzes);

        public ViewResult Lobby(int quizID){
            // Random rnd = new Random();
            // var quizCode = rnd.Next(maxValue: 999999);
            // string quizCode = "12345";
            
            // await _quizHub.Groups.AddToGroupAsync(, quizCode);
            return View();
        }

        public ViewResult Quiz(){
            /* Get model from DB */
            IEnumerable<QuizModel> quizzes= _quizRepository.ListOfQuizzes;
            // Temporary fix
            QuizModel model = quizzes.First();
            return View(model);
        }
    }
    /*TO DO Quiz master selects a QuizModel and passes it to QuizDisplay component */
}
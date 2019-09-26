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

        public QuizController(IQuizRepository repo, IHubContext<QuizHub> quizHub = null){
            _quizHub = quizHub;
            _quizRepository = repo;
        }
        public IQuizRepository Repository { get {return _quizRepository;} }
        public ViewResult Index() => View(_quizRepository.ListOfQuizzes);

        [HttpGet]
        public ViewResult Lobby() => View();
        [HttpPost]
        public ViewResult Lobby(int QuizModelID){
            int QuizCode = GenerateCode(User.Identity.Name.GetHashCode(), QuizModelID);
            return View(QuizCode);
        }
        //generate 8-digit game code
        private int GenerateCode(int a, int b){
            return Math.Abs((a + b) * a*b) % (int) 1e+8;
        }

        public ViewResult Quiz(){
            /* Get model from DB */
            IEnumerable<QuizModel> quizzes= _quizRepository.ListOfQuizzes;
            // Temporary fix
            QuizModel model = quizzes.First();
            return View(model);
        }
        
        public IActionResult CreateQuiz()
        {
            return View();
        }
    }
}
using Microsoft.AspNetCore.Mvc;

namespace QuizTime.Controllers{
    public class AccountController : Controller{

        [HttpGet]
        public ViewResult Login(){
            return View();
        }

        [HttpGet]
        public ViewResult Signin(){
            return View();
        }
    }
}
using Microsoft.AspNetCore.Mvc;
namespace QuizTime.Controllers{
    public class HomeController : Controller{
        public ViewResult Index(){
            return View();
        }
    }
}
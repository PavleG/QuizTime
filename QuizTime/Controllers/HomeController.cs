using Microsoft.AspNetCore.Mvc;
namespace QuizTime.Controllers{
    public class HomeController : Controller{
        public IActionResult Index(){
            return View();
        }
    }
}
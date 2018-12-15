using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
namespace QuizTime.Controllers{
    [AllowAnonymous]
    public class HomeController : Controller{
        public ViewResult Index(){
            return View();
        }
    }
}
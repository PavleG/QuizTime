using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace QuizTime.Controllers{
    [AllowAnonymous]
    public class PlayController : Controller{
        public ViewResult Index() => View();
    }
}
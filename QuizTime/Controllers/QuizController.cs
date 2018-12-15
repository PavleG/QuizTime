using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace QuizTime.Controllers{
    [Authorize(Roles = "QuizMaster")]
    public class QuizController : Controller{
        public ViewResult Index() => View();
    }
}
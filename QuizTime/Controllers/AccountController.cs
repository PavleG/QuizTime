using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using QuizTime.Models.ViewModels;
using QuizTime.Models;
namespace QuizTime.Controllers{
    [AllowAnonymous]
    public class AccountController : Controller{
        private SignInManager<User> _signManager; 
        private UserManager<User> _userManager;
        private RoleManager<IdentityRole> _roleManager; 

        public AccountController(UserManager<User> userManager, SignInManager<User> signManager,
                                RoleManager<IdentityRole> roleManager){
            _userManager = userManager; 
            _signManager = signManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public ViewResult Registration(){
            return View();
        }

        [HttpPost] 
        public async Task<IActionResult> Registration (RegistrationViewModel model) {
            if(ModelState.IsValid){
                User user = new User{
                    UserName = model.UserName,
                    Email = model.Email,
                };
                IdentityResult result = await _userManager.CreateAsync(user, model.Password);
                if(result.Succeeded){
                    await _userManager.AddToRoleAsync(user, "QuizMaster");
                    return RedirectToAction("Index", "Quiz");
                }
                else{
                    foreach(IdentityError e in result.Errors)
                        ModelState.AddModelError("", e.Description);
                }
            }
            return View(model);
        }

        [HttpGet]
        public ViewResult Login(){
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginModel) 
        {
            if (ModelState.IsValid) 
            {
                User user =
                    await _userManager.FindByNameAsync(loginModel.UserName);
                if (user != null) 
                {
                    await _signManager.SignOutAsync();
                    if ((await _signManager.PasswordSignInAsync
                            (user, loginModel.Password, false, false)).Succeeded) 
                                return RedirectToAction("Index", "Quiz");
                }
            }

            ModelState.AddModelError("", "Invalid name or password");
            return View(loginModel);
        }
        public async Task<IActionResult> Logout(){
            await _signManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
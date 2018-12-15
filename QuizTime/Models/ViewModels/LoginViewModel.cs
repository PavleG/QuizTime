using System.ComponentModel.DataAnnotations;

namespace QuizTime.Models.ViewModels{

    public class LoginViewModel {

        [Required]
        public string UserName { get; set; }

        [Required]
        [UIHint("Password")]
        public string Password { get; set; }
    }
}
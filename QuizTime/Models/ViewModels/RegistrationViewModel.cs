using System.ComponentModel.DataAnnotations;

namespace QuizTime.Models.ViewModels{
    public class RegistrationViewModel{
        [Required(ErrorMessage = "Please select your user name"), MaxLength(256)] 
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please enter your email address")]
        public string Email { get; set; }
   
        [Required(ErrorMessage = "Please select a password"), DataType(DataType.Password)] 
        public string Password { get; set; }  
    
        [DataType(DataType.Password), Compare(nameof(Password))] 
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Please enter your first name")]
        public string FirstName {get; set;}

         [Required(ErrorMessage = "Please enter your last name")]
        public string LastName {get; set;}
    }
}
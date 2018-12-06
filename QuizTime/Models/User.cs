using System;
using System.ComponentModel.DataAnnotations;
namespace QuizTime.Models{
    public class User{
        public int UserID { get; set; }
        [Required(ErrorMessage = "Please select your user name")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please enter your email address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please select a password")]
        public string Password { get; set; }
    }
}
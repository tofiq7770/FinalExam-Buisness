using System.ComponentModel.DataAnnotations;

namespace FinalExam.Areas.Admin.ViewModels.Account
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Name is required")]
        [MinLength(3, ErrorMessage = "Name Should be Minimum 3 characters")]
        [MaxLength(25, ErrorMessage = "Name Should be Maximum 25 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Surname is required")]
        [MinLength(3, ErrorMessage = "Surname Should be Minimum 3 characters")]
        [MaxLength(25, ErrorMessage = "Surname Should be Minimum 25 characters")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Username is required")]
        [MinLength(3, ErrorMessage = "Username Should be Minimum 3 characters")]
        [MaxLength(25, ErrorMessage = "Username Should be Minimum 25 characters")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm Password is required")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}


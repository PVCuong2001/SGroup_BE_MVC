using System.ComponentModel.DataAnnotations;

namespace Test1.ViewModel
{
    public class LoginVM
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the password")]
        public string Password { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the gmail")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Gmail { get; set; }
    }
}
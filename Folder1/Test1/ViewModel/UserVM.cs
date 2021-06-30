using System.ComponentModel.DataAnnotations;

namespace Test1.ViewModel
{
    public class UserVM
    {
        public string Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the name")]
        [StringLength(maximumLength: 25, MinimumLength = 10, ErrorMessage = "Length must be between 10 to 25")]
        public string Name { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the password")]
        public string Password { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the gmail")]
        public string Gmail { get; set; }
        public string ImageUrl { get; set; }
    }
}
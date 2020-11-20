using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.UserDTOs
{
    public class RegisterDTO
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter your e-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your password")]
        [MinLength(7, ErrorMessage = "Password must be between 7 and 20 characters"), MaxLength(20)]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])).+$", 
        ErrorMessage = "The Password must contain at least one captial letter.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required(ErrorMessage = "Please confirm your password")]
        [Compare("Password", ErrorMessage = "Passwords don't match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Please submit a photo")]
        public IFormFile ProfilePicture { get; set; }
    }
}

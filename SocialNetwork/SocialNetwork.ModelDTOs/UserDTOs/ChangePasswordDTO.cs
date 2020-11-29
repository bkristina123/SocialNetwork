using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.ModelDTOs.UserDTOs
{
    public class ChangePasswordDTO
    {
        [Required]
        [Display(Name = "Old Password")]
        public string OldPassword { get; set; }

        [Required]
        [Display(Name = "New Password")]
        public string NewPassword { get; set; }

        [Required]
        [Display(Name = "Confirm Password")]
        [Compare("NewPassword", ErrorMessage = "Passwords don't match.")]
        public string ConfirmPassword { get; set; }
    }
}

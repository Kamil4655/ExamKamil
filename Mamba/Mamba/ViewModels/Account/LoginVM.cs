using System.ComponentModel.DataAnnotations;

namespace Mamba.ViewModels.Account
{
    public class LoginVM
    {
        public string UserNameOrEmail { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [Required]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}

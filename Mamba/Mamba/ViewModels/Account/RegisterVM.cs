using System.ComponentModel.DataAnnotations;

namespace Mamba.ViewModels.Account
{
    public class RegisterVM
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password), Compare("Password")]
        public string RepatPassword { get; set; }
    }
}

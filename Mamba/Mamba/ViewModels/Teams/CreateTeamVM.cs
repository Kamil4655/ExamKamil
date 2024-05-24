using System.ComponentModel.DataAnnotations;

namespace Mamba.ViewModels.Teams
{
    public class CreateTeamVM
    {
        [MaxLength(100)]
        public string Name { get; set; }
        public string Job { get; set; }
        public string SocialMedia { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}

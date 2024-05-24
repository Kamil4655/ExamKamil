using System.ComponentModel.DataAnnotations;

namespace Mamba.ViewModels.Teams
{
    public class GetTeamVM
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public string Job { get; set; }
        public string SocialMedia { get; set; }
        public string ImageFile { get; set; }
    }
}

namespace Mamba.Models
{
    public class Team: BaseEntity
    {
        public string Name { get; set; }
        public string Job { get; set; }
        public string ImageUrl { get; set; }
        public string SocialMedia { get; set; }
        public string ImageFile { get; internal set; }
    }
}

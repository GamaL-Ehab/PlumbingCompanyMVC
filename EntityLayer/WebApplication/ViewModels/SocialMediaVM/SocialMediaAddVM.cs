namespace EntityLayer.WebApplication.ViewModels
{
    public class SocialMediaAddVM
    {
        public string? Twitter { get; set; }
        public string? LinkedIn { get; set; }
        public string? Facebook { get; set; }
        public string? Instagram { get; set; }

        public AboutAddVM AboutUs { get; set; } = null!;
    }
}

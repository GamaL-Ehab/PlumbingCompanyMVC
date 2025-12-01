namespace EntityLayer.WebApplication.ViewModels
{
    public class SocialMediaListVM
    {
        public int Id { get; set; }
        public string CreatedDate { get; set; } = DateTime.Now.ToString("d");
        public string? UpdatedDate { get; set; }
        public string? Twitter { get; set; }
        public string? LinkedIn { get; set; }
        public string? Facebook { get; set; }
        public string? Instagram { get; set; }

        public AboutListVM AboutUs { get; set; } = null!;
    }
}

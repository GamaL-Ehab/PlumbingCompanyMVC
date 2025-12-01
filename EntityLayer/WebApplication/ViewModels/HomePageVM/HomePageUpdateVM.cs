namespace EntityLayer.WebApplication.ViewModels
{
    public class HomePageUpdateVM
    {
        public int Id { get; set; }
        public string? UpdatedDate { get; set; }
        public virtual byte[] RowVersion { get; set; } = null!;
        public string Header { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string VideoLink { get; set; } = null!;
    }
}

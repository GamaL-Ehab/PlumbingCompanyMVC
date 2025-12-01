namespace EntityLayer.WebApplication.ViewModels
{
    public class ContactUpdateVM
    {
        public int Id { get; set; }
        public string? UpdatedDate { get; set; }
        public virtual byte[] RowVersion { get; set; } = null!;
        public string Location { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Call { get; set; } = null!;
        public string Map { get; set; } = null!;
    }
}

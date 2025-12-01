namespace EntityLayer.WebApplication.ViewModels
{
    public class CategoryUpdateVM
    {
        public int Id { get; set; }
        public string? UpdatedDate { get; set; }
        public virtual byte[] RowVersion { get; set; } = null!;
        public string Name { get; set; } = null!;
    }
}

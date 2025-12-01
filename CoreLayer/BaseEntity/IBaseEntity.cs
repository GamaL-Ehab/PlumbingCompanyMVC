namespace CoreLayer.BaseEntity
{
    public interface IBaseEntity
    {
        int Id { get; set; }
        string CreatedDate { get; set; }
        string? UpdatedDate { get; set; }
        byte[] RowVersion { get; set; }
    }
}

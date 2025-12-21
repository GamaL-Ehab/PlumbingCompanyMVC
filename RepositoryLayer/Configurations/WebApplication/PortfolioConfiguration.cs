using EntityLayer.WebApplication.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RepositoryLayer.Configurations.WebApplication
{
    public class PortfolioConfiguration : IEntityTypeConfiguration<Portfolio>
    {
        public void Configure(EntityTypeBuilder<Portfolio> builder)
        {
            builder.Property(x => x.CreatedDate).IsRequired().HasMaxLength(10);
            builder.Property(x => x.UpdatedDate).HasMaxLength(10);
            builder.Property(x => x.RowVersion).IsRowVersion();

            builder.Property(x => x.Title).IsRequired().HasMaxLength(200);
            builder.Property(x => x.FileName).IsRequired();
            builder.Property(x => x.FileType).IsRequired();

            builder.HasData(new Portfolio
            {
                Id = 1,
                CategoryId = 1,
                Title = "test",
                FileName = "test",
                FileType = "file",
            }, 
            new Portfolio
            {
                Id = 2,
                CategoryId = 1,
                Title = "test2",
                FileName = "test2",
                FileType = "file2",
            }, 
            new Portfolio
            {
                Id = 3,
                CategoryId = 2,
                Title = "test3",
                FileName = "test3",
                FileType = "file3",
            }, 
            new Portfolio
            {
                Id = 4,
                CategoryId = 2,
                Title = "test4",
                FileName = "test4",
                FileType = "file4",
            });
        }
    }
}

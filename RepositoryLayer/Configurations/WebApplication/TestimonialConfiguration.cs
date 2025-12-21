using EntityLayer.WebApplication.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RepositoryLayer.Configurations.WebApplication
{
    public class TestimonialConfiguration : IEntityTypeConfiguration<Testimonial>
    {
        public void Configure(EntityTypeBuilder<Testimonial> builder)
        {
            builder.Property(x => x.CreatedDate).IsRequired().HasMaxLength(10);
            builder.Property(x => x.UpdatedDate).HasMaxLength(10);
            builder.Property(x => x.RowVersion).IsRowVersion();

            builder.Property(x => x.FullName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Comment).IsRequired().HasMaxLength(2000);
            builder.Property(x => x.FileName).IsRequired();
            builder.Property(x => x.FileType).IsRequired();

            builder.HasData(new Testimonial
            {
                Id = 1,
                FullName = "Test",
                FileType = "Test",
                FileName = "Test",
                Title = "Test",
                Comment = "consectetur adipiscing elit. Duis arcu diam, rutrum et efficitur in, varius eget est." +
                "Nullam blandit, dui ut pellentesque placerat, tortor arcu euismod libero,"
            },
            new Testimonial
            {
                Id = 2,
                FullName = "Test2",
                FileType = "Test2",
                FileName = "Test2",
                Title = "Test2",
                Comment = "consectetur adipiscing elit. Duis arcu diam, rutrum et efficitur in, varius eget est." +
                "Nullam blandit, dui ut pellentesque placerat, tortor arcu euismod libero2,"
            },
            new Testimonial
            {
                Id = 3,
                FullName = "Test3",
                FileType = "Test3",
                FileName = "Test3",
                Title = "Test3",
                Comment = "consectetur adipiscing elit. Duis arcu diam, rutrum et efficitur in, varius eget est." +
                "Nullam blandit, dui ut pellentesque placerat, tortor arcu euismod libero3,"
            });
        }
    }
}

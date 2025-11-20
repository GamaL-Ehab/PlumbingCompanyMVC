using EntityLayer.WebApplication.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RepositoryLayer.Configurations
{
    public class HomePageConfiguration : IEntityTypeConfiguration<HomePage>
    {
        public void Configure(EntityTypeBuilder<HomePage> builder)
        {
            builder.Property(x => x.CreatedDate).IsRequired().HasMaxLength(10);
            builder.Property(x => x.UpdatedDate).HasMaxLength(10);
            builder.Property(x => x.RowVersion).IsRowVersion();

            builder.Property(x => x.Header).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(2000);
            builder.Property(x => x.VideoLink).IsRequired();

            builder.HasData(new HomePage
            {
                Id = 1,
                Header = "Lorem ipsum dolor sit amet.",
                Description = "consectetur adipiscing elit. Duis arcu diam, rutrum et efficitur in, varius eget est. " +
                "Nullam blandit, dui ut pellentesque placerat, tortor arcu euismod libero, " +
                "nec pulvinar quam nisl eu turpis. Aenean egestas vulputate orci a tristique. " +
                "Pellentesque vulputate viverra tristique. Morbi eu dignissim nulla.",
                VideoLink = "testVideoLink"
            });
        }
    }
}

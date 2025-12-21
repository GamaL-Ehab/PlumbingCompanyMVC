using EntityLayer.WebApplication.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RepositoryLayer.Configurations.WebApplication
{
    public class AboutUsConfiguration : IEntityTypeConfiguration<AboutUs>
    {
        public void Configure(EntityTypeBuilder<AboutUs> builder)
        {
            builder.Property(x => x.CreatedDate).IsRequired().HasMaxLength(10);
            builder.Property(x => x.UpdatedDate).HasMaxLength(10);
            builder.Property(x => x.RowVersion).IsRowVersion();

            builder.Property(x => x.Header).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(5000);

            builder.Property(x => x.Clients).IsRequired().HasMaxLength(6);
            builder.Property(x => x.Projects).IsRequired().HasMaxLength(6);
            builder.Property(x => x.HoursOfSupport).IsRequired().HasMaxLength(6);
            builder.Property(x => x.HardWorkers).IsRequired().HasMaxLength(6);

            builder.HasData(new AboutUs
            {
                Id = 1,
                Header = "Lorem ipsum dolor sit amet.",
                Description = "consectetur adipiscing elit. Duis arcu diam, rutrum et efficitur in, varius eget est. " +
                "Nullam blandit, dui ut pellentesque placerat, tortor arcu euismod libero, " +
                "nec pulvinar quam nisl eu turpis. Aenean egestas vulputate orci a tristique. " +
                "Pellentesque vulputate viverra tristique. Morbi eu dignissim nulla.",
                Clients = 5,
                Projects = 5,
                HoursOfSupport = 150,
                HardWorkers = 3,
                FileName = "Test",
                FileType = "Test",
                SocialMediaId = 1,
            });
        }
    }
}

using EntityLayer.WebApplication.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RepositoryLayer.Configurations
{
    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.Property(x => x.CreatedDate).IsRequired().HasMaxLength(10);
            builder.Property(x => x.UpdatedDate).HasMaxLength(10);
            builder.Property(x => x.RowVersion).IsRowVersion();

            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(2000);
            builder.Property(x => x.Icon).IsRequired().HasMaxLength(100);

            builder.HasData(new Service
            {
                Id = 1,
                Name = "Test",
                Icon = "Test",
                Description = "consectetur adipiscing elit. Duis arcu diam, rutrum et efficitur in, varius eget est. " +
                "Nullam blandit, dui ut pellentesque placerat, tortor arcu euismod libero, " +
                "nec pulvinar quam nisl eu turpis. Aenean egestas vulputate orci a tristique. " +
                "Pellentesque vulputate viverra tristique. Morbi eu dignissim nulla."
            },
            new Service
            {
                Id = 2,
                Name = "Test2",
                Icon = "Test2",
                Description = "consectetur adipiscing elit. Duis arcu diam, rutrum et efficitur in, varius eget est. " +
                "Nullam blandit, dui ut pellentesque placerat, tortor arcu euismod libero, " +
                "nec pulvinar quam nisl eu turpis. Aenean egestas vulputate orci a tristique. " +
                "Pellentesque vulputate viverra tristique. Morbi eu dignissim nulla."
            },
            new Service
            {
                Id = 3,
                Name = "Test3",
                Icon = "Test3",
                Description = "consectetur adipiscing elit. Duis arcu diam, rutrum et efficitur in, varius eget est. " +
                "Nullam blandit, dui ut pellentesque placerat, tortor arcu euismod libero, " +
                "nec pulvinar quam nisl eu turpis. Aenean egestas vulputate orci a tristique. " +
                "Pellentesque vulputate viverra tristique. Morbi eu dignissim nulla."
            });
        }
    }
}

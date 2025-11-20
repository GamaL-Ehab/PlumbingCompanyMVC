using EntityLayer.WebApplication.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace RepositoryLayer.Contexts
{
    public class PlumbingDbContext : DbContext
    {
        public PlumbingDbContext(DbContextOptions options) : base(options)
        {
        }

        public PlumbingDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<HomePage> HomePage { get; set; }
        public DbSet<AboutUs> AboutUs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<Portfolio> Portfolio { get; set; }
        public DbSet<Service> Service { get; set; }
        public DbSet<SocialMedia> SocialMedia { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }

    }
}

using Microsoft.EntityFrameworkCore;
using Modul4HW6.Data.Entity;
using Modul4HW6.Data.EntityConfigurations;
namespace Modul4HW6.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<ArtistEntity> Artists { get; set; } = null!;
        public DbSet<GenreEntity> Genres { get; set; } = null!;
        public DbSet<SongEntity> Songs { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArtistConfigurations());
            modelBuilder.ApplyConfiguration(new GenreConfiguration());
            modelBuilder.ApplyConfiguration(new SongConfigurations());
        }
    }
}

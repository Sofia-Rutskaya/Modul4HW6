using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modul4HW6.Data.Entity;

namespace Modul4HW6.Data.EntityConfigurations
{
    public class SongConfigurations : IEntityTypeConfiguration<SongEntity>
    {
        public void Configure(EntityTypeBuilder<SongEntity> builder)
        {
            builder.ToTable("Song").HasKey(e => e.Id);
            builder.Property(e => e.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(p => p.Duration).IsRequired();

            builder.HasOne(h => h.Genre)
                .WithMany(w => w.Songs)
                .HasForeignKey(f => f.GenreId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

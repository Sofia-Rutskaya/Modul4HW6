using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modul4HW6.Data.Entity;

namespace Modul4HW6.Data.EntityConfigurations
{
    public class ArtistConfigurations : IEntityTypeConfiguration<ArtistEntity>
    {
        public void Configure(EntityTypeBuilder<ArtistEntity> builder)
        {
            builder.ToTable("Artist").HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Phone).HasMaxLength(50);
            builder.Property(x => x.Email).HasMaxLength(50);
            builder.Property(x => x.DateOfBirth).IsRequired();
            builder.Property(x => x.InstagramUrl).HasMaxLength(50);

            builder.HasMany(h => h.Songs)
                .WithMany(w => w.Artists)
                .UsingEntity<Dictionary<string, object>>(
                "ArtistSong",
                j => j
                .HasOne<SongEntity>()
                .WithMany()
                .HasForeignKey("SongEntityId"),
                j => j.HasOne<ArtistEntity>()
                .WithMany()
                .HasForeignKey("ArtistEntityId"));
        }
    }
}

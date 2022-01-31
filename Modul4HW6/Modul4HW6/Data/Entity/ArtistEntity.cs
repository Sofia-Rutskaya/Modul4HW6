namespace Modul4HW6.Data.Entity
{
    public class ArtistEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public int Phone { get; set; }
        public string? Email { get; set; }
        public string? InstagramUrl { get; set; }
        public virtual List<SongEntity> Songs { get; set; } = new ();
    }
}

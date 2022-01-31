namespace Modul4HW6.Data.Entity
{
    public class SongEntity
    {
        public int Id { get; set; }
        public string Tittle { get; set; } = null!;
        public string Duration { get; set; } = null!;
        public DateTime ReleasedDate { get; set; }

        public int GenreId { get; set; }
        public virtual GenreEntity Genre { get; set; } = null!;
        public virtual List<ArtistEntity> Artists { get; set; } = new ();
    }
}

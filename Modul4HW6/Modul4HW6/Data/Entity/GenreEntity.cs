namespace Modul4HW6.Data.Entity
{
    public class GenreEntity
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;

        public virtual List<SongEntity> Songs { get; set; } = new ();
    }
}

using Modul4HW6.Helper;
using Modul4HW6.Data.Entity;

namespace Modul4HW6.Data
{
    public class AddInfoDb
    {
        private readonly ApplicationContext _context;
        public AddInfoDb(ApplicationContext context)
        {
            _context = context;
        }

        public async Task CheckDb(string[] args)
        {
            var numRows = _context.Genres.Select(x => x.Id)
                .ToList().Count;
            if (numRows <= 0)
            {
                await AddItemsGenres(args);
            }

            numRows = _context.Artists.Select(x => x.Id)
                .ToList().Count;
            if (numRows <= 0)
            {
                await AddItemsArtistSong(args);
            }
        }

        public async Task AddItemsArtistSong(string[] args)
        {
            var artist =
             new List<ArtistEntity>
             {
                new ArtistEntity
                {
                    Name = "Adel",
                    Email = "adel@gmail.com",
                    DateOfBirth = new DateTime(1975, 11, 19),
                    Phone = 0823452842,
                    InstagramUrl = "https:///www.instagram.com/Adel"
                },
                new ArtistEntity
                {
                    Name = "Rag'N'Bone Man",
                    Email = "RagNBoneMan@gmail.com",
                    DateOfBirth = new DateTime(2000, 09, 19),
                    Phone = 932849205,
                    InstagramUrl = "https:///www.instagram.com/RagNBoneMan"
                },
                new ArtistEntity
                {
                    Name = "Billie Eilish",
                    Email = "billie_eilish@gmail.com",
                    DateOfBirth = new DateTime(2002, 05, 24),
                    Phone = 1589853404,
                    InstagramUrl = "https:///www.instagram.com/billie_eilish"
                },
                new ArtistEntity
                {
                    Name = "Melanie Martinez",
                    Email = "melanie_martinez@gmail.com",
                    DateOfBirth = new DateTime(1999, 05, 24),
                    Phone = 1589853404,
                    InstagramUrl = "https:///www.instagram.com/melanie_martinez"
                },
                new ArtistEntity
                {
                    Name = "grandson",
                    Email = "grandson@gmail.com",
                    DateOfBirth = new DateTime(1988, 05, 24),
                    Phone = 536262756,
                    InstagramUrl = "https:///www.instagram.com/grandson"
                }
             };

            var song =
                new List<SongEntity>
                {
                    new SongEntity
                    {
                        Duration = "03:13",
                        ReleasedDate = new DateTime(2018, 04, 12),
                        Tittle = "Dirty",
                        GenreId = 1
                    },
                    new SongEntity
                    {
                        Duration = "03:59",
                        ReleasedDate = new DateTime(2017, 08, 12),
                        Tittle = "Wonderland",
                        GenreId = 2,
                    },
                    new SongEntity
                    {
                        Duration = "03:59",
                        ReleasedDate = new DateTime(2017, 08, 12),
                        Tittle = "Riptide",
                        GenreId = 3,
                    },
                    new SongEntity
                    {
                        Duration = "03:35",
                        ReleasedDate = new DateTime(2020, 08, 12),
                        Tittle = "Bad Guy",
                        GenreId = 3,
                    },
                    new SongEntity
                    {
                        Duration = "03:39",
                        ReleasedDate = new DateTime(2000, 08, 12),
                        Tittle = "Human",
                        GenreId = 5,
                    }
                };

            await _context.Artists.AddRangeAsync(artist);
            await _context.Songs.AddRangeAsync(song);

            artist[1].Songs.Add(song[4]);
            artist[2].Songs.Add(song[3]);
            artist[3].Songs.Add(song[1]);
            artist[4].Songs.Add(song[0]);
            artist[4].Songs.Add(song[2]);

            await _context.SaveChangesAsync();
        }

        public async Task AddItemsGenres(string[] args)
        {
            var genre =
            new List<GenreEntity>
            {
                new GenreEntity
                {
                    Title = "Rock"
                },
                new GenreEntity
                {
                    Title = "Pop"
                },
                new GenreEntity
                {
                    Title = "Grunge"
                },
                new GenreEntity
                {
                    Title = "Classic"
                },
                new GenreEntity
                {
                    Title = "Hip Hop"
                }
            };

            await _context.Genres.AddRangeAsync(genre);

            await _context.SaveChangesAsync();
        }
    }
}

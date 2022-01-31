using System.Data.SqlTypes;
using Modul4HW6.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Modul4HW6.Queries
{
    public class Query
    {
        private readonly ApplicationContext _context;
        public Query(ApplicationContext context)
        {
            _context = context;
        }

        public async Task First()
        {
            var data = await _context.Songs
                .Include(i => i.Genre)
                .Include(s => s.Artists)
                .ToListAsync();

            foreach (var item in data)
            {
                Console.Write($"Tittle: {item.Tittle}, Genre: {item.Genre.Title}");
                foreach (var artist in item.Artists)
                {
                    Console.Write($" Artist: {artist.Name}{Environment.NewLine}");
                }
            }
        }

        public async Task Second()
        {
            var data = await _context.Genres
                .Include(i => i.Songs)
                .ToListAsync();

            foreach (var item in data)
            {
                Console.WriteLine($"Genre: {item.Title}, Count of songs{item.Songs.Count()}");
            }
        }

        public async Task Third()
        {
            var data = await _context.Artists
                .Include(i => i.Songs)
                .Select(s => new
                {
                    DateOfBirth = s.DateOfBirth,
                    Song = s.Songs.Select(d => d.ReleasedDate).FirstOrDefault(),
                    Tittle = s.Name
                })
                .Where(s => (s.DateOfBirth > s.Song))
                .ToListAsync();

            foreach (var item in data)
            {
                Console.Write($"{item.DateOfBirth}");
                Console.WriteLine($" {item.Song} {item.Tittle}");
            }
        }
    }
}

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
                .Select(i => new
                {
                    Tittle = i.Tittle,
                    Genre = i.Genre.Title,
                    Name = i.Artists.Count(),
                })
                .ToListAsync();

            foreach (var item in data)
            {
                Console.WriteLine($"Tittle: {item.Tittle}, Artist: {item.Name}, Genre: {item.Genre}");
            }
        }
    }
}

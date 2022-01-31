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

            Console.WriteLine("Вывести название песни, имя исполнителя, название жанра песни. " +
                $"Вывести только песни у которых есть жанр и которые поет существующий исполнитель.{Environment.NewLine}");

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

            Console.WriteLine($"Вывести кол-во песен в каждом жанре.{Environment.NewLine}");
            foreach (var item in data)
            {
                Console.WriteLine($"Genre: {item.Title}, Count of songs: {item.Songs.Count()}");
            }
        }

        public async Task Third()
        {
            var dateRealise = await _context.Artists
                .Where(a => a.Songs.Count() > 0)
                .MaxAsync(a => a.DateOfBirth);

            var data = await _context.Songs
                .Select(s => new
                {
                    Tittle = s.Tittle,
                    Date = s.ReleasedDate
                })
                .Where(s => s.Date < dateRealise)
                .ToListAsync();

            Console.WriteLine($"Вывести песни, которые были написаны (ReleasedDate) до рождения самого молодого исполнителя.{Environment.NewLine}");

            foreach (var item in data)
            {
                Console.WriteLine($"{item.Tittle}  --  {item.Date}");
            }
        }
    }
}

using CountryInfoApp.CountryInfoApp.Data;
using CountryInfoApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CountryInfoApp.Services
{
    public class CityService
    {
        private readonly ApplicationDbContext _context;

        public CityService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<City>> GetTop10CitiesAsync()
        {
            
            Console.WriteLine("getting cities" + _context.Cities.Count<City>());
            Console.WriteLine(_context.Cities);
            for (int i = 0; i < _context.Cities.Count<City>(); i++)
            {
                Console.WriteLine("Found city");
                Console.WriteLine(_context.Cities.ElementAt(i));
            }
            return await _context.Cities
                .OrderByDescending(c => c.Population)
                .Take(10)
                .ToListAsync();
        }
    }
}

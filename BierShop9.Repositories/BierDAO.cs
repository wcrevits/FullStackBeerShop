using Microsoft.EntityFrameworkCore;
using BierShop9.Repositories.Interfaces;
using BierShop9.Domain.DataDB;
using BierShop9.Domain.EntitiesDB;

namespace BierShop9.Repositories
{
    public class BierDAO : IBierDAO
    {
        private readonly BeerShopDbContext _context;

        public BierDAO(BeerShopDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Beer>> GetAllBeersAsync()
        {
            return await _context.Beers.ToListAsync();
        }
    }
}

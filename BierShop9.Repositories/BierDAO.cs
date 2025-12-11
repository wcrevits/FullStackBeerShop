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

        public Task AddAsync(Beer entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Beer entity)
        {
            throw new NotImplementedException();
        }

        public Task<Beer?> FindbyIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Beer>?> GetAllAsync()
        {
            return await _context.Beers.ToListAsync();
        }

        public Task<IEnumerable<Beer>> GetBeersByAlcohol(decimal percentage)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Beer>> GetBeersByBrewery(int brouwerId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Beer entity)
        {
            throw new NotImplementedException();
        }
    }
}

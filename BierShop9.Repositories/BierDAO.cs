using Microsoft.EntityFrameworkCore;
using BierShop9.Repositories.Interfaces;
using BierShop9.Domain.DataDB;
using BierShop9.Domain.EntitiesDB;
using System.Linq.Expressions;

namespace BierShop9.Repositories
{
    public class BierDAO : IBierDAO
    {
        private readonly BeerShopDbContext _context;

        public BierDAO(BeerShopDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Beer entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
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
            return await _context.Beers
                .Include(b => b.BrouwernrNavigation)
                .Include(b => b.SoortnrNavigation)
                .ToListAsync();
        }

        public async Task<IEnumerable<Beer>> GetBeersByAlcohol(decimal percentage)
        {
            return await _context.Beers
                .Include(b => b.BrouwernrNavigation)
                .Include(b => b.SoortnrNavigation)
                .Where(b => b.Alcohol == percentage)
                .ToListAsync();
        }


        public async Task<IEnumerable<Beer>> GetBeersByBrewery(int brouwerId)
        {
                return await _context.Beers
                    .Where(b => b.Brouwernr == brouwerId)
                    .Include(b => b.BrouwernrNavigation)
                    .Include(b => b.SoortnrNavigation)
                    .ToListAsync();
            
        }

        public Task UpdateAsync(Beer entity)
        {
            throw new NotImplementedException();
        }
    }
}

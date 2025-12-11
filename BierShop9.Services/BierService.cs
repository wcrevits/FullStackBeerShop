using BierShop9.Domain.EntitiesDB;
using BierShop9.Repositories.Interfaces;
using BierShop9.Services.Interfaces;

namespace BierShop9.Services
{
    public class BierService : IBierService
    {
        private IBierDAO _beerDAO;

        public BierService(IBierDAO beerDAO) 
        {
            _beerDAO = beerDAO;
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
            return await _beerDAO.GetAllAsync();
        }

        public Task<IEnumerable<Beer>> GetAllBeersByAlcohol()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Beer>> GetBeersByBreweries()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Beer entity)
        {
            throw new NotImplementedException();
        }
    }
}

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

        public async Task AddAsync(Beer entity)
        {
            await _beerDAO.AddAsync(entity);
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

        public async Task<IEnumerable<Beer>> GetAllBeersByAlcohol(decimal percentage)
        {
            return await _beerDAO.GetBeersByAlcohol(percentage);
        }

        public async Task<IEnumerable<Beer>> GetBeersByBreweries(int breweryId)
        {
            return await _beerDAO.GetBeersByBrewery(breweryId);
        }

        public Task UpdateAsync(Beer entity)
        {
            throw new NotImplementedException();
        }
    }
}

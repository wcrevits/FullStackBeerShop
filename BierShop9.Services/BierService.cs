using BierShop9.Domain.EntitiesDB;
using BierShop9.Repositories.Interfaces;
using BierShop9.Services.Interfaces;

namespace BierShop9.Services
{
    public class BierService : IBierService
    {
        private readonly IBierDAO _bierDAO;

        public BierService(IBierDAO bierDAO)
        {
            _bierDAO = bierDAO;
        }

        public async Task<IEnumerable<Beer>> GetAllBeersAsync()
        {
            return await _bierDAO.GetAllBeersAsync();
        }
    }
}

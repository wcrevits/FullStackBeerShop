using BierShop9.Domain.EntitiesDB;
using BierShop9.Repositories;
using BierShop9.Repositories.Interfaces;
using BierShop9.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace BierShop9.Services
{
    public class BreweryService : IService<Brewery>
    {

        private readonly IDAO<Brewery> _context;

        public BreweryService(IDAO<Brewery> context)
        {
            _context = context;
        }
        
        public Task AddAsync(Brewery entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Brewery entity)
        {
            throw new NotImplementedException();
        }

        public Task<Brewery?> FindbyIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Brewery>?> GetAllAsync()
        {
            return await _context.GetAllAsync();
        }

        public Task UpdateAsync(Brewery entity)
        {
            throw new NotImplementedException();
        }
    }
}

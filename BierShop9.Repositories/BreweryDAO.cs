using BierShop9.Domain.DataDB;
using BierShop9.Domain.EntitiesDB;
using BierShop9.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BierShop9.Repositories
{
    public class BreweryDAO : IDAO<Brewery>
    {
        private readonly BeerShopDbContext _dbContext;

        public BreweryDAO(BeerShopDbContext dbContext)
        {
            _dbContext = dbContext;
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

        public Task<IEnumerable<Brewery>?> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Brewery entity)
        {
            throw new NotImplementedException();
        }
    }
}

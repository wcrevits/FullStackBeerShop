using BierShop9.Domain.DataDB;
using BierShop9.Domain.EntitiesDB;
using BierShop9.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BierShop9.Repositories
{
    public class VarietyDAO : IDAO<Variety>
    {
        private readonly BeerShopDbContext _dbContext;

        public VarietyDAO(BeerShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task AddAsync(Variety entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Variety entity)
        {
            throw new NotImplementedException();
        }

        public Task<Variety?> FindbyIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Variety>?> GetAllAsync()
        {
            return await _dbContext.Varieties.ToListAsync();
        }

        public Task UpdateAsync(Variety entity)
        {
            throw new NotImplementedException();
        }
    }
}

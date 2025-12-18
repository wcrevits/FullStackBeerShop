using BierShop9.Domain.EntitiesDB;
using BierShop9.Repositories.Interfaces;
using BierShop9.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BierShop9.Services
{
    public class VarietyService : IService<Variety>
    {
        private readonly IDAO<Variety> _context;
        public VarietyService(IDAO<Variety> context)
        {
            _context = context;
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
            return await _context.GetAllAsync();
        }

        public Task UpdateAsync(Variety entity)
        {
            throw new NotImplementedException();
        }
    }
}

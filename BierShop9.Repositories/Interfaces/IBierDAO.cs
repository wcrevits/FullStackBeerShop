using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BierShop9.Domain.EntitiesDB;

namespace BierShop9.Repositories.Interfaces
{
    public interface IBierDAO
    {
        Task<IEnumerable<Beer>> GetAllBeersAsync();
    }
}

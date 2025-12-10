using BierShop9.Domain.EntitiesDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BierShop9.Services.Interfaces
{
    public interface IBierService
    {
        Task<IEnumerable<Beer>> GetAllBeersAsync();
    }
}

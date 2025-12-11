
using BierShop9.Domain.EntitiesDB;
using BierShop9.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
namespace BierShop9.Services.Interfaces
{
    public interface IBierService
    {
        Task<IEnumerable<Beer>> GetAllBeersAsync();
    }
}
*/

namespace BierShop9.Services.Interfaces
{
    public interface IBierService : IService<Beer>
    {
        Task<IEnumerable<Beer>> GetAllBeersByAlcohol(decimal percentage);
        Task<IEnumerable<Beer>> GetBeersByBreweries(int breweryId);
    }
}
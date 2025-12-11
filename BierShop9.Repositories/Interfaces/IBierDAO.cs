using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BierShop9.Domain.EntitiesDB;

namespace BierShop9.Repositories.Interfaces
{
    public interface IBierDAO : IDAO<Beer>
    {
        Task<IEnumerable<Beer>> GetBeersByAlcohol(decimal percentage);
        Task<IEnumerable<Beer>> GetBeersByBrewery(int brouwerId);
    }
}

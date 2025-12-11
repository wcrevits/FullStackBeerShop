using BierShop9.Domain.EntitiesDB;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BierShop9.ViewModels
{
    public class BreweryBeersVM
    {
        public int? BreweryNumber { get; set; }
        public IEnumerable<SelectListItem>? Breweries { get; set; }
        public IEnumerable<BeersVM>? Beers { get; set; }
    }
}

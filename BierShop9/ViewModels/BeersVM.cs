using BierShop9.Domain.EntitiesDB;

namespace BierShop9.ViewModels
{
    public class BeersVM
    {
        public string Naam { get; set; }

        public string? BreweryName { get; set; }

        public string? VarietyName { get; set; }

        public decimal? Alcohol { get; set; }

        public string? Image { get; set; }

    }
}

using BierShop9.Domain.EntitiesDB;

namespace BierShop9.ViewModels
{
    public class BeersVM
    {
        public string? Naam { get; set; }

        public string? BrouwerNaam { get; set; }

        public string? SoortNaam { get; set; }

        public decimal? Alcohol { get; set; }

        public string? Image { get; set; }

    }
}

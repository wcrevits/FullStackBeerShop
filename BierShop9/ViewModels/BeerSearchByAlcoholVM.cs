using System.ComponentModel.DataAnnotations;

namespace BierShop9.ViewModels
{
    public class BeerSearchByAlcoholVM
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Geef een alcoholprecentage")]
        [Range(0, 100, ErrorMessage = "Geef een percentage tussen 0 en 100")]

        public int? AlcoholPercentage { get; set; }
        public List<BeersVM>? Beers { get; set; } 
    }
}

using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace BierShop9.ViewModels
{
    public class CreateBeerVM
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Geef een biernaam")]
        [Display(Name = "Naam")]
        public string? naam { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Geef een alcoholprecentage")]
        [Range(0, 100, ErrorMessage = "Geef een percentage tussen 0 en 100")]
        [Display(Name = "Alcoholpercentage")]
        public int alcoholPercentage { get; set; }
        [Required]
        [Display(Name ="Brouwer")]
        public int? Brouwernr { get; set; }
        [Required]
        [Display(Name = "Soort")]
        public int? Soortnr { get; set; }
        public IEnumerable<SelectListItem>? Breweries { get; set; }
        public IEnumerable<SelectListItem>? Varieties {  get; set; }

    }
}

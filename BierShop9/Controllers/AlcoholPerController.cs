using Microsoft.AspNetCore.Mvc;
using BierShop9.Services.Interfaces;
using BierShop9.ViewModels;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using AutoMapper;

namespace BierShop9.Controllers
{
    public class AlcoholPerController : Controller
    {
        private readonly IBierService _bierService;
        private readonly IMapper _mapper;

        public AlcoholPerController(IBierService bierService, IMapper mapper)
        {
            _mapper = mapper;
            _bierService = bierService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var lstBeers = await _bierService.GetAllBeersAsync();

                if (lstBeers != null)
                {
                    var beersVMs = _mapper.Map<List<BeersVM>>(lstBeers);
                    return View(beersVMs);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Er is een fout opgetreden bij het ophalen van de bieren: " + ex.Message);
            }

            return View();
        }
    }
}

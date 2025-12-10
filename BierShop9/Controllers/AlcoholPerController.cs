using Microsoft.AspNetCore.Mvc;
using BierShop9.Services.Interfaces;
using BierShop9.ViewModels;
using AutoMapper;

namespace BierShop9.Controllers
{
    public class AlcoholPerController : Controller
    {
        private readonly IBierService _bierService;
        private readonly IMapper _mapper;

        public AlcoholPerController(IBierService bierService, IMapper mapper)
        {
            _bierService = bierService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            // Show empty table until user searches
            return View(new List<BeersVM>());
        }

        [HttpPost]
        [HttpPost]
        public async Task<IActionResult> Index(decimal alcoholPercentage)
        {
            try
            {
                var beers = await _bierService.GetAllBeersAsync();

                var filtered = beers
                    .Where(b => b.Alcohol.HasValue && b.Alcohol.Value == alcoholPercentage)
                    .ToList();

                var vm = _mapper.Map<List<BeersVM>>(filtered);

                return View(vm);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error loading beers: " + ex.Message);
                return View(new List<BeersVM>());
            }
        }

    }
}

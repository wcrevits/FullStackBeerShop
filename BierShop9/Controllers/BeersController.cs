using AutoMapper;
using BierShop9.Domain.EntitiesDB;
using BierShop9.Services.Interfaces;
using BierShop9.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace BierShop9.Controllers
{
    public class BeersController : Controller
    {
        private readonly IBierService _bierService;
        private readonly IService<Brewery> _breweryService;
        private readonly IService<Variety> _varietyService;
        private readonly IMapper _mapper;

        public BeersController(IBierService bierService, IMapper mapper, IService<Brewery> breweryService, IService<Variety> varietyService)
        {
            _mapper = mapper;
            _bierService = bierService;
            _breweryService = breweryService;
            _varietyService = varietyService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var lstBeers = await _bierService.GetAllAsync();

                List<BeersVM> beersVMs = _mapper.Map<List<BeersVM>>(lstBeers);
                return View(beersVMs);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Er is een fout opgetreden bij het ophalen van de bieren: " + ex.Message);
            }

            return View();
        }
        /// <summary>
        /// Returns a list of beers by inputed alcohol percentage
        /// </summary>
        /// <returns></returns>
        public IActionResult ListAlcohol()
        {
            return View(new BeerSearchByAlcoholVM
            {
                Beers = new List<BeersVM>()
            });
        }

        [HttpPost]
        public async Task<IActionResult> ListAlcohol(BeerSearchByAlcoholVM model)
        {
            if (!ModelState.IsValid)
            {
                return View("ListAlcohol", model);
            }

            try
            {
                var beers = await _bierService.GetAllBeersByAlcohol(model.AlcoholPercentage!.Value);
                model.Beers = _mapper.Map<List<BeersVM>>(beers);
            }
            catch
            {
                ModelState.AddModelError("", "Er ging iets mis bij het ophalen van de bieren.");
            }

            return View("ListAlcohol", model);
        }


        public async Task<IActionResult> GetBeersByBreweriesVM()
        {

            try
            {
                BreweryBeersVM breweryBeersVM = new BreweryBeersVM();

                breweryBeersVM.Breweries = new SelectList(
                    await _breweryService.GetAllAsync(),
                    "Brouwernr",
                    "Naam"
                );

                return View(breweryBeersVM);
            }
            catch
            {


                // Optioneel: Toon een generieke foutmelding aan de gebruiker
                ViewBag.ErrorMessage = "Er is een probleem opgetreden bij het laden van de gegevens.";
                return View("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetBeersByBreweriesVM(BreweryBeersVM entity)
        {
            if (entity.BreweryNumber == null)
            {
                ModelState.AddModelError("", "Selecteer een brouwerij.");
            }
            else
            {
                var beers = await _bierService.GetBeersByBreweries(entity.BreweryNumber.Value);
                entity.Beers = _mapper.Map<List<BeersVM>>(beers);
            }

            entity.Breweries = new SelectList(
                await _breweryService.GetAllAsync(),
                "Brouwernr",
                "Naam",
                entity.BreweryNumber
            );

            return View("GetBeersByBreweriesVM", entity);
        }

        public async Task<IActionResult> GetBeersByBreweries()
        {

            try
            {
                ViewBag.lstBrouwer = new SelectList(
                    await _breweryService.GetAllAsync(),
                    "Brouwernr",
                    "Naam"
                );

                return View();
            }
            catch (Exception ex)
            {
                // Toon een foutpagina of een foutmelding aan de gebruiker
                //ViewBag.ErrorMessage = "Er is een probleem opgetreden bij het ophalen van de lijst met brouwerijen.";
                //return View("Error"); // Ga naar een foutpagina genaamd "Error"
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetBeersByBreweries(int? brouwerId)
        {
            if (brouwerId == null)
            {
                return NotFound();
            }
            try
            {
                var bierList = await _bierService.GetBeersByBreweries
                    (Convert.ToInt16(brouwerId));

                ViewBag.LstBrouwer = new SelectList(await _breweryService.GetAllAsync(),
                "Brouwernr", "Naam", brouwerId);

                List<BeersVM> listVM = _mapper.Map<List<BeersVM>>(bierList);
                return View(listVM);
            }
            catch (Exception ex)
            {

            }
            return View();
        }

        public async Task<IActionResult> GetBeersByBreweriesAjax()
        {

            try
            {
                BreweryBeersVM breweryBeersVM = new BreweryBeersVM();

                breweryBeersVM.Breweries = new SelectList(
                    await _breweryService.GetAllAsync(),
                    "Brouwernr",
                    "Naam"
                );

                return View(breweryBeersVM);
            }
            catch
            {


                // Optioneel: Toon een generieke foutmelding aan de gebruiker
                ViewBag.ErrorMessage = "Er is een probleem opgetreden bij het laden van de gegevens.";
                return View("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetBeersByBreweriesAjax(BreweryBeersVM entity)
        {
            if (entity.BreweryNumber == null)
            {
                return NotFound();
            }
            try
            {
                var beerLst = await _bierService.GetBeersByBreweries
               (Convert.ToInt16(entity.BreweryNumber));
                List<BeersVM> listVM = _mapper.Map<List<BeersVM>>(beerLst);

                // er moet geen lijst met brouwers worden meegegeven

                Thread.Sleep(2000);// mag je natuurlijk weglaten, hier wordt 2 sec. gewacht
                return PartialView("_SearchBierenPartial", listVM);
            }
            catch
            {

            }
            return View(entity);

        }

        public async Task<IActionResult> CreateBeer()
        {
            try
            {
                var createBeerVM = new CreateBeerVM()
                {
                    Breweries = new SelectList(await _breweryService.GetAllAsync(),
                    "Brouwernr", "Naam"),

                    Varieties = new SelectList(await _varietyService.GetAllAsync(),
                    "Soortnr", "Soortnaam")
                };
                return View(createBeerVM);
            }
            catch
            {

                // Optioneel: Toon een generieke foutmelding aan de gebruiker
                ViewBag.ErrorMessage = "Er is een probleem opgetreden bij het laden van de gegevens.";
                return View("Error");
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBeer(CreateBeerVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Beer beer = _mapper.Map<Beer>(model);
                    await _bierService.AddAsync(beer);
                    return RedirectToAction("Index");
                }
            }
            catch (DataException ex)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            catch (Exception ex)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "call system administrator.");
            }

            model.Breweries =
                new SelectList(await _breweryService.GetAllAsync(), "Brouwernr", "Naam"
                , model.Brouwernr);

            model.Varieties =
                new SelectList(await _varietyService.GetAllAsync(), "Soortnr", "Soortnaam"
                , model.Soortnr);

            return View(model);

        }
    }
}
using Laboratorio05.Handlers;
using Laboratorio05.Models;
using Microsoft.AspNetCore.Mvc;
namespace Laboratorio5.Controllers
{
    public class CountryController : Controller
    {
        public IActionResult Index()
        {
            CountryHandler countryHandler = new CountryHandler();
            var countries = countryHandler.ObtenerPaises();
            ViewBag.MainTitle = "Countries list";
            return View(countries);
        }

        [HttpGet]
        public ActionResult CreateCountry()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCountry(CountryModel country)
        {
            ViewBag.ExitoAlCrear = false;
            try
            {
                if (ModelState.IsValid)
                {
                    CountryHandler countryHandler = new CountryHandler();
                    ViewBag.ExitoAlCrear = countryHandler.CrearPais(country);

                    if (ViewBag.ExitoAlCrear)
                    {
                        ViewBag.Message = "Country " + country.Name + " was created succesfully ";
                        ModelState.Clear();
                    }
                }
                return View();
            }
            catch
            {
                ViewBag.Message = "Error on create Country";
                return View();
            }
        }
    }
}

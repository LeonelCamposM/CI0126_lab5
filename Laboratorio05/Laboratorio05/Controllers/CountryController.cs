using Laboratorio05.Handlers;
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
    }
}

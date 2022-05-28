﻿using Laboratorio05.Handlers;
using Laboratorio05.Models;
using Microsoft.AspNetCore.Mvc;
namespace Laboratorio05.Controllers
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

        [HttpGet]
        public ActionResult EditCountry(int? identificador)
        {
            ActionResult vista;
            try
            {
                var paisesHandler = new CountryHandler();
                var pais = paisesHandler.ObtenerPaises().Find(model => model.Id == identificador);
                if (pais == null)
                {
                    vista = RedirectToAction("Index");
                }
                else
                {
                    vista = View(pais);
                }
            }
            catch
            {
                vista = RedirectToAction("Index");
            }
            return vista;
        }

        [HttpPost]
        public ActionResult EditCountry(CountryModel country)
        {
            ViewBag.ExitoAlCrear = false;
            try
            {
                var paisesHandler = new CountryHandler();
                paisesHandler.EditarPais(country);
                return RedirectToAction("Index", "Country");

            }
            catch
            {
                return View();
            }
        } 

        [HttpGet]
        public ActionResult DeleteCountry(int? identificador)
        {
            ViewBag.ExitoAlCrear = false;
            try
            {
                var paisesHandler = new CountryHandler();
                paisesHandler.DeletePais(identificador);
                return RedirectToAction("Index", "Country");

            }
            catch
            {
                return View();
            }
        }
    }
}

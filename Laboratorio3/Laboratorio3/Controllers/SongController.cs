using Laboratorio3.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Laboratorio3.Controllers
{
    public class SongController : Controller
    {
        public IActionResult Index()
        {
            var Song = GetSong();
            ViewBag.MainTitle = "My favorite song";
            return View(Song);
        }

        private SongModel GetSong()
        {
            SongModel song = (new SongModel
            {
                Views = 1000,
                Name = "Borderline",
                Genre = "Indie",
                Author = "Tame Impala",
                LaunchDate = new DateTime(1994, 10, 14)
            });

            return song;
        }
    }
}

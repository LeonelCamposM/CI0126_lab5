using Microsoft.AspNetCore.Mvc;
using System;

namespace Laboratorio3.Models
{
    public class MovieModel
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }

        public DateTime ReleasedDate;
    }
}

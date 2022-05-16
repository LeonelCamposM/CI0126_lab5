using Microsoft.AspNetCore.Mvc;
using System;

namespace Laboratorio5.Models
{
    public class CountryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Continent { get; set; }
        public string Idiom { get; set; }
    }
}

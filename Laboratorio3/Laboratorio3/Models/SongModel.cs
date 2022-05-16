using Microsoft.AspNetCore.Mvc;
using System;

namespace Laboratorio3.Models
{
    public class SongModel
    {
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Author { get; set; }
        public DateTime LaunchDate { get; set; }
        public int Views { get; set; }
    }
}

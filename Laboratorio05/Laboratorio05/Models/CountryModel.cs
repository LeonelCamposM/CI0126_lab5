using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Laboratorio05.Models
{
    public class CountryModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe proporcionar un nombre")]
        [DisplayName("Nombre del país")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Debe proporcionar un continente")]
        [DisplayName("Continente")]
        public string Continent { get; set; }

        [Required(ErrorMessage = "Debe ingresar un idioma")]
        [DisplayName("Idioma")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "No puede ingresar numeros")]
        public string Idiom { get; set; }
    }
}

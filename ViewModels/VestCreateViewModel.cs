using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Brajici.ViewModels
{
    public class VestCreateViewModel
    {

        [Required(ErrorMessage = "Autor je obavezan.")]
        [MaxLength(15, ErrorMessage = "Autor moze imati maksimalno 15 karaktera.")]
        public string Autor { get; set; }
        public string Datum { get; set; }
        [Required(ErrorMessage = "Naslov je obavezan.")]
        [MaxLength(30, ErrorMessage = "Naslov moze imati maksimalno 30 karaktera.")]
        public string Naslov { get; set; }
        [Required(ErrorMessage = "Naslov je obavezan.")]
        [MaxLength(200, ErrorMessage = "Kategorija moze imati maksimalno 15 karaktera.")]
        public string Tekst { get; set; }
        [Required(ErrorMessage = "Slika je obavezna.")]
        public IFormFile Slika { get; set; }
    }
}

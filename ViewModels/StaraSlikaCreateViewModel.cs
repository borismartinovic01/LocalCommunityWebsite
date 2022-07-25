using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Brajici.ViewModels
{
    public class StaraSlikaCreateViewModel
    {
        [Required(ErrorMessage = "Naslov je obavezan.")]
        [MaxLength(50, ErrorMessage = "Naslov ne sme prelaziti 50 karaktera")]
        public string Naslov { get; set; }
        [Required(ErrorMessage = "Opis je obavezan.")]
        [MaxLength(110, ErrorMessage = "Naslov ne sme prelaziti 50 karaktera")]
        public string Opis { get; set; }
        [Required(ErrorMessage = "Slika je obavezna.")]
        public IFormFile Slika { get; set; }
    }
}

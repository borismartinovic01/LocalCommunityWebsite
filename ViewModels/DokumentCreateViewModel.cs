using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Brajici.ViewModels
{
    public class DokumentCreateViewModel
    {
        [Required(ErrorMessage = "Naslov je obavezan.")]
        [MaxLength(50, ErrorMessage = "Naslov ne sme prelaziti 50 karaktera")]
        public string Naslov { get; set; }
        [Required(ErrorMessage = "Opis je obavezan.")]
        [MaxLength(110, ErrorMessage = "Opis ne sme prelaziti 110 karaktera")]
        public string Opis { get; set; }
        [Required(ErrorMessage = "Jedna slika je obavezna.")]
        public IFormFile Slika1 { get; set; }
        public IFormFile Slika2 { get; set; }
        public IFormFile Slika3 { get; set; }
        public IFormFile Slika4 { get; set; }
        public IFormFile Slika5 { get; set; }
    }
}

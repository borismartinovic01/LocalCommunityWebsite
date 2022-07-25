using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Brajici.Models
{
    public class Sponzor
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Naziv je obavezan.")]
        public string Naziv { get; set; }
        [Required(ErrorMessage = "Adresa je obavezan.")]
        public string Adresa { get; set; }
        [Required(ErrorMessage = "Telefon je obavezan.")]
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string Link { get; set; }
        public string Instagram { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        [Required(ErrorMessage = "Slika je obavezna.")]
        public string PhotoPath { get; set; }
    }
}

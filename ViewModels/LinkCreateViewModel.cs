using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Brajici.ViewModels
{
    public class LinkCreateViewModel
    {
        [Required(ErrorMessage = "Naslov je obavezan.")]
        [MaxLength(50, ErrorMessage = "Naslov ne sme prelaziti 50 karaktera")]
        public string Naslov { get; set; }
        [Required(ErrorMessage = "Link je obavezan.")]
        [MaxLength(110, ErrorMessage = "Link ne sme prelaziti 110 karaktera")]
        public string Li { get; set; }
    }
}

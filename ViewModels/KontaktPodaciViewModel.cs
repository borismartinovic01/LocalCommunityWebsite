using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Brajici.ViewModels
{
    public class KontaktPodaciViewModel
    {
        [Required(ErrorMessage ="Ime je obavezno.")]
        public string Ime { get; set; }
        [Required(ErrorMessage="Email je obavezan.")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Poruka je obavezna.")]
        public string Poruka { get; set; }
    }
}

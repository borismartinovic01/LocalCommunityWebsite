using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Brajici.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Email je obavezan.")]
        [EmailAddress(ErrorMessage ="Neispravan email format.")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Šifra je obavezna.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Zapamti me")]
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}

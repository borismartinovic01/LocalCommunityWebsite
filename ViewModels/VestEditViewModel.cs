using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brajici.ViewModels
{
    public class VestEditViewModel:VestCreateViewModel
    {
        public int Id { get; set; }
        public string ExistingPhotoPath { get; set; }
    }
}

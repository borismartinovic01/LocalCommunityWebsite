using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brajici.ViewModels
{
    public class DokumentEditViewModel:DokumentCreateViewModel
    {
        public int Id { get; set; }
        public string ExistingPhotoPath1 { get; set; }
        public string ExistingPhotoPath2 { get; set; }
        public string ExistingPhotoPath3 { get; set; }
        public string ExistingPhotoPath4 { get; set; }
        public string ExistingPhotoPath5 { get; set; }
    }
}

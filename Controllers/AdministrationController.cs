using Brajici.Models;
using Brajici.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Brajici.Controllers
{
    
    public class AdministrationController: Controller
    {
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IStaraSlikaRepository staraSlikaRepository;
        private readonly INovaSlikaRepository novaSlikaRepository;
        private readonly IVestiRepository vestiRepository;
        private readonly IUmjetnickaSlikaRepository umjetnickaSlikaRepository;
        private readonly ISponzorRepository sponzorRepository;
        private readonly IDokumentRepository dokumentRepository;
        private readonly ILinkRepository linkRepository;

        public AdministrationController(IHostingEnvironment hostingEnvironment, IStaraSlikaRepository staraSlikaRepository, INovaSlikaRepository novaSlikaRepository, IVestiRepository vestiRepository, IUmjetnickaSlikaRepository umjetnickaSlikaRepository, ISponzorRepository sponzorRepository, IDokumentRepository dokumentRepository, ILinkRepository linkRepository)
        {
            this.hostingEnvironment = hostingEnvironment;
            this.staraSlikaRepository = staraSlikaRepository;
            this.novaSlikaRepository = novaSlikaRepository;
            this.vestiRepository = vestiRepository;
            this.umjetnickaSlikaRepository = umjetnickaSlikaRepository;
            this.sponzorRepository = sponzorRepository;
            this.dokumentRepository = dokumentRepository;
            this.linkRepository = linkRepository;
        }

        [HttpGet]
        public IActionResult LinkCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LinkCreate(LinkCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                Link noviDokument = new Link()
                {
                    Naslov = model.Naslov,
                    Li = model.Li
                };
                linkRepository.Add(noviDokument);
                return RedirectToAction("Linkovi", "home");
            }
            return View();
        }

        [HttpPost]
        public IActionResult DeleteLink(int id)
        {
            linkRepository.Delete(id);
            return RedirectToAction("Linkovi", "home");
        }
        [HttpGet]
        public ViewResult LinkEdit(int id)
        {
            Link link = linkRepository.GetLink(id);
            LinkEditViewModel linkEditViewModel = new LinkEditViewModel()
            {
                Id = link.Id,
                Naslov = link.Naslov,
                Li = link.Li
            };
            return View(linkEditViewModel);

        }
        [HttpPost]
        public IActionResult LinkEdit(LinkEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Link link = linkRepository.GetLink(model.Id);
                link.Naslov = model.Naslov;
                link.Li = model.Li;
                linkRepository.Update(link);
                return RedirectToAction("Linkovi", "home");
            }
            return View();
        }


        [HttpGet]
        public IActionResult DokumentCreate()
        {
            return View();
        }
        private List<string> ProcessUploadedFileDokument(DokumentCreateViewModel model)
        {
            //Ovde trebas da napravis listu, ali pre toga napravi DokumentCreateViewModel
            List<IFormFile> Slike = new List<IFormFile>()
            {
                model.Slika1,
                model.Slika2,
                model.Slika3,
                model.Slika4,
                model.Slika5
            };
            List<string> uniqueFileNames = new List<string>();
            foreach(var Slika in Slike)
            {
                if (Slika != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "dokumentPictures");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + Slika.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        Slika.CopyTo(fileStream);
                    }
                    uniqueFileNames.Add(uniqueFileName);
                }
                else
                {
                    uniqueFileNames.Add(null);
                }
            }
            //Ako hoces da izbacis sve null vrednosti
            /*while (uniqueFileNames.Count(null) > 0)
            {
                uniqueFileNames.Remove(null);
            }*/
            return uniqueFileNames;
        }

        [HttpPost]
        public IActionResult DokumentCreate(DokumentCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                List<string> uniqueFileNames = ProcessUploadedFileDokument(model);
                Dokument noviDokument = new Dokument()
                {
                    Naslov = model.Naslov,
                    Opis = model.Opis,
                    PhotoPath1 = uniqueFileNames[0],
                    PhotoPath2 = uniqueFileNames[1],
                    PhotoPath3 = uniqueFileNames[2],
                    PhotoPath4 = uniqueFileNames[3],
                    PhotoPath5 = uniqueFileNames[4],
                };
                dokumentRepository.Add(noviDokument);
                return RedirectToAction("Dokumenti", "home");
            }
            return View();
        }
        [HttpPost]
        public IActionResult DeleteDokument(int id)
        {
            Dokument dokument = dokumentRepository.GetDokument(id);
            string filePath1 = Path.Combine(hostingEnvironment.WebRootPath, "dokumentPictures", dokument.PhotoPath1);            
            if (dokument.PhotoPath2 != null)
            {
                string filePath2 = Path.Combine(hostingEnvironment.WebRootPath, "dokumentPictures", dokument.PhotoPath2);
                System.IO.File.Delete(filePath2);
            }
            if (dokument.PhotoPath3 != null)
            {
                string filePath3 = Path.Combine(hostingEnvironment.WebRootPath, "dokumentPictures", dokument.PhotoPath3);
                System.IO.File.Delete(filePath3);
            }
            if (dokument.PhotoPath4 != null)
            {
                string filePath4 = Path.Combine(hostingEnvironment.WebRootPath, "dokumentPictures", dokument.PhotoPath4);
                System.IO.File.Delete(filePath4);
            }
            if (dokument.PhotoPath5 != null)
            {
                string filePath5 = Path.Combine(hostingEnvironment.WebRootPath, "dokumentPictures", dokument.PhotoPath5);
                System.IO.File.Delete(filePath5);
            }
            dokumentRepository.Delete(id);
            System.IO.File.Delete(filePath1);
            return RedirectToAction("dokumenti", "home");
        }
        [HttpGet]
        public ViewResult DokumentEdit(int id)
        {
            Dokument dokument = dokumentRepository.GetDokument(id);
            DokumentEditViewModel dokumentEditViewModel = new DokumentEditViewModel()
            {
                Id = dokument.Id,
                Naslov = dokument.Naslov,
                Opis = dokument.Opis,
                ExistingPhotoPath1 = dokument.PhotoPath1,
                ExistingPhotoPath2 = dokument.PhotoPath2,
                ExistingPhotoPath3 = dokument.PhotoPath3,
                ExistingPhotoPath4 = dokument.PhotoPath4,
                ExistingPhotoPath5 = dokument.PhotoPath5,
            };
            return View(dokumentEditViewModel);
        }
        [HttpPost]
        public IActionResult DokumentEdit(DokumentEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Dokument dokument = dokumentRepository.GetDokument(model.Id);
                dokument.Naslov = model.Naslov;
                dokument.Opis = model.Opis;
                string filePath1 = Path.Combine(hostingEnvironment.WebRootPath, "dokumentPictures", model.ExistingPhotoPath1);
                System.IO.File.Delete(filePath1);
                if (model.ExistingPhotoPath2 != null)
                {
                    string filePath2 = Path.Combine(hostingEnvironment.WebRootPath, "dokumentPictures", model.ExistingPhotoPath2);
                    System.IO.File.Delete(filePath2);
                }
                if (model.ExistingPhotoPath3 != null)
                {
                    string filePath3 = Path.Combine(hostingEnvironment.WebRootPath, "dokumentPictures", model.ExistingPhotoPath3);
                    System.IO.File.Delete(filePath3);
                }
                if (model.ExistingPhotoPath4 != null)
                {
                    string filePath4 = Path.Combine(hostingEnvironment.WebRootPath, "dokumentPictures", model.ExistingPhotoPath4);
                    System.IO.File.Delete(filePath4);
                }
                if (model.ExistingPhotoPath5 != null)
                {
                    string filePath5 = Path.Combine(hostingEnvironment.WebRootPath, "dokumentPictures", model.ExistingPhotoPath5);
                    System.IO.File.Delete(filePath5);
                }
                List<string> uniqueFileNames = ProcessUploadedFileDokument(model);
                dokument.PhotoPath1 = uniqueFileNames[0];
                dokument.PhotoPath2 = uniqueFileNames[1];
                dokument.PhotoPath3 = uniqueFileNames[2];
                dokument.PhotoPath4 = uniqueFileNames[3];
                dokument.PhotoPath5 = uniqueFileNames[4];
                dokumentRepository.Update(dokument);
                return RedirectToAction("Dokumenti", "home");
            }
            return View();
        }
        [HttpGet]
        public IActionResult StaraSlikaCreate()
        {
            return View();
        }

        private string ProcessUploadedFileOld(StaraSlikaCreateViewModel model)
        {
            string uniqueFileName = null;
            if (model.Slika != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "oldPictures");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Slika.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Slika.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }

        [HttpPost]
        public IActionResult StaraSlikaCreate(StaraSlikaCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadedFileOld(model);
                StaraSlika novaStaraSlika = new StaraSlika()
                {
                    Naslov = model.Naslov,
                    Opis = model.Opis,
                    PhotoPath = uniqueFileName
                };
                staraSlikaRepository.Add(novaStaraSlika);
                return RedirectToAction("StareSlike", "home");
            }            
            return View();
        }
        [HttpGet]
        public IActionResult NovaSlikaCreate()
        {
            return View();
        }

        private string ProcessUploadedFileNew(NovaSlikaCreateViewModel model)
        {

            string uniqueFileName = null;
            if (model.Slika != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "newPictures");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Slika.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Slika.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }
        [HttpPost]
        public IActionResult NovaSlikaCreate(NovaSlikaCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadedFileNew(model);
                NovaSlika novaNovaSlika = new NovaSlika()
                {
                    Naslov = model.Naslov,
                    Opis = model.Opis,
                    PhotoPath = uniqueFileName
                };
                novaSlikaRepository.Add(novaNovaSlika);
                return RedirectToAction("SavremeneSlike", "home");
            }            
            return View();
        }
        [HttpGet]
        public ViewResult StaraSlikaEdit(int id)
        {
            StaraSlika stara = staraSlikaRepository.GetStara(id);
            StaraSlikaEditViewModel staraSlikaEditViewModel = new StaraSlikaEditViewModel()
            {
                Id = stara.Id,
                Naslov = stara.Naslov,
                Opis = stara.Opis,
                ExistingPhotoPath = stara.PhotoPath
            };
            return View(staraSlikaEditViewModel);

        }
        [HttpPost]
        public IActionResult StaraSlikaEdit(StaraSlikaEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                StaraSlika stara = staraSlikaRepository.GetStara(model.Id);
                stara.Naslov = model.Naslov;
                stara.Opis = model.Opis;
                string filePath = Path.Combine(hostingEnvironment.WebRootPath, "oldPictures", model.ExistingPhotoPath);
                System.IO.File.Delete(filePath);
                stara.PhotoPath = ProcessUploadedFileOld(model);
                staraSlikaRepository.Update(stara);
                return RedirectToAction("StareSlike", "home");
            }
            return View();
        }
        [HttpGet]
        public ViewResult NovaSlikaEdit(int id)
        {
            NovaSlika nova = novaSlikaRepository.GetNova(id);
            NovaSlikaEditViewModel novaSlikaEditViewModel = new NovaSlikaEditViewModel()
            {
                Id = nova.Id,
                Naslov = nova.Naslov,
                Opis = nova.Opis,
                ExistingPhotoPath = nova.PhotoPath
            };
            return View(novaSlikaEditViewModel);

        }
        [HttpPost]
        public IActionResult NovaSlikaEdit(NovaSlikaEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                NovaSlika nova = novaSlikaRepository.GetNova(model.Id);
                nova.Naslov = model.Naslov;
                nova.Opis = model.Opis;
                string filePath = Path.Combine(hostingEnvironment.WebRootPath, "newPictures", model.ExistingPhotoPath);
                System.IO.File.Delete(filePath);
                nova.PhotoPath = ProcessUploadedFileNew(model);
                novaSlikaRepository.Update(nova);
                return RedirectToAction("SavremeneSlike", "home");
            }
            return View();
        }
        private string ProcessUploadedFileVest(VestCreateViewModel model)
        {

            string uniqueFileName = null;
            if (model.Slika != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "vestiPictures");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Slika.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Slika.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }
        [HttpGet]
        public IActionResult VestCreate()
        {
            return View();
        }
        [HttpPost]
        public IActionResult VestCreate(VestCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadedFileVest(model);
                Vesti vest = new Vesti()
                {
                    Autor = model.Autor,
                    Datum = System.DateTime.Now.Day.ToString() + "." + System.DateTime.Now.Month.ToString() + "." + System.DateTime.Now.Year.ToString(),
                    Naslov=model.Naslov,
                    Tekst=model.Tekst,
                    PhotoPath = uniqueFileName
                };
                vestiRepository.Add(vest);
                return RedirectToAction("vesti", "home");
            }
            return View();
        }
        [HttpGet]
        public ViewResult VestEdit(int id)
        {
            Vesti vest = vestiRepository.GetVest(id);
            VestEditViewModel vestEditViewModel = new VestEditViewModel()
            {
                Id = vest.Id,
                Autor = vest.Autor,
                Naslov = vest.Naslov,
                Tekst = vest.Tekst,
                ExistingPhotoPath = vest.PhotoPath
            };
            return View(vestEditViewModel);
        }
        [HttpPost]
        public IActionResult VestEdit(VestEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Vesti vest = vestiRepository.GetVest(model.Id);
                vest.Autor = model.Autor;
                vest.Naslov = model.Naslov;
                vest.Tekst = model.Tekst;
                string filePath = Path.Combine(hostingEnvironment.WebRootPath, "vestiPictures", model.ExistingPhotoPath);
                System.IO.File.Delete(filePath);
                vest.PhotoPath = ProcessUploadedFileVest(model);
                vestiRepository.Update(vest);
                return RedirectToAction("vesti", "home");
            }
            return View();
        }

        [HttpPost]
        public IActionResult DeleteStara(int id)
        {
            StaraSlika stara = staraSlikaRepository.GetStara(id);
            string filePath = Path.Combine(hostingEnvironment.WebRootPath, "oldPictures", stara.PhotoPath);           
            staraSlikaRepository.Delete(id);
            System.IO.File.Delete(filePath);
            return RedirectToAction("stareSlike","home");
        }
        [HttpPost]
        public IActionResult DeleteNova(int id)
        {
            NovaSlika nova = novaSlikaRepository.GetNova(id);
            string filePath = Path.Combine(hostingEnvironment.WebRootPath, "newPictures", nova.PhotoPath);
            
            novaSlikaRepository.Delete(id);
            System.IO.File.Delete(filePath);
            return RedirectToAction("savremeneSlike", "home");
        }
        [HttpPost]
        public IActionResult DeleteVest(int id)
        {
            Vesti vest = vestiRepository.GetVest(id);
            string filePath = Path.Combine(hostingEnvironment.WebRootPath, "vestiPictures", vest.PhotoPath);            
            vestiRepository.Delete(id);
            System.IO.File.Delete(filePath);
            return RedirectToAction("vesti", "home");
        }

        private string ProcessUploadedFileUm(UmjetnickaSlikaCreateViewModel model)
        {
            string uniqueFileName = null;
            if (model.Slika != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "umPictures");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Slika.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Slika.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }
        [HttpGet]
        public IActionResult UmjetnickaSlikaCreate()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UmjetnickaSlikaCreate(UmjetnickaSlikaCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadedFileUm(model);
                UmjetnickaSlika novaUmjetnickaSlika = new UmjetnickaSlika()
                {
                    Naslov = model.Naslov,
                    Opis = model.Opis,
                    PhotoPath = uniqueFileName
                };
                umjetnickaSlikaRepository.Add(novaUmjetnickaSlika);
                return RedirectToAction("UmjetnickeSlike", "home");
            }
            return View();
        }
        [HttpGet]
        public ViewResult UmjetnickaSlikaEdit(int id)
        {
            UmjetnickaSlika umjetnicka = umjetnickaSlikaRepository.GetSlika(id);
            UmjetnickaSlikaEditViewModel umjetnickaSlikaEditViewModel = new UmjetnickaSlikaEditViewModel()
            {
                Id = umjetnicka.Id,
                Naslov = umjetnicka.Naslov,
                Opis = umjetnicka.Opis,
                ExistingPhotoPath = umjetnicka.PhotoPath
            };
            return View(umjetnickaSlikaEditViewModel);

        }
        [HttpPost]
        public IActionResult UmjetnickaSlikaEdit(UmjetnickaSlikaEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                UmjetnickaSlika umjetnicka = umjetnickaSlikaRepository.GetSlika(model.Id);
                umjetnicka.Naslov = model.Naslov;
                umjetnicka.Opis = model.Opis;
                string filePath = Path.Combine(hostingEnvironment.WebRootPath, "umPictures", model.ExistingPhotoPath);
                System.IO.File.Delete(filePath);
                umjetnicka.PhotoPath = ProcessUploadedFileUm(model);
                umjetnickaSlikaRepository.Update(umjetnicka);
                return RedirectToAction("UmjetnickeSlike", "home");
            }
            return View();
        }
        [HttpPost]
        public IActionResult DeleteUmjetnicka(int id)
        {
            UmjetnickaSlika umjetnicka = umjetnickaSlikaRepository.GetSlika(id);
            string filePath = Path.Combine(hostingEnvironment.WebRootPath, "umPictures", umjetnicka.PhotoPath);
            umjetnickaSlikaRepository.Delete(id);
            System.IO.File.Delete(filePath);
            return RedirectToAction("umjetnickeSlike", "home");
        }
        [HttpGet]
        public IActionResult SponzorCreate()
        {
            return View();
        }
        private string ProcessUploadedFileSponzor(SponzorCreateViewModel model)
        {
            string uniqueFileName = null;
            if (model.Slika != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "spPictures");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Slika.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Slika.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }
        [HttpPost]
        public IActionResult SponzorCreate(SponzorCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadedFileSponzor(model);
                Sponzor noviSponzor = new Sponzor()
                {
                    Naziv=model.Naziv,
                    Adresa=model.Adresa,
                    Telefon=model.Telefon,
                    Email=model.Email,
                    Link=model.Link,
                    Instagram=model.Instagram,
                    Facebook=model.Facebook,
                    Twitter=model.Twitter,
                    PhotoPath = uniqueFileName
                };
                sponzorRepository.Add(noviSponzor);
                return RedirectToAction("sponzori", "home");
            }
            return View();
        }

        [HttpGet]
        public ViewResult SponzorEdit(int id)
        {
            Sponzor sponzor = sponzorRepository.GetSponzor(id);
            SponzorEditViewModel sponzorEditViewModel = new SponzorEditViewModel()
            {
                Id=sponzor.Id,
                Naziv=sponzor.Naziv,
                Adresa=sponzor.Adresa,
                Telefon=sponzor.Telefon,
                Email=sponzor.Email,
                Link=sponzor.Link,
                Instagram=sponzor.Instagram,
                Facebook=sponzor.Facebook,
                Twitter=sponzor.Twitter,
                ExistingPhotoPath = sponzor.PhotoPath
            };
            return View(sponzorEditViewModel);

        }
        [HttpPost]
        public IActionResult SponzorEdit(SponzorEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Sponzor sponzor = sponzorRepository.GetSponzor(model.Id);
                sponzor.Naziv = model.Naziv;
                sponzor.Adresa = model.Adresa;
                sponzor.Telefon = model.Telefon;
                sponzor.Email = model.Email;
                sponzor.Link = model.Link;
                sponzor.Instagram = model.Instagram;
                sponzor.Facebook = model.Facebook;
                sponzor.Twitter = model.Twitter;
                string filePath = Path.Combine(hostingEnvironment.WebRootPath, "spPictures", model.ExistingPhotoPath);
                System.IO.File.Delete(filePath);
                sponzor.PhotoPath = ProcessUploadedFileSponzor(model);
                sponzorRepository.Update(sponzor);
                return RedirectToAction("sponzori", "home");
            }
            return View();
        }

        [HttpPost]
        public IActionResult DeleteSponzor(int id)
        {
            Sponzor sponzor = sponzorRepository.GetSponzor(id);
            string filePath = Path.Combine(hostingEnvironment.WebRootPath, "spPictures", sponzor.PhotoPath);

            sponzorRepository.Delete(id);
            System.IO.File.Delete(filePath);
            return RedirectToAction("sponzori", "home");
        }
    }
}

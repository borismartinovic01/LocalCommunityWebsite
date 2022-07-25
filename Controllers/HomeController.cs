using Brajici.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
using Brajici.Models;

namespace Brajici.Controllers
{
    public class HomeController: Controller
    {
        private readonly IStaraSlikaRepository staraSlikaRepository;
        private readonly INovaSlikaRepository novaSlikaRepository;
        private readonly IVestiRepository vestiRepository;
        private readonly IUmjetnickaSlikaRepository umjetnickaSlikaRepository;
        private readonly IEmailService emailService;
        private readonly ISponzorRepository sponzorRepository;
        private readonly IDokumentRepository dokumentRepository;
        private readonly ILinkRepository linkRepository;

        public HomeController(IStaraSlikaRepository staraSlikaRepository, INovaSlikaRepository novaSlikaRepository, IVestiRepository vestiRepository, IUmjetnickaSlikaRepository umjetnickaSlikaRepository, IEmailService emailService, ISponzorRepository sponzorRepository, IDokumentRepository dokumentRepository, ILinkRepository linkRepository)
        {
            this.staraSlikaRepository = staraSlikaRepository;
            this.novaSlikaRepository = novaSlikaRepository;
            this.vestiRepository = vestiRepository;
            this.umjetnickaSlikaRepository = umjetnickaSlikaRepository;
            this.emailService = emailService;
            this.sponzorRepository = sponzorRepository;
            this.dokumentRepository = dokumentRepository;
            this.linkRepository = linkRepository;
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Galerija()
        {
            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Kontakt()
        {
            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult PDFViewer()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Kontakt(KontaktPodaciViewModel model)
        {
            if (ModelState.IsValid)
            {
                EmailMessage emailMessage = new EmailMessage()
                {
                    ToAddress = "sajtbrajici@gmail.com",
                    FromAddress = model.Email,
                    Content = model.Poruka,
                    Subject = model.Ime
                };
                emailService.Send(emailMessage);
                return View();
            }
            
            return View();
        }

        
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Tekstovi()
        {
            return View();

        }        
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Obicaji()
        {
            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Rodoslovi()
        {
            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Topopriroda()
        {
            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Toponimi()
        {
            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Pk()
        {
            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult StareSlike()
        {
            var model = staraSlikaRepository.GetStareSlike();
            return View(model);
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult SavremeneSlike()
        {
            var model = novaSlikaRepository.GetNoveSlike();
            return View(model);
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult UmjetnickeSlike()
        {
            var model = umjetnickaSlikaRepository.GetUmjetnickeSlike();
            return View(model);
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Istorija()
        {
            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Vesti()
        {
            var model = vestiRepository.GetSveVesti();
            return View(model);
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Dokumenti()
        {
            var model = dokumentRepository.GetDokumenta();
            return View(model);
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Linkovi()
        {
            var model = linkRepository.GetLinkovi();
            return View(model);
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Atrakcije()
        {
            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Sponzori()
        {
            var model = sponzorRepository.GetSveSponzore();
            return View(model);
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Privacy()
        {
            return View();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using LiberDent.Data.Data;
using LiberDent.Data.Data.Account;
using LiberDent.PortalWWW.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LiberDent.PortalWWW.Controllers
{
    public class DbController : Controller
    {
        protected readonly UserManager<ApplicationUser> _userManager;
        protected readonly SignInManager<ApplicationUser> _signInManager;
        protected readonly IEmailSender _emailSender;
        protected readonly ILogger _logger;
        protected readonly LiberDentContext db;
        protected readonly UrlEncoder _urlEncoder;

        public DbController(UserManager<ApplicationUser> userManager,
                    SignInManager<ApplicationUser> signInManager,
                    ILogger<AccountController> logger, LiberDentContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            this.db = db;
        }
        public DbController(UserManager<ApplicationUser> userManager,
                    SignInManager<ApplicationUser> signInManager, IEmailSender emailSender,
                    ILogger<AccountController> logger, LiberDentContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _logger = logger;
            this.db = db;
        }


        public DbController(
          UserManager<ApplicationUser> userManager,
          SignInManager<ApplicationUser> signInManager,
          ILogger<ManageController> logger,
          UrlEncoder urlEncoder,
          LiberDentContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _urlEncoder = urlEncoder;
            this.db = db;
        }

        public DbController(
          UserManager<ApplicationUser> userManager,
          SignInManager<ApplicationUser> signInManager,
          IEmailSender emailSender,
          ILogger<ManageController> logger,
          UrlEncoder urlEncoder,
          LiberDentContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _logger = logger;
            _urlEncoder = urlEncoder;
            this.db = db;
        }

        public DbController(LiberDentContext db)
        {
            this.db = db;
        }

        public void WywolajViewBagi()
        {
            ViewBag.ModelKontaktGlowny =
                (
                    from kontakt in db.Kontakt
                    where kontakt.CzyAktywny == true
                    orderby kontakt.PozycjaWyswietlania
                    select kontakt
                ).ToList();
            ViewBag.ModelGodzinyOtwarcia =
                (
                    from godziny in db.GodzinyOtwarcia
                    where godziny.CzyAktywny == true
                    orderby godziny.PozycjaWyswietlania
                    select godziny
                ).ToList();
        }
        public DateTime zmienFormatDaty(DateTime data)
        {
            int dzien = data.Day;
            int miesiac = data.Month;
            int rok = data.Year;
            return new DateTime(rok, miesiac, dzien);
        }
    }
}
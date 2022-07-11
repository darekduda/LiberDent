using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using LiberDent.Data.Data;
using LiberDent.Data.Data.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LiberDent.Intranet.Controllers.Account
{
    public class DBController : Controller
    {
        protected readonly UserManager<ApplicationUser> _userManager;
        protected readonly SignInManager<ApplicationUser> _signInManager;
        protected readonly ILogger _logger;
        protected readonly LiberDentContext db;
        protected readonly UrlEncoder _urlEncoder;
        public DBController(UserManager<ApplicationUser> userManager,
                    SignInManager<ApplicationUser> signInManager,
                    ILogger<AccountController> logger, LiberDentContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            this.db = db;
        }

        public DBController(
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

        public DBController(LiberDentContext db)
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
    }
}
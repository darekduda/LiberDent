using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LiberDent.PortalWWW.Models;
using LiberDent.Data.Data;
using LiberDent.PortalWWW.Models.HomeViewModel;
using Microsoft.EntityFrameworkCore;
using LiberDent.Data.Data.CMS;
using Microsoft.AspNetCore.Identity;
using LiberDent.Data.Data.Account;
using LiberDent.PortalWWW.Services;

namespace LiberDent.PortalWWW.Controllers
{
    public class HomeController : DbController
    {
        [TempData]
        public string StatusMessage { get; set; }

        public HomeController(UserManager<ApplicationUser> userManager,
                    SignInManager<ApplicationUser> signInManager, IEmailSender emailSender,
                    ILogger<AccountController> logger, LiberDentContext db)
            : base(userManager, signInManager, emailSender, logger, db)
        {
        }

        public async Task<IActionResult> Index()
        {
            WywolajViewBagi();
            var model = await db.Powitanie.Where(a => a.CzyAktywny == true).FirstOrDefaultAsync();
            return View(model);
        }
        public async Task<IActionResult> ONas()
        {
            WywolajViewBagi();
            var model = await db.ONas.FirstOrDefaultAsync();
            return View(model);
        }
        public async Task<IActionResult> Personel()
        {
            WywolajViewBagi();
            //var model = await db.DaneLekarza.Include(d => d.Uzytkownik).Include(c=> c.Uzytkownik.Dane).ToListAsync();
            var model = await db.Users.Where(i => i.CzyLekarz == true).Include(c => c.DaneLekarza).Include(a => a.Dane).ToListAsync();
            //foreach (var item in model)
            //{
            //    item.Uzytkownik = await db.Users.FindAsync(item.IdUzytkownika);
            //    var tmp = item.Uzytkownik;
            //    item.Uzytkownik.Dane = await db.DaneUzytkownika.Where(i => i.IdUzytkownika == tmp.Id).FirstOrDefaultAsync();
            //}
            return View(model);
        }
        public async Task<IActionResult> Cennik()
        {
            WywolajViewBagi();
            var model = await db.CenyUslug.ToListAsync();
            return View(model);
        }

        //public IActionResult UmowWizyte(string str)
        //{
        //    var model = new Object();

        //    if (str == null)
        //    {
        //        model = new UmowWizyteViewModel
        //        {
        //            WybranyDzien = DateTime.Now
        //        };
        //    }
        //    else
        //    {
        //        DateTime id = Convert.ToDateTime(str);
        //        model = new UmowWizyteViewModel
        //        {
        //            WybranyDzien = (DateTime)id
        //        };
        //    }
        //    WywolajViewBagi();
        //    return View(model);
        //}

        public async Task<IActionResult> UmowWizyte()
        {
            WywolajViewBagi();
            DateTime data = zmienFormatDaty(DateTime.Now);
            var model = new UmowWizyteViewModel
            {
                WybranyDzien = data,
                ListaLekarzy = await db.DaneLekarza.Include(c => c.Uzytkownik).ThenInclude(d => d.Dane).ToListAsync(),
                ListaRodzajeWizyt = await db.RodzajeWizyty.ToListAsync(),
                GodzinyOtwarciaLista = await db.GodzinyOtwarcia.ToListAsync()
            };
            ViewData["ModelData"] = model;
            return View(model);
        }

        public async Task<IActionResult> Wizyta(string str, string id, int rod)
        {
            WywolajViewBagi();
            DateTime id2 = Convert.ToDateTime(str);
            UmowWizyteViewModel model;
            if (id==null)
            {
                model = new UmowWizyteViewModel
                {
                    WybranyDzien = id2,
                    ListaLekarzy = await db.DaneLekarza.Include(c => c.Uzytkownik).ThenInclude(d => d.Dane).ToListAsync(),
                    ListaRodzajeWizyt = await db.RodzajeWizyty.ToListAsync(),
                    GodzinyOtwarciaLista = await db.GodzinyOtwarcia.ToListAsync()
                    //db.UmowioneWizyty.Include(a => a.DaneLekarza).ThenInclude(b => b.Uzytkownik).Where(c => c.DataWizyty == id2).Where(c => c.DaneLekarza.Uzytkownik.Id == id).ToList()
                };
            }
            else
            {
                 model = new UmowWizyteViewModel
                {
                    WybranyDzien = id2,
                    ListaLekarzy = await db.DaneLekarza.Include(c => c.Uzytkownik).ThenInclude(d => d.Dane).ToListAsync(),
                    IdLekarza = id,
                    IdRodzajWizyty = rod,
                    ListaRodzajeWizyt = await db.RodzajeWizyty.ToListAsync(),
                    UmowioneWizyty = await db.UmowioneWizyty.Where(a => a.DataWizyty == id2 && a.IdLekarza == db.Users.Find(id).DaneLekarza.IdDaneLekarza).ToListAsync(),
                     GodzinyOtwarciaLista = await db.GodzinyOtwarcia.ToListAsync()
                     //db.UmowioneWizyty.Include(a => a.DaneLekarza).ThenInclude(b => b.Uzytkownik).Where(c => c.DataWizyty == id2).Where(c => c.DaneLekarza.Uzytkownik.Id == id).ToList()
                 };
            }
            
            return View("UmowWizyte", model);
        }

        public async Task<IActionResult> WizytaLekarz(string id, int rod)
        {
            WywolajViewBagi();
            DateTime data = zmienFormatDaty(DateTime.Now);
            var model = new UmowWizyteViewModel
            {
                WybranyDzien = data,
                ListaLekarzy = await db.DaneLekarza.Include(c => c.Uzytkownik).ThenInclude(d => d.Dane).ToListAsync(),
                IdLekarza = id,
                IdRodzajWizyty = rod,
                ListaRodzajeWizyt = await db.RodzajeWizyty.ToListAsync(),
                UmowioneWizyty = await db.UmowioneWizyty.Where(a => a.DataWizyty == data && a.IdLekarza == db.Users.Find(id).DaneLekarza.IdDaneLekarza).ToListAsync(),
                GodzinyOtwarciaLista = await db.GodzinyOtwarcia.ToListAsync()
                //db.UmowioneWizyty.Include(a => a.DaneLekarza).ThenInclude(b => b.Uzytkownik).Where(c => c.DataWizyty == DateTime.Now).Where(c => c.DaneLekarza.Uzytkownik.Id == id).ToList()
            };
            return View("UmowWizyte", model);
        }

        public async Task<IActionResult> UmowWizyteDoLekarza(string str, string id, int rod, string god)
        {
            WywolajViewBagi();
            var user = await _userManager.GetUserAsync(User);
            DateTime id2 = Convert.ToDateTime(str);
            TimeSpan god2 = TimeSpan.Parse(god);
            UmowioneWizyty nowaWizyta = new UmowioneWizyty()
            {
                DataWizyty = id2,
                GodzinaWizyty = god2,
                ApplicationUser = user,
                IdApplicationUser = user.Id,
                IdLekarza = db.DaneLekarza.Include(a => a.Uzytkownik).FirstOrDefaultAsync(a => a.Uzytkownik.Id == id).Result.IdDaneLekarza,
                DaneLekarza = db.DaneLekarza.Include(a => a.Uzytkownik).FirstOrDefaultAsync(a => a.Uzytkownik.Id == id).Result,
                IdRodzajeWizyty = rod,
                RodzajeWizyty = db.RodzajeWizyty.FindAsync(rod).Result,
                CzyPacjentByl = false
            };
            db.Add(nowaWizyta);
            db.SaveChanges();
            var model = new UmowWizyteViewModel
            {
                WybranyDzien = id2,
                ListaLekarzy = await db.DaneLekarza.Include(c => c.Uzytkownik).ThenInclude(d => d.Dane).ToListAsync(),
                IdLekarza = id,
                IdRodzajWizyty = rod,
                ListaRodzajeWizyt = await db.RodzajeWizyty.ToListAsync(),
                UmowioneWizyty = await db.UmowioneWizyty.Where(a => a.DataWizyty == id2 && a.IdLekarza == db.Users.Find(id).DaneLekarza.IdDaneLekarza).ToListAsync(),
                //db.UmowioneWizyty.Include(a => a.DaneLekarza).ThenInclude(b => b.Uzytkownik).Where(c => c.DataWizyty == id2).Where(c => c.DaneLekarza.Uzytkownik.Id == id).ToList(),
                StatusMessage = "Pomyślnie umówiono wizytę",
                GodzinyOtwarciaLista = await db.GodzinyOtwarcia.ToListAsync()
            };
            StatusMessage = "Pomyślnie umówiono wizytę";
            return View("UmowWizyte", model);
        }

        [HttpGet]
        public async Task<IActionResult> InfoOPersonelu(string str)
        {
            WywolajViewBagi();

            //db.DaneOPersonelu.Find(id).TytulNaukowy = db.TytulNaukowy.First();
            var dane = await db.Users.Include(a => a.Dane).Include(b => b.DaneLekarza).Where(i=>i.Id == str).FirstOrDefaultAsync();
            dane.DaneLekarza.Stanowiska = await db.Stanowiska.Where(i => i.IdStanowiska == dane.DaneLekarza.IdStanowiska).FirstOrDefaultAsync();
            dane.DaneLekarza.TytulNaukowy = await db.TytulNaukowy.Where(i => i.IdTytulNaukowy == dane.DaneLekarza.IdTytulNaukowy).FirstOrDefaultAsync();
            //dane.Stanowiska = await db.Stanowiska.FirstAsync();
            var model = new InfoOPersoneluViewModel
            {
                DaneUser = dane
            };
            //model.Dane.TytulNaukowy = await db.TytulNaukowy.FindAsync(dane.IdTytulNaukowy);
            //model.Dane.Stanowiska = await db.Stanowiska.FindAsync(dane.IdStanowiska);
            //model.Dane.Uzytkownik = await db.Users.FindAsync(dane.IdUzytkownika);
            //model.Dane.Uzytkownik.Dane = await db.DaneUzytkownika.FindAsync(dane.Uzytkownik.Dane.IdDaneUzytkownika);
            //model.Dane.Stanowiska = await db.Stanowiska.FirstAsync();

            return View(model);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult ZmienDzien(string str)
        {
            var model = new UmowWizyteViewModel
            {
                WybranyDzien = Convert.ToDateTime(str)
            };
            //DateTime id = Convert.ToDateTime(str);
            return RedirectToAction(nameof(UmowWizyte),str);
            //return View("UmowWizyte", model);
        }

        public IActionResult OtworzKalendarz(string str)
        {
            var model = new UmowWizyteViewModel
            {
                WybranyDzien = DateTime.Now,
                IdLekarza = str
            };
            //DateTime id = Convert.ToDateTime(str);
            return RedirectToAction(nameof(UmowWizyte), model);
            //return View("UmowWizyte", model);
        }
       
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LiberDent.Intranet.Models;
using Microsoft.AspNetCore.Identity;
using LiberDent.Data.Data;
using LiberDent.Data.Data.Account;

namespace LiberDent.Intranet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        protected readonly UserManager<ApplicationUser> _userManager;
        protected readonly SignInManager<ApplicationUser> _signInManager;
        protected readonly LiberDentContext db;

        public HomeController(ILogger<HomeController> logger, UserManager<ApplicationUser> userManager,
                    SignInManager<ApplicationUser> signInManager, LiberDentContext db)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            this.db = db;
        }

        public IActionResult Index()
        {
            if (_signInManager.IsSignedIn(User))
                return View("Index");
            else
                return RedirectToAction("Login", "Account");
            //return View();
        }

        public IActionResult Home()
        {
            return View("Index");
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
    }
}

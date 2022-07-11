using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using LiberDent.Data.Data;
using LiberDent.Data.Data.Account;
using LiberDent.Intranet.Controllers.Account;
using LiberDent.Intranet.Models.Account.AccountViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LiberDent.Intranet.Controllers
{
    public class AccountController : DBController
    {
        public AccountController(
                    UserManager<ApplicationUser> userManager,
                    SignInManager<ApplicationUser> signInManager,
                    ILogger<AccountController> logger, LiberDentContext db)
            : base(userManager, signInManager, logger, db)
        {
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}

        #region Helpers
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }
        #endregion

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            WywolajViewBagi();
            var model = new RegisterViewModel
            {
                Stanowiska = db.Stanowiska.ToList(),
                TytulNaukowy = db.TytulNaukowy.ToList(),
                PoziomUprawnienLista = db.PoziomUprawnien.ToList()
            };
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    DaneLekarza = model.Dane,
                    CzyLekarz = true,
                    
                    //Imie = model.DaneUzytkownika.Imie,
                    //DrugieImie = model.DaneUzytkownika.DrugieImie,
                    //Nazwisko = model.DaneUzytkownika.Nazwisko,
                    //Adres = new AdresUzytkownika()
                    //{
                    //    Miejscowosc = model.DaneUzytkownika.Adres.Miejscowosc,
                    //    Ulica = model.DaneUzytkownika.Adres.Ulica,
                    //    NumerDomu = model.DaneUzytkownika.Adres.NumerDomu,
                    //    NumerLokalu = model.DaneUzytkownika.Adres.NumerLokalu,
                    //    KodPocztowy = model.DaneUzytkownika.Adres.KodPocztowy,
                    //    Poczta = model.DaneUzytkownika.Adres.Poczta,
                    //}
                };
                user.DaneLekarza.IdPoziomUprawnien = model.IdPoziomUprawnien;
                user.DaneLekarza.PoziomUprawnien = db.PoziomUprawnien.Find(model.IdPoziomUprawnien);
                user.Adres = new AdresUzytkownika()
                {
                    KodPocztowy = "00-000",
                    Miejscowosc = " ",
                    NumerDomu = " ",
                    NumerLokalu =" ",
                    Poczta = " ",
                    Ulica = " "
                    
                };
                user.Dane = new DaneUzytkownika()
                {
                    DataUrodzenia = DateTime.Now,
                    Imie = " ",
                    Nazwisko = " ",
                    NumerPESEL = " "
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    //await _signInManager.SignInAsync(user, isPersistent: false);
                    _logger.LogInformation("User created a new account with password.");
                    return RedirectToLocal(returnUrl);
                }
                AddErrors(result);
            }
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Lockout()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            WywolajViewBagi();
            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            var czyLekarz = db.Users.Where(i => i.Email == model.Email).FirstOrDefault().CzyLekarz;
            if (czyLekarz == true)
            {
                if (ModelState.IsValid)
                {
                    // This does not count login failures towards account lockout
                    // To enable password failures to trigger account lockout,
                    // set lockoutOnFailure: true
                    var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                    result =await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, lockoutOnFailure: false);
                    if (result.Succeeded)
                    {
                        _logger.LogInformation("Zalogowano");
                        return RedirectToAction("Home", "Home");
                    }
                    //if (result.RequiresTwoFactor)
                    //{
                    //    return RedirectToAction(nameof(LoginWith2fa), new { returnUrl, model.RememberMe });
                    //}
                    if (result.IsLockedOut)
                    {
                        _logger.LogWarning("Konto jest zablokowane.");
                        return RedirectToAction(nameof(Lockout));
                    }
                    else
                    {
                        result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                        if (result.Succeeded)
                        {
                            _logger.LogInformation("Zalogowano");
                            return RedirectToAction("Home", "Home");
                        }
                        ModelState.AddModelError(string.Empty, "Błąd danych.");
                        return View(model);
                    }
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Błąd danych.");
                return View(model);
            }

            // If execution got this far, something failed, redisplay the form.
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("Wylogowano.");
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        //===================
        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public IActionResult ExternalLogin(string provider, string returnUrl = null)
        //{
        //    // Request a redirect to the external login provider.
        //    var redirectUrl = Url.Action(nameof(ExternalLoginCallback), "Account", new { returnUrl });
        //    var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
        //    return Challenge(properties, provider);
        //}

        //[HttpGet]
        //[AllowAnonymous]
        //public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null, string remoteError = null)
        //{
        //    if (remoteError != null)
        //    {
        //        _logger.LogInformation("Error from external provider:");
        //        return RedirectToAction(nameof(Login));
        //    }
        //    var info = await _signInManager.GetExternalLoginInfoAsync();
        //    if (info == null)
        //    {
        //        return RedirectToAction(nameof(Login));
        //    }

        //    // Sign in the user with this external login provider if the user already has a login.
        //    var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);
        //    if (result.Succeeded)
        //    {
        //        _logger.LogInformation("User logged in with {Name} provider.", info.LoginProvider);
        //        return RedirectToLocal(returnUrl);
        //    }
        //    if (result.IsLockedOut)
        //    {
        //        return RedirectToAction(nameof(Lockout));
        //    }
        //    else
        //    {
        //        // If the user does not have an account, then ask the user to create an account.
        //        ViewData["ReturnUrl"] = returnUrl;
        //        ViewData["LoginProvider"] = info.LoginProvider;
        //        var email = info.Principal.FindFirstValue(ClaimTypes.Email);
        //        var name = info.Principal.FindFirstValue(ClaimTypes.Name);
        //        var dob = info.Principal.FindFirstValue(ClaimTypes.DateOfBirth);
        //        return View("ExternalLogin", new ExternalLoginViewModel
        //        {
        //            Email = email,
        //            Name = name,
        //            //DOB = dob.ToString()
        //        });
        //    }
        //}

        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> ExternalLoginConfirmation(ExternalLoginViewModel model, string returnUrl = null)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        // Get the information about the user from the external login provider
        //        var info = await _signInManager.GetExternalLoginInfoAsync();
        //        if (info == null)
        //        {
        //            throw new ApplicationException("Error loading external login information during confirmation.");
        //        }
        //        var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
        //        var result = await _userManager.CreateAsync(user);
        //        if (result.Succeeded)
        //        {
        //            result = await _userManager.AddLoginAsync(user, info);
        //            if (result.Succeeded)
        //            {
        //                await _signInManager.SignInAsync(user, isPersistent: false);
        //                _logger.LogInformation("User created an account using {Name} provider.", info.LoginProvider);
        //                return RedirectToLocal(returnUrl);
        //            }
        //        }
        //        AddErrors(result);
        //    }

        //    ViewData["ReturnUrl"] = returnUrl;
        //    return View(nameof(ExternalLogin), model);
        //}

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{userId}'.");
            }
            var result = await _userManager.ConfirmEmailAsync(user, code);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }
    }
}
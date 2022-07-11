﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using LiberDent.Data.Data;
using LiberDent.Data.Data.Account;
using LiberDent.Intranet.Models.Account.ManageViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LiberDent.Intranet.Controllers.Account
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class ManageController : DBController
    {

        private const string AuthenticatorUriFormat = "otpauth://totp/{0}:{1}?secret={2}&issuer={0}&digits=6";
        private const string RecoveryCodesKey = nameof(RecoveryCodesKey);

        public ManageController(
          UserManager<ApplicationUser> userManager,
          SignInManager<ApplicationUser> signInManager,
          ILogger<ManageController> logger,
          UrlEncoder urlEncoder,
          LiberDentContext db)
            : base(userManager, signInManager, logger, urlEncoder, db)
        {

        }

        [TempData]
        public string StatusMessage { get; set; }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            WywolajViewBagi();
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var model = new IndexViewModel()
            {
                Username = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                IsEmailConfirmed = user.EmailConfirmed,
                StatusMessage = StatusMessage,
                //DaneUzytkownika = new ApplicationUser()
                //{
                //    //UserName = user.UserName,
                //    //Email = user.Email,
                //    PhoneNumber = user.PhoneNumber,
                //    //PhoneNumber = user.PhoneNumber,
                //    Imie = user.Imie,
                //    DrugieImie = user.DrugieImie,
                //    Nazwisko = user.Nazwisko,
                //Adres = user.Adres


                //Adres = new AdresUzytkownika
                //{
                //    IdAdresu = user.Adres.IdAdresu,
                //    Miejscowosc = user.Adres.Miejscowosc,
                //    Ulica = user.Adres.Ulica,
                //    NumerDomu = user.Adres.NumerDomu,
                //    NumerLokalu = user.Adres.NumerLokalu,
                //    KodPocztowy = user.Adres.KodPocztowy,
                //    Poczta = user.Adres.Poczta,
                //}
                //Adres = new AdresUzytkownika()
                //{
                //    IdAdresu = user.Adres.IdAdresu,
                //    Miejscowosc = user.Adres.Miejscowosc,
                //    Ulica = user.Adres.Ulica,
                //    NumerDomu = user.Adres.NumerDomu,
                //    NumerLokalu = user.Adres.NumerLokalu,
                //    KodPocztowy = user.Adres.KodPocztowy,
                //    Poczta = user.Adres.Poczta,
                //}


                //}

            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(IndexViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var username = user.UserName;
            if (model.Username != username)
            {
                var setUserNameResult = await _userManager.SetUserNameAsync(user, model.Username);
                if (!setUserNameResult.Succeeded)
                {
                    throw new ApplicationException($"Unexpected error occurred setting email for user with ID '{user.Id}'.");
                }
            }

            var email = user.Email;
            if (model.Email != email)
            {
                var setEmailResult = await _userManager.SetEmailAsync(user, model.Email);
                if (!setEmailResult.Succeeded)
                {
                    throw new ApplicationException($"Unexpected error occurred setting email for user with ID '{user.Id}'.");
                }
            }

            var phoneNumber = user.PhoneNumber;
            if (model.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, model.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    throw new ApplicationException($"Unexpected error occurred setting phone number for user with ID '{user.Id}'.");
                }
            }

            //if(model.DaneUzytkownika.Imie != user.Imie)
            //    setImie(user,model.DaneUzytkownika.Imie);

            //if (model.DaneUzytkownika.Nazwisko != user.Nazwisko)
            //    setNazwisko(user, model.DaneUzytkownika.Nazwisko);

            //if (model.DaneUzytkownika.Imie != user.DrugieImie)
            //    setDrugieImie(user, model.DaneUzytkownika.DrugieImie);

            await _userManager.UpdateAsync(user);
            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Profil został zaktualizowany";
            return RedirectToAction(nameof(Index));
        }

        //[HttpGet]
        //public async Task<IActionResult> OptionalInformation()
        //{
        //    var user = await _userManager.GetUserAsync(User);
        //    if (user == null)
        //    {
        //        throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
        //    }

        //    var model = new OptionalInformationViewModel
        //    {
        //        FirstName = user.FirstName,
        //        LastName = user.LastName,
        //        Address = user.Address,
        //        BirthDate = user.BirthDate
        //    };

        //    return View(model);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> OptionalInformation(OptionalInformationViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }

        //    var user = await _userManager.GetUserAsync(User);
        //    if (user == null)
        //    {
        //        throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
        //    }


        //    if (model.FirstName != user.FirstName)
        //        user.FirstName = model.FirstName;
        //    if (model.LastName != user.LastName)
        //        user.LastName = model.LastName;
        //    if (model.Address != user.Address)
        //        user.Address = model.Address;
        //    if (model.BirthDate != user.BirthDate)
        //        user.BirthDate = model.BirthDate;

        //    await _userManager.UpdateAsync(user);
        //    await _signInManager.RefreshSignInAsync(user);
        //    StatusMessage = "Your profile has been updated";
        //    return RedirectToAction(nameof(Index));
        //}

        [HttpGet]
        public async Task<IActionResult> ChangePassword()
        {
            WywolajViewBagi();
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var hasPassword = await _userManager.HasPasswordAsync(user);
            if (!hasPassword)
            {
                return RedirectToAction(nameof(SetPassword));
            }

            var model = new ChangePasswordViewModel { StatusMessage = StatusMessage };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var changePasswordResult = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
            if (!changePasswordResult.Succeeded)
            {
                AddErrors(changePasswordResult);
                return View(model);
            }

            await _signInManager.SignInAsync(user, isPersistent: false);
            _logger.LogInformation("User changed their password successfully.");
            StatusMessage = "Twoje hasło zostało zmienione.";

            return RedirectToAction(nameof(ChangePassword));
        }

        [HttpGet]
        public async Task<IActionResult> SetPassword()
        {
            WywolajViewBagi();
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var hasPassword = await _userManager.HasPasswordAsync(user);

            if (hasPassword)
            {
                return RedirectToAction(nameof(ChangePassword));
            }

            var model = new SetPasswordViewModel { StatusMessage = StatusMessage };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SetPassword(SetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var addPasswordResult = await _userManager.AddPasswordAsync(user, model.NewPassword);
            if (!addPasswordResult.Succeeded)
            {
                AddErrors(addPasswordResult);
                return View(model);
            }

            await _signInManager.SignInAsync(user, isPersistent: false);
            StatusMessage = "Twoje hasło zostało ustawione.";

            return RedirectToAction(nameof(SetPassword));
        }

        [HttpGet]
        public async Task<IActionResult> ExternalLogins()
        {
            WywolajViewBagi();
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var model = new ExternalLoginsViewModel { CurrentLogins = await _userManager.GetLoginsAsync(user) };
            model.OtherLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync())
                .Where(auth => model.CurrentLogins.All(ul => auth.Name != ul.LoginProvider))
                .ToList();
            model.ShowRemoveButton = await _userManager.HasPasswordAsync(user) || model.CurrentLogins.Count > 1;
            model.StatusMessage = StatusMessage;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LinkLogin(string provider)
        {
            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            // Request a redirect to the external login provider to link a login for the current user
            var redirectUrl = Url.Action(nameof(LinkLoginCallback));
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl, _userManager.GetUserId(User));
            return new ChallengeResult(provider, properties);
        }

        [HttpGet]
        public async Task<IActionResult> LinkLoginCallback()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var info = await _signInManager.GetExternalLoginInfoAsync(user.Id);
            if (info == null)
            {
                throw new ApplicationException($"Unexpected error occurred loading external login info for user with ID '{user.Id}'.");
            }

            var result = await _userManager.AddLoginAsync(user, info);
            if (!result.Succeeded)
            {
                throw new ApplicationException($"Unexpected error occurred adding external login for user with ID '{user.Id}'.");
            }

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            StatusMessage = "Powiązane konto zostało poprawnie dodane.";
            return RedirectToAction(nameof(ExternalLogins));
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> RemoveLogin(RemoveLoginViewModel model)
        //{
        //    var user = await _userManager.GetUserAsync(User);
        //    if (user == null)
        //    {
        //        throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
        //    }

        //    var result = await _userManager.RemoveLoginAsync(user, model.LoginProvider, model.ProviderKey);
        //    if (!result.Succeeded)
        //    {
        //        throw new ApplicationException($"Unexpected error occurred removing external login for user with ID '{user.Id}'.");
        //    }

        //    await _signInManager.SignInAsync(user, isPersistent: false);
        //    StatusMessage = "The external login was removed.";
        //    return RedirectToAction(nameof(ExternalLogins));
        //}

        //[HttpGet]
        //public async Task<IActionResult> TwoFactorAuthentication()
        //{
        //    var user = await _userManager.GetUserAsync(User);
        //    if (user == null)
        //    {
        //        throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
        //    }

        //    var model = new TwoFactorAuthenticationViewModel
        //    {
        //        HasAuthenticator = await _userManager.GetAuthenticatorKeyAsync(user) != null,
        //        Is2faEnabled = user.TwoFactorEnabled,
        //        RecoveryCodesLeft = await _userManager.CountRecoveryCodesAsync(user),
        //    };

        //    return View(model);
        //}

        //[HttpGet]
        //public async Task<IActionResult> Disable2faWarning()
        //{
        //    var user = await _userManager.GetUserAsync(User);
        //    if (user == null)
        //    {
        //        throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
        //    }

        //    if (!user.TwoFactorEnabled)
        //    {
        //        throw new ApplicationException($"Unexpected error occurred disabling 2FA for user with ID '{user.Id}'.");
        //    }

        //    return View(nameof(Disable2fa));
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Disable2fa()
        //{
        //    var user = await _userManager.GetUserAsync(User);
        //    if (user == null)
        //    {
        //        throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
        //    }

        //    var disable2faResult = await _userManager.SetTwoFactorEnabledAsync(user, false);
        //    if (!disable2faResult.Succeeded)
        //    {
        //        throw new ApplicationException($"Unexpected error occurred disabling 2FA for user with ID '{user.Id}'.");
        //    }

        //    _logger.LogInformation("User with ID {UserId} has disabled 2fa.", user.Id);
        //    return RedirectToAction(nameof(TwoFactorAuthentication));
        //}

        //[HttpGet]
        //public async Task<IActionResult> EnableAuthenticator()
        //{
        //    var user = await _userManager.GetUserAsync(User);
        //    if (user == null)
        //    {
        //        throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
        //    }

        //    var model = new EnableAuthenticatorViewModel();
        //    await LoadSharedKeyAndQrCodeUriAsync(user, model);

        //    return View(model);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> EnableAuthenticator(EnableAuthenticatorViewModel model)
        //{
        //    var user = await _userManager.GetUserAsync(User);
        //    if (user == null)
        //    {
        //        throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
        //    }

        //    if (!ModelState.IsValid)
        //    {
        //        await LoadSharedKeyAndQrCodeUriAsync(user, model);
        //        return View(model);
        //    }

        //    // Strip spaces and hypens
        //    var verificationCode = model.Code.Replace(" ", string.Empty).Replace("-", string.Empty);

        //    var is2faTokenValid = await _userManager.VerifyTwoFactorTokenAsync(
        //        user, _userManager.Options.Tokens.AuthenticatorTokenProvider, verificationCode);

        //    if (!is2faTokenValid)
        //    {
        //        ModelState.AddModelError("Code", "Verification code is invalid.");
        //        await LoadSharedKeyAndQrCodeUriAsync(user, model);
        //        return View(model);
        //    }

        //    await _userManager.SetTwoFactorEnabledAsync(user, true);
        //    _logger.LogInformation("User with ID {UserId} has enabled 2FA with an authenticator app.", user.Id);
        //    var recoveryCodes = await _userManager.GenerateNewTwoFactorRecoveryCodesAsync(user, 10);
        //    TempData[RecoveryCodesKey] = recoveryCodes.ToArray();

        //    return RedirectToAction(nameof(ShowRecoveryCodes));
        //}

        //[HttpGet]
        //public IActionResult ShowRecoveryCodes()
        //{
        //    var recoveryCodes = (string[])TempData[RecoveryCodesKey];
        //    if (recoveryCodes == null)
        //    {
        //        return RedirectToAction(nameof(TwoFactorAuthentication));
        //    }

        //    var model = new ShowRecoveryCodesViewModel { RecoveryCodes = recoveryCodes };
        //    return View(model);
        //}

        //[HttpGet]
        //public IActionResult ResetAuthenticatorWarning()
        //{
        //    return View(nameof(ResetAuthenticator));
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> ResetAuthenticator()
        //{
        //    var user = await _userManager.GetUserAsync(User);
        //    if (user == null)
        //    {
        //        throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
        //    }

        //    await _userManager.SetTwoFactorEnabledAsync(user, false);
        //    await _userManager.ResetAuthenticatorKeyAsync(user);
        //    _logger.LogInformation("User with id '{UserId}' has reset their authentication app key.", user.Id);

        //    return RedirectToAction(nameof(EnableAuthenticator));
        //}

        //[HttpGet]
        //public async Task<IActionResult> GenerateRecoveryCodesWarning()
        //{
        //    var user = await _userManager.GetUserAsync(User);
        //    if (user == null)
        //    {
        //        throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
        //    }

        //    if (!user.TwoFactorEnabled)
        //    {
        //        throw new ApplicationException($"Cannot generate recovery codes for user with ID '{user.Id}' because they do not have 2FA enabled.");
        //    }

        //    return View(nameof(GenerateRecoveryCodes));
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> GenerateRecoveryCodes()
        //{
        //    var user = await _userManager.GetUserAsync(User);
        //    if (user == null)
        //    {
        //        throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
        //    }

        //    if (!user.TwoFactorEnabled)
        //    {
        //        throw new ApplicationException($"Cannot generate recovery codes for user with ID '{user.Id}' as they do not have 2FA enabled.");
        //    }

        //    var recoveryCodes = await _userManager.GenerateNewTwoFactorRecoveryCodesAsync(user, 10);
        //    _logger.LogInformation("User with ID {UserId} has generated new 2FA recovery codes.", user.Id);

        //    var model = new ShowRecoveryCodesViewModel { RecoveryCodes = recoveryCodes.ToArray() };

        //    return View(nameof(ShowRecoveryCodes), model);
        //}

        #region Helpers

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        private string FormatKey(string unformattedKey)
        {
            var result = new StringBuilder();
            int currentPosition = 0;
            while (currentPosition + 4 < unformattedKey.Length)
            {
                result.Append(unformattedKey.Substring(currentPosition, 4)).Append(" ");
                currentPosition += 4;
            }
            if (currentPosition < unformattedKey.Length)
            {
                result.Append(unformattedKey.Substring(currentPosition));
            }

            return result.ToString().ToLowerInvariant();
        }

        private string GenerateQrCodeUri(string email, string unformattedKey)
        {
            return string.Format(
                AuthenticatorUriFormat,
                _urlEncoder.Encode("IdentityDemo"),
                _urlEncoder.Encode(email),
                unformattedKey);
        }

        //private async Task LoadSharedKeyAndQrCodeUriAsync(ApplicationUser user, EnableAuthenticatorViewModel model)
        //{
        //    var unformattedKey = await _userManager.GetAuthenticatorKeyAsync(user);
        //    if (string.IsNullOrEmpty(unformattedKey))
        //    {
        //        await _userManager.ResetAuthenticatorKeyAsync(user);
        //        unformattedKey = await _userManager.GetAuthenticatorKeyAsync(user);
        //    }

        //    model.SharedKey = FormatKey(unformattedKey);
        //    model.AuthenticatorUri = GenerateQrCodeUri(user.Email, unformattedKey);
        //}

        #endregion

        #region Helpers
        //private bool setImie(ApplicationUser user1, string imie)
        //{
        //    user1.Imie = imie;
        //    return true;
        //}
        //private bool setNazwisko(ApplicationUser user1, string nazwisko)
        //{
        //    user1.Nazwisko = nazwisko;
        //    return true;
        //}
        //private bool setDrugieImie(ApplicationUser user1, string drugieImie)
        //{
        //    user1.DrugieImie = drugieImie;
        //    return true;
        //}
        #endregion Helpers

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DaneUzytkownika(DaneUzytkownikaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            var daneU = await db.DaneUzytkownika.FirstAsync(item => item.Uzytkownik == user);
            //user.Dane = model.Dane;
            if (model.Dane.Imie != daneU.Imie)
                daneU.Imie = model.Dane.Imie;
            if (model.Dane.Nazwisko != daneU.Nazwisko)
                daneU.Nazwisko = model.Dane.Nazwisko;
            if (model.Dane.DataUrodzenia != daneU.DataUrodzenia)
                daneU.DataUrodzenia = model.Dane.DataUrodzenia;
            if (model.Dane.NumerPESEL != daneU.NumerPESEL)
                daneU.NumerPESEL = model.Dane.NumerPESEL;

            await _userManager.UpdateAsync(user);
            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Profil został zaktualizowany";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> DaneUzytkownika()
        {
            WywolajViewBagi();
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var daneU = await db.DaneUzytkownika.FirstAsync(item => item.Uzytkownik == user);
            var model = new DaneUzytkownikaViewModel
            {
                Dane = daneU
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DaneAdresowe(DaneAdresoweViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            var daneA = await db.AdresUzytkownika.FirstAsync(item => item.Uzytkownik == user);
            if (model.Adres.Miejscowosc != daneA.Miejscowosc)
                daneA.Miejscowosc = model.Adres.Miejscowosc;
            if (model.Adres.Ulica != daneA.Ulica)
                daneA.Ulica = model.Adres.Ulica;
            if (model.Adres.NumerDomu != daneA.NumerDomu)
                daneA.NumerDomu = model.Adres.NumerDomu;
            if (model.Adres.NumerLokalu != daneA.NumerLokalu)
                daneA.NumerLokalu = model.Adres.NumerLokalu;
            if (model.Adres.KodPocztowy != daneA.KodPocztowy)
                daneA.KodPocztowy = model.Adres.KodPocztowy;
            if (model.Adres.Poczta != daneA.Poczta)
                daneA.Poczta = model.Adres.Poczta;

            await _userManager.UpdateAsync(user);
            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Profil został zaktualizowany";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> DaneAdresowe()
        {
            WywolajViewBagi();
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }


            var daneU = await db.AdresUzytkownika.FirstAsync(item => item.Uzytkownik == user);
            var model = new DaneAdresoweViewModel
            {
                Adres = daneU
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DaneLekarza(DaneLekarzaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            var daneA = await db.DaneLekarza.FirstAsync(item => item.Uzytkownik == user);
            if (model.DaneLekarza.IdStanowiska != daneA.IdStanowiska)
            {
                daneA.IdStanowiska = model.DaneLekarza.IdStanowiska;
                daneA.Stanowiska = await db.Stanowiska.FindAsync(model.DaneLekarza.IdStanowiska);
            }
            if (model.DaneLekarza.IdTytulNaukowy != daneA.IdTytulNaukowy)
            {
                daneA.IdTytulNaukowy = model.DaneLekarza.IdTytulNaukowy;
                daneA.TytulNaukowy = await db.TytulNaukowy.FindAsync(model.DaneLekarza.IdTytulNaukowy);
            }
            if (model.DaneLekarza.Opis != daneA.Opis)
                daneA.Opis = model.DaneLekarza.Opis;
            await _userManager.UpdateAsync(user);
            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Profil został zaktualizowany";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> DaneLekarza()
        {
            WywolajViewBagi();
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            var daneU = await db.DaneLekarza.FirstAsync(item => item.Uzytkownik == user);
            var model = new DaneLekarzaViewModel
            {
                DaneLekarza = daneU,
                Stanowiska = await db.Stanowiska.ToListAsync(),
                TytulNaukowy = await db.TytulNaukowy.ToListAsync()
            };
            return View(model);
        }

        public async Task<IActionResult> MojeWizyty(string str)
        {
            WywolajViewBagi();
            DateTime id2;
            if (str == null)
                id2 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            else
                id2 = Convert.ToDateTime(str);
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            var model = new MojeWizytyViewModel
            {
                UmowioneWizyty = db.UmowioneWizyty.Include(a=>a.DaneLekarza).ThenInclude(a=>a.Uzytkownik).Where(b=>b.DaneLekarza.Uzytkownik.Id == _userManager.GetUserId(User)).Include(a=>a.ApplicationUser).ThenInclude(a=>a.Dane).Where(a=>a.DataWizyty == id2).ToList(),
                WybranyDzien = id2,
                GodzinyOtwarciaLista = await db.GodzinyOtwarcia.ToListAsync()
            };
            return View(model);
        }


        public async Task<IActionResult> InfoOPacjencie(string id, int wiz)
        {
            var model = new InfoOPacjecieViewModel
            {
                Pacjent = await db.Users.Include(c => c.Dane).Include(c => c.Adres).Where(a => a.Id == id).FirstOrDefaultAsync(),
                Wizyta = await db.UmowioneWizyty.FindAsync(wiz)
            };
            return View(model);
        }
        public async Task<IActionResult> ZapiszInfoOPacjencie(int wiz, bool id)
        {
            var wizyta = await db.UmowioneWizyty.FindAsync(wiz);
            wizyta.CzyPacjentByl = id;
            db.Update(wizyta);
            await db.SaveChangesAsync();
            return RedirectToAction("MojeWizyty");
        }
    }
}
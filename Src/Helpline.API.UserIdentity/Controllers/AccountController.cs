using Helpline.API.UserIdentity.Models;
using Helpline.Domain.Models.Entities;
using Helpline.Domain.Models.Types;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace Helpline.API.UserIdentity.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Register(string? returnurl = null)
        {
            if (!_roleManager.RoleExistsAsync(RoleType.Guest.ToString()).GetAwaiter().GetResult())
            {
                await _roleManager.CreateAsync(new IdentityRole(RoleType.Guest.ToString()));
                // await _userManager.AddClaimAsync(new Claim("Permission", PermissionType.Guest.ToString()));
            }

            ViewData["ReturnUrl"] = returnurl;
            RegisterViewModel registerViewModel = new()
            {
                RoleList = _roleManager.Roles.Select(x => x.Name).Select(i => new SelectListItem()
                {
                    Text = i,
                    Value = i
                })
            };

            return View(registerViewModel);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model, string? returnurl = null)
        {
            ViewData["ReturnUrl"] = returnurl;
            returnurl = returnurl ?? Url.Content("~/");

            if (ModelState.IsValid)
            {
                var user = new ApplicationUser()
                {
                    UserName = model.Email,
                    Email = model.Email,
                    PasswordHash = model.Password,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Role = (RoleType)(model.RoleSelected is null ?
                        RoleType.Guest : model.RoleSelected),
                    Permissions = (PermissionType)(model.PermissionSelected is null ?
                        PermissionType.None : model.PermissionSelected)
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    if (model.RoleSelected != null)
                    {
                        await _userManager.AddToRoleAsync(user, model.RoleSelected.ToString()!);
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(user, RoleType.None.ToString());
                    }

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackurl = Url.Action("ConfirmEmail", "Account", new
                    {
                        userid = user.Id,
                        code
                    }, protocol: HttpContext.Request.Scheme);

                    // Setup Email Service here to send email to confirm user's email
                    //await _emailSender.SendEmailAsync(model.Email, "Confirm Email - Identity Manager",
                    //                       $"Please confirm your email by clicking here: <a href='{callbackurl}'>link</a>");

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnurl);
                }

                AddErrors(result);
            }

            model.RoleList = _roleManager.Roles.Select(x => x.Name).Select(i => new SelectListItem
            {
                Text = i,
                Value = i
            });
            return View(model);
        }

        [AllowAnonymous]
        public IActionResult Login(string? returnurl = null)
        {
            ViewData["ReturnUrl"] = returnurl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string? returnurl = null)
        {
            ViewData["ReturnUrl"] = returnurl;
            returnurl = returnurl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe,
                    lockoutOnFailure: true);
                if (result.Succeeded)
                {
                    var user = await _userManager.GetUserAsync(User);
                    if (user is null)
                        return View("Error");

                    var claim = await _userManager.GetClaimsAsync(user);

                    if (claim.Count > 0)
                    {
                        await _userManager.RemoveClaimAsync(user, claim.FirstOrDefault(u => u.Type == "FirstName")!);
                    }
                    await _userManager.AddClaimAsync(user, new Claim("FirstName", user.FirstName));

                    return LocalRedirect(returnurl);
                }
                if (result.RequiresTwoFactor)
                {
                    return RedirectToAction(nameof(VerifyAuthenticatorCode), new { returnurl, model.RememberMe });
                }
                if (result.IsLockedOut)
                {
                    return View("Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }
            }
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> VerifyAuthenticatorCode(bool rememberMe, string? returnUrl = null)
        {
            var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();
            if (user is null)
                return View("Error");

            ViewData["ReturnUrl"] = returnUrl;

            return View(new VerifyAuthenticatorViewModel { ReturnUrl = returnUrl, RememberMe = rememberMe });

        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
    }
}

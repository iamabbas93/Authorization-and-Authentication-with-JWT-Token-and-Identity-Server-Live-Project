using IKonnect_LiveCare.Dtos.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IKonnect_LiveCare.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        [Route("Account/Index")]
      
        public IActionResult Index()
        {

            if (!_signInManager.IsSignedIn(User))
            {
                return RedirectToAction( "Login","Account");
            }

            return View();
        }

        [HttpGet]
        [Route("Account/Login")]
        public IActionResult Login()
        {

            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("swagger", "index");
            }

            return View();
        }

        [HttpGet]
        [Route("Account/Register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Route("Account/Register")]
        public IActionResult Register(registerwithImage dyn)
        {
            return View();
        }

        [HttpGet]
        [Route("Account/VerifyEmail")]
        public async Task<IActionResult> VerifyEmail(string userId,string code)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return BadRequest();
            var result = await _userManager.ConfirmEmailAsync(user, code);
            if (result.Succeeded)
            {
                return View();
            }
            return BadRequest();

            
        }

    }
}

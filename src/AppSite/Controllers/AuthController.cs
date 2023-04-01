using AppSite.Helpers;
using AppSite.ViewModels;
using Business.Interfaces.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppSite.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ICookieService _cookieService;

        public AuthController(IUserRepository userRepository, ICookieService cookieService)
        {
            _userRepository = userRepository;
            _cookieService = cookieService;
        }

        public async Task<IActionResult> Login()
        {
            if (await _cookieService.IsAuthenticated())
                return RedirectToAction("index", "home");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            var user = await _userRepository.GetByLogin(loginViewModel.User);

            if (user == null || user.Password != loginViewModel.Password)
            {
                TempData["errologin"] = "Usuário ou senha inválidos";
                return View(loginViewModel);
            }
            
            await _cookieService.AddCookie(user);
            return RedirectToAction("index","home");
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _cookieService.RemoveCookie();
            return RedirectToAction("login", "auth");
        }


        public IActionResult ResetPassword()
        {
            return View();
        }
    }
}

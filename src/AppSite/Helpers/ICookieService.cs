﻿using Business.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace AppSite.Helpers
{
    public interface ICookieService
    {
        Task AddCookie(User user);
        Task RemoveCookie();
        Task<bool> IsAuthenticated(); 

    }
    public class CookieService : ICookieService
    {
        private readonly IHttpContextAccessor _http;

        public CookieService(IHttpContextAccessor http)
        {
            _http = http;
        }

        public async Task AddCookie(User user)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.Name));
            claims.Add(new Claim(ClaimTypes.Role, user.UserType.Name));
            claims.Add(new Claim("Id", user.Id.ToString()));

            var claimsIdentity =
                new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme));

            var authProperties = new AuthenticationProperties()
            {
                ExpiresUtc = DateTime.UtcNow.AddHours(1),
                IssuedUtc = DateTime.UtcNow
            };
            await _http.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsIdentity, authProperties);

        }

        public async Task<bool> IsAuthenticated()
        {
            return _http.HttpContext.User.Identity.IsAuthenticated;
        }

        public async Task RemoveCookie()
        {
            await _http.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}

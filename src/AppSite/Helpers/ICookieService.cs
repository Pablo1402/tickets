using Business.Entities;
using Microsoft.AspNetCore.Http;

namespace AppSite.Helpers
{
    public interface ICookieService
    {
        Task AddCookie(User user);
        Task RemoveCookie();
        Task<bool> IsAuthenticated(); 

    }
}

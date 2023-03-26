using AppSite.Helpers;
using Business.Repositories;
using Data.Repository;

namespace AppSite.Config
{
    public static class IoCConfiguration
    {
        public static IServiceCollection Configure (this IServiceCollection services)
        {
            services.AddScoped<IStoreRepository, StoreRepository>();
            services.AddScoped<IStorePlanRepository, StorePlanRepository>();
            services.AddScoped<IUserRepository, UserRepository>();




            services.AddTransient<ICookieService, CookieService>();
            return services;

        }
    }
}

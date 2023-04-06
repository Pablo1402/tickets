using AppSite.Helpers;
using Business.Interfaces.Repositories;
using Business.Interfaces.Services;
using Business.Services;
using Data.Repository;

namespace AppSite.Config
{
    public static class IoCConfiguration
    {
        public static IServiceCollection ConfigureRepositories (this IServiceCollection services)
        {
            services.AddScoped<IStoreRepository, StoreRepository>();
            services.AddScoped<IStorePlanRepository, StorePlanRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserTypeRepository, UserTypeRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();

            return services;

        }

        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddTransient<ICookieService, CookieService>();
            services.AddScoped<IUserTypeService, UserTypeService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IClientService, ClientService>();
            return services;

        }

        public static IServiceCollection ConfigureProxies(this IServiceCollection services)
        {
            return services;

        }


    }
}

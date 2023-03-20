using AppSite.ViewModels;
using AutoMapper;
using Business.Entities;

namespace AppSite.Config
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<Store, StoreViewModel>().ReverseMap();
            CreateMap<StorePlan, StorePlanViewModel>().ReverseMap();
        }
    }
}

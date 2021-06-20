using AutoMapper;
using Test1.Model;

namespace Test1.ViewModel
{
    public class Mapping : Profile
    {
        public Mapping()
        {

            CreateMap<Customer, CustomerVM>()
                /*.ForMember(dest => dest.ProfileImage, act => act.MapFrom(src => src.ImageUrl))*/    
                .ReverseMap();
            CreateMap<User, UserVM>().ReverseMap();
            CreateMap<User, LoginVM>().ReverseMap();
            CreateMap<Product, ProductVM>().ReverseMap();
        }
    }
}
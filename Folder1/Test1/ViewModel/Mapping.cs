using AutoMapper;
using Test1.Model;

namespace Test1.ViewModel
{
    public class Mapping : Profile
    {
        public Mapping()
        {

            CreateMap<Customer, CustomerVM>().ReverseMap();
            CreateMap<User, UserVM>().ReverseMap();
            CreateMap<User, LoginVM>().ReverseMap();
            CreateMap<Product, ProductVM>().ReverseMap();
        }
    }
}
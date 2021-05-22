using AutoMapper;
using Test1.Model;

namespace Test1.ViewModel
{
    public class Mapping : Profile
    {
        public Mapping(){ 
           
            CreateMap<Customer,CustomerVM>().ReverseMap()
                 //.ForMember(dest =>dest.IdRoomtype ,opt =>opt.MapFrom(src => src.ImgroomImgstoNavigation.ImgroomImgstoNavigation.IdRoomtype) ) 
                .ReverseMap();
        }
    }
}
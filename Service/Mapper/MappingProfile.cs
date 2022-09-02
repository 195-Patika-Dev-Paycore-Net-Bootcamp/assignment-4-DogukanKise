using AutoMapper;
using Data.Model.Concrete;
using Dto.Concrete;


namespace Service.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Map creation process using Automapper
            CreateMap<Vehicle, VehicleDto>();
            CreateMap<VehicleDto, Vehicle>();
            CreateMap<Container, ContainerDto>().ReverseMap();
        }
    }
}

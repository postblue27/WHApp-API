using AutoMapper;
using WHApp_API.Dtos;
using WHApp_API.Models;

namespace WHApp_API.Helpers
{
    public class AutoMapperProfiles :Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<WarehouseForCreateDto, Warehouse>();    
            CreateMap<ProductToAddDto, Product>();
            CreateMap<UserForRegisterDto, User>();
            CreateMap<CarToCreateDto, Car>();
        }
    }
}
using AutoMapper;
using CleanArchCqrs.Application.Dtos;

namespace CleanArchCqrs.Application.Mappings
{
    public class EntityToDtoMappingProfile : Profile
    {
        public EntityToDtoMappingProfile()
        {
            CreateMap<Domain.Entities.Product, ProductGetAllResponse>().ReverseMap();
            CreateMap<Domain.Entities.Product, ProductGetByIdResponse>().ReverseMap();
            CreateMap<Domain.Entities.Product, ProductCreateResponse>().ReverseMap();

            CreateMap<Domain.Entities.Category, CategoryGetAllResponse>().ReverseMap();
        }
    }
}

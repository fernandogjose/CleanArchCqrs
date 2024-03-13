using AutoMapper;
using CleanArchCqrs.Application.Dtos;

namespace CleanArchCqrs.Application.Mappings
{
    public class EntityToDtoMappingProfile : Profile
    {
        public EntityToDtoMappingProfile()
        {
            CreateMap<Domain.Entities.Product, ProductDto>();
            CreateMap<Domain.Entities.Category, CategoryDto>();
        }
    }
}

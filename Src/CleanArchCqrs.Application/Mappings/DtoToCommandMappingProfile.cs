using AutoMapper;
using CleanArchCqrs.Application.Cqrs.Product.Commands;
using CleanArchCqrs.Application.Dtos;

namespace CleanArchCqrs.Application.Mappings
{
    public class DtoToCommandMappingProfile : Profile
    {
        public DtoToCommandMappingProfile()
        {
            CreateMap<ProductCreateRequest, ProductCreateCommand>().ReverseMap();
            CreateMap<ProductUpdateRequest, ProductUpdateCommand>().ReverseMap();
        }
    }
}

using AutoMapper;
using CleanArchCqrs.Application.ComandsHandlers.Product.Commands;

namespace CleanArchCqrs.Application.Mappings
{
    public class CommandToEntityMappingProfile : Profile
    {
        public CommandToEntityMappingProfile()
        {
            CreateMap<ProductCreateCommand, Domain.Entities.Product>().ReverseMap();
            CreateMap<ProductUpdateCommand, Domain.Entities.Product>().ReverseMap();
            CreateMap<ProductDeleteCommand, Domain.Entities.Product>().ReverseMap();
        }
    }
}

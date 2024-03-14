using AutoMapper;
using CleanArchCqrs.Application.Cqrs.Product.Commands;

namespace CleanArchCqrs.Application.Mappings
{
    public class CommandToEntityMappingProfile : Profile
    {
        public CommandToEntityMappingProfile()
        {
            CreateMap<ProductCreateCommand, Domain.Entities.Product>().ReverseMap();
        }
    }
}

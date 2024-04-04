using AutoMapper;
using CleanArchCqrs.Application.ComandsHandlers.Payment.Commands;
using CleanArchCqrs.Application.ComandsHandlers.Product.Commands;
using CleanArchCqrs.Domain.Enums;

namespace CleanArchCqrs.Application.Mappings
{
    public class CommandToEntityMappingProfile : Profile
    {
        public CommandToEntityMappingProfile()
        {
            CreateMap<ProductCreateCommand, Domain.Entities.Product>().ReverseMap();
            CreateMap<ProductUpdateCommand, Domain.Entities.Product>().ReverseMap();
            CreateMap<ProductDeleteCommand, Domain.Entities.Product>().ReverseMap();

            CreateMap<PaymentCreateCommand, Domain.Entities.Payment>().ReverseMap()
                .BeforeMap((src, dest) => src.Status = PaymentStatusEnum.Received);
        }
    }
}

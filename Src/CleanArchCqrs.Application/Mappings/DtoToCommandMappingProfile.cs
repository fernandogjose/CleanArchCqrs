using AutoMapper;
using CleanArchCqrs.Application.ComandsHandlers.Payment.Commands;
using CleanArchCqrs.Application.ComandsHandlers.Product.Commands;
using CleanArchCqrs.Application.Dtos;

namespace CleanArchCqrs.Application.Mappings
{
    public class DtoToCommandMappingProfile : Profile
    {
        public DtoToCommandMappingProfile()
        {
            CreateMap<ProductCreateRequest, ProductCreateCommand>().ReverseMap();
            CreateMap<ProductUpdateRequest, ProductUpdateCommand>().ReverseMap();
            CreateMap<ProductDeleteRequest, ProductDeleteCommand>().ReverseMap();

            CreateMap<PaymentCreateRequest, PaymentCreateCommand>().ReverseMap();
        }
    }
}

using AutoMapper;
using CleanArchCqrs.Application.Cqrs.Category.Commands;
using CleanArchCqrs.Application.Cqrs.Category.Queries;
using CleanArchCqrs.Application.Cqrs.Product.Commands;
using CleanArchCqrs.Application.Cqrs.Product.Queries;
using CleanArchCqrs.Application.Dtos;

namespace CleanArchCqrs.Application.Mappings
{
    public class DtoToCommandMappingProfile : Profile
    {
        public DtoToCommandMappingProfile()
        {
            CreateMap<ProductCreateRequest, ProductCreateCommand>().ReverseMap();
            CreateMap<ProductGetAllResponse, ProductDeleteCommand>().ReverseMap();
            CreateMap<ProductGetAllResponse, ProductUpdateCommand>().ReverseMap();
            CreateMap<ProductGetAllResponse, ProductGetByIdQuery>().ReverseMap();

            CreateMap<Category, CategoryCreateCommand>().ReverseMap();
            CreateMap<Category, CategoryDeleteCommand>().ReverseMap();
            CreateMap<Category, CategoryUpdateCommand>().ReverseMap();
            CreateMap<Category, CategoryGetByIdQuery>().ReverseMap();
        }
    }
}

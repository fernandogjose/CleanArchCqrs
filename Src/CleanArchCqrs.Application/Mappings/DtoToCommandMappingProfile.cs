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
            CreateMap<ProductDto, ProductCreateCommand>();
            CreateMap<ProductDto, ProductDeleteCommand>();
            CreateMap<ProductDto, ProductUpdateCommand>();
            CreateMap<ProductDto, ProductGetByIdQuery>();

            CreateMap<CategoryDto, CategoryCreateCommand>();
            CreateMap<CategoryDto, CategoryDeleteCommand>();
            CreateMap<CategoryDto, CategoryUpdateCommand>();
            CreateMap<CategoryDto, CategoryGetByIdQuery>();
        }
    }
}

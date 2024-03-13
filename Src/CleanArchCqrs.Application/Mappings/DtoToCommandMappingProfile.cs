using AutoMapper;
using CleanArchCqrs.Application.Category.Commands;
using CleanArchCqrs.Application.Dtos;
using CleanArchCqrs.Application.Product.Commands;
using CleanArchCqrs.Application.Product.Queries;

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

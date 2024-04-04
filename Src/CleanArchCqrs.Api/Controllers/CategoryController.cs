using AutoMapper;
using CleanArchCqrs.Application.ComandsHandlers.Category.Queries;
using CleanArchCqrs.Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchCqrs.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly IMapper _mapper;

        public CategoryController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryGetAllResponse>>> Get()
        {
            var categoryGetAllQuery = new CategoryGetAllQuery();
            var categorysDtoResponse = await _mediator.Send(categoryGetAllQuery);

            return categorysDtoResponse == null || !categorysDtoResponse.Any()
                ? NotFound("Categories not found")
                : Ok(categorysDtoResponse);
        }

        [HttpGet("id:int")]
        public async Task<ActionResult<IEnumerable<CategoryGetAllResponse>>> Get([FromQuery] int id)
        {
            var categoryGetByIdQuery = new CategoryGetByIdQuery(id);
            var categoryDtoResponse = await _mediator.Send(categoryGetByIdQuery);

            return categoryDtoResponse == null 
                ? NotFound("Category not found")
                : Ok(categoryDtoResponse);
        }
    }
}

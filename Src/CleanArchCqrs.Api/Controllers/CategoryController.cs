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
            var categoryGetAllResponse = await _mediator.Send(new CategoryGetAllQuery());

            return categoryGetAllResponse == null || !categoryGetAllResponse.Any()
                ? NotFound("Categories not found")
                : Ok(categoryGetAllResponse);
        }

        [HttpGet("id:int")]
        public async Task<ActionResult<IEnumerable<CategoryGetAllResponse>>> Get([FromQuery] int id)
        {
            var categoryGetByIdResponse = await _mediator.Send(new CategoryGetByIdQuery(id));

            return categoryGetByIdResponse == null
                ? NotFound("Category not found")
                : Ok(categoryGetByIdResponse);
        }
    }
}

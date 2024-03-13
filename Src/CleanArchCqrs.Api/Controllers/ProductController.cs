using AutoMapper;
using CleanArchCqrs.Application.Dtos;
using CleanArchCqrs.Application.Product.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchCqrs.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly IMapper _mapper;

        public ProductController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> Get()
        {
            var productGetAllQuery = new ProductGetAllQuery();
            var productsDtoResponse = await _mediator.Send(productGetAllQuery);

            return productsDtoResponse == null || !productsDtoResponse.Any()
                ? NotFound("Products not found")
                : Ok(productsDtoResponse);
        }
    }
}

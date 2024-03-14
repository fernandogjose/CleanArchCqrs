using AutoMapper;
using CleanArchCqrs.Application.Cqrs.Product.Commands;
using CleanArchCqrs.Application.Cqrs.Product.Queries;
using CleanArchCqrs.Application.Dtos;
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

        [HttpPost]
        public async Task<ActionResult<ProductGetAllResponse>> Post([FromBody] ProductCreateRequest productCreateRequest)
        {
            var productCreateCommand = _mapper.Map<ProductCreateCommand>(productCreateRequest);
            var productCreateResponse = await _mediator.Send(productCreateCommand);

            return productCreateResponse == null
                ? NotFound("Product not created")
                : Created();
        }

        [HttpPut]
        public async Task<ActionResult<ProductGetAllResponse>> Put([FromBody] ProductUpdateRequest productUpdateRequest)
        {
            var productUpdateCommand = _mapper.Map<ProductUpdateCommand>(productUpdateRequest);
            var productUpdateResponse = await _mediator.Send(productUpdateCommand);

            return productUpdateResponse == null
                ? NotFound("Product not created")
                : Created();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductGetAllResponse>>> Get()
        {
            var productGetAllQuery = new ProductGetAllQuery();
            var productsDtoResponse = await _mediator.Send(productGetAllQuery);

            return productsDtoResponse == null || !productsDtoResponse.Any()
                ? NotFound("Products not found")
                : Ok(productsDtoResponse);
        }

        [HttpGet("id:int")]
        public async Task<ActionResult<ProductGetByIdResponse>> Get([FromQuery] int id)
        {
            var productGetByIdQuery = new ProductGetByIdQuery(id);
            var productDtoResponse = await _mediator.Send(productGetByIdQuery);

            return productDtoResponse == null
                ? NotFound("Product not found")
                : Ok(productDtoResponse);
        }
    }
}
